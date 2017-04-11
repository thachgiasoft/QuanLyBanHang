using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using System.Security.Cryptography;

namespace CGCN.Framework
{
    public class DataAccessLayerBaseClass
    {
        private IDbCommand command;
        private IDbConnection connection;
        private string strConnectionString;
        private IDbTransaction transaction;

        // Methods
        protected DataAccessLayerBaseClass()
        {
        }

        public DataAccessLayerBaseClass(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void BeginTransaction()
        {
            if (this.transaction == null)
            {
                try
                {
                    this.connection = this.GetDataProviderConnection();
                    this.connection.ConnectionString = this.ConnectionString;
                    this.connection.Open();
                    this.transaction = this.connection.BeginTransaction(IsolationLevel.ReadCommitted);
                }
                catch
                {
                    this.connection.Close();
                    throw;
                }
            }
        }

        public void CloseConnection()
        {
            if (this.connection != null)
            {
                this.connection.Close();
                this.transaction = null;
            }
        }

        public void CommitTransaction()
        {
            if (this.transaction != null)
            {
                try
                {
                    this.transaction.Commit();
                }
                catch
                {
                    this.RollbackTransaction();
                    throw;
                }
                finally
                {
                    this.connection.Close();
                    this.transaction = null;
                }
            }
        }

        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] buffer;
            byte[] inputBuffer = Convert.FromBase64String(cipherString);
            string machineCode = this.GetMachineCode();
            if (useHashing)
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(machineCode));
                provider.Clear();
            }
            else
            {
                buffer = Encoding.UTF8.GetBytes(machineCode);
            }
            TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
            {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] bytes = provider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            provider2.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] buffer;
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            string machineCode = this.GetMachineCode();
            if (useHashing)
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(machineCode));
                provider.Clear();
            }
            else
            {
                buffer = Encoding.UTF8.GetBytes(machineCode);
            }
            TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
            {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            provider2.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public IDataReader ExecuteDataReader(string commandText)
        {
            return this.ExecuteDataReader(commandText, CommandType.Text, null);
        }

        public IDataReader ExecuteDataReader(string commandText, CommandType commandType)
        {
            return this.ExecuteDataReader(commandText, commandType, null);
        }

        public IDataReader ExecuteDataReader(string commandText, IDataParameter[] commandParameters)
        {
            return this.ExecuteDataReader(commandText, CommandType.Text, commandParameters);
        }

        public IDataReader ExecuteDataReader(string commandText, CommandType commandType, IDataParameter[] commandParameters)
        {
            IDataReader reader2;
            try
            {
                IDataReader reader;
                this.PrepareCommand(commandType, commandText, commandParameters);
                if (this.transaction == null)
                {
                    reader = this.command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = this.command.ExecuteReader();
                }
                reader2 = reader;
            }
            catch
            {
                if (this.transaction != null)
                {
                    this.RollbackTransaction();
                }
                throw;
            }
            finally
            {
                if (this.transaction == null)
                {
                    this.connection.Close();
                    this.command.Dispose();
                }
            }
            return reader2;
        }

        public DataSet ExecuteDataSet(string commandText)
        {
            return this.ExecuteDataSet(commandText, CommandType.Text, null);
        }

        public DataSet ExecuteDataSet(string commandText, IDataParameter[] commandParameters)
        {
            return this.ExecuteDataSet(commandText, CommandType.Text, commandParameters);
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            return this.ExecuteDataSet(commandText, commandType, null);
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, IDataParameter[] commandParameters)
        {
            DataSet set2;
            try
            {
                this.PrepareCommand(commandType, commandText, commandParameters);
                IDbDataAdapter dataProviderDataAdapter = this.GetDataProviderDataAdapter();
                dataProviderDataAdapter.SelectCommand = this.command;
                DataSet dataSet = new DataSet();
                dataProviderDataAdapter.Fill(dataSet);
                set2 = dataSet;
            }
            catch (Exception exception)
            {
                if (this.transaction != null)
                {
                    this.RollbackTransaction();
                }
                throw exception;
            }
            finally
            {
                if (this.transaction == null)
                {
                    this.connection.Close();
                    this.command.Dispose();
                }
            }
            return set2;
        }

        public int ExecuteQuery(string commandText)
        {
            return this.ExecuteQuery(commandText, CommandType.Text, null);
        }

        public int ExecuteQuery(string commandText, IDataParameter[] commandParameters)
        {
            return this.ExecuteQuery(commandText, CommandType.StoredProcedure, commandParameters);
        }

        public int ExecuteQuery(string commandText, CommandType commandType)
        {
            return this.ExecuteQuery(commandText, commandType, null);
        }

        public int ExecuteQuery(string commandText, CommandType commandType, IDataParameter[] commandParameters)
        {
            int num2;
            try
            {
                this.PrepareCommand(commandType, commandText, commandParameters);
                num2 = this.command.ExecuteNonQuery();
            }
            catch
            {
                if (this.transaction != null)
                {
                    this.RollbackTransaction();
                }
                throw;
            }
            finally
            {
                if (this.transaction == null)
                {
                    this.connection.Close();
                    this.command.Dispose();
                }
            }
            return num2;
        }

        public object ExecuteScalar(string commandText)
        {
            return this.ExecuteScalar(commandText, CommandType.Text, null);
        }

        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            return this.ExecuteScalar(commandText, commandType, null);
        }

        public object ExecuteScalar(string commandText, IDataParameter[] commandParameters)
        {
            return this.ExecuteScalar(commandText, CommandType.Text, commandParameters);
        }

        public object ExecuteScalar(string commandText, CommandType commandType, IDataParameter[] commandParameters)
        {
            object obj3;
            try
            {
                this.PrepareCommand(commandType, commandText, commandParameters);
                object obj2 = this.command.ExecuteScalar();
                if (obj2 != DBNull.Value)
                {
                    return obj2;
                }
                obj3 = null;
            }
            catch
            {
                if (this.transaction != null)
                {
                    this.RollbackTransaction();
                }
                throw;
            }
            finally
            {
                if (this.transaction == null)
                {
                    this.connection.Close();
                    this.command.Dispose();
                }
            }
            return obj3;
        }

        private NpgsqlCommand GeDataProviderCommand()
        {
            return new NpgsqlCommand();
        }

        private NpgsqlConnection GetDataProviderConnection()
        {
            return new NpgsqlConnection(this.ConnectionString);
        }

        private NpgsqlDataAdapter GetDataProviderDataAdapter()
        {
            return new NpgsqlDataAdapter();
        }

        private string GetMachineCode()
        {
            return "_tungpt_";
        }

        private void PrepareCommand(CommandType commandType, string commandText, IDataParameter[] commandParameters)
        {
            if (this.connection == null)
            {
                this.connection = this.GetDataProviderConnection();
                this.connection.ConnectionString = this.ConnectionString;
            }
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
            if (this.command == null)
            {
                this.command = this.GeDataProviderCommand();
                this.command.CommandTimeout = 0;
            }
            this.command.Connection = this.connection;
            this.command.CommandText = commandText;
            this.command.CommandType = commandType;
            this.command.Parameters.Clear();
            if (this.transaction != null)
            {
                this.command.Transaction = this.transaction;
            }
            if (commandParameters != null)
            {
                foreach (IDataParameter parameter in commandParameters)
                {
                    if ((parameter.Value == null) || parameter.Value.ToString().Length.Equals(0))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    this.command.Parameters.Add(parameter);
                }
            }
        }

        public void RollbackTransaction()
        {
            if (this.transaction != null)
            {
                try
                {
                    this.transaction.Rollback();
                }
                catch
                {
                }
                finally
                {
                    this.connection.Close();
                    this.transaction = null;
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                if ((this.strConnectionString == string.Empty) || (this.strConnectionString.Length == 0))
                {
                    throw new ArgumentException("Invalid database connection string.");
                }
                return this.strConnectionString;
            }
            set
            {
                this.strConnectionString = value;
            }
        }
    }
}

