using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace WMSAPI.Context
{
    public class DBWMSConnect
    {
        private readonly IConfiguration configuration;
        private readonly SqlCommand sqlCommand;
        private string ConnString { get; set; }
        private string GetConnectionString()
        {
            return configuration.GetConnectionString(ConnString);
        }

        public DBWMSConnect(IConfiguration _configuration, string _connString = "WMSConnection")
        {
            configuration = _configuration;
            ConnString = _connString;
            sqlCommand = new SqlCommand();
        }

        public void OpenConnection()
        {
            if (sqlCommand.Connection == null)
            {
                sqlCommand.Connection = new SqlConnection(GetConnectionString());
            }

            if (sqlCommand.Connection.State != ConnectionState.Open)
            {
                sqlCommand.Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlCommand.Connection.State != ConnectionState.Closed)
            {
                sqlCommand.Connection.Close();
            }
        }

        public void SetCommandText(string sql)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
        }

        public void SetCommandStoredProcedure(string storedProcName)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = storedProcName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        #region Parameters

        public SqlParameter AddOutputParameter(string paramName, SqlDbType paramType)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);
            param.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(param);
            return param;
        }
        public SqlParameter AddOutputParameter(string paramName, SqlDbType paramType, int paramSize)
        {
            SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
            param.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(param);
            return param;
        }

        public void AddInputParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);
            param.Value = paramValue;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
        }
        public void AddInputParameter(string paramName, SqlDbType paramType, int paramSize, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
            param.Value = paramValue;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
        }

        #endregion

        #region Executes
        public T ExecuteJSON<T>()
        {
            try
            {
                OpenConnection();
                var jsonResult = new StringBuilder();
                var reader = sqlCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }

                string tmpJSONString = jsonResult.ToString();
                var result = JsonConvert.DeserializeObject<T>(tmpJSONString);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public object ExecuteScalar()
        {
            object result;
            try
            {
                OpenConnection();
                result = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public bool ExecuteNonQuery()
        {
            int rowsAffected = 0;
            try
            {
                OpenConnection();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return rowsAffected != 0;
        }

        public List<T> ExecuteToList<T>()
        {
            Type genericListType = typeof(List<>);
            Type concreteListType = genericListType.MakeGenericType(typeof(T));
            IList list = Activator.CreateInstance(concreteListType) as IList;
            try
            {
                OpenConnection();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object entity = Activator.CreateInstance(typeof(T));
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string field_name = reader.GetName(i);
                            object field_value = DBNull.Value == reader[i] ? null : reader[i];

                            PropertyInfo property = typeof(T).GetProperty(field_name);
                            if (property != null && property.CanWrite)
                            {
                                //RegularEntity
                                var t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                var safeValue = field_value == null ? null : Convert.ChangeType(field_value, t);
                                property.SetValue(entity, safeValue, null);
                            }
                        }
                        list.Add((T)entity);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return (List<T>)list;
        }

        #endregion

        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    sqlCommand.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
