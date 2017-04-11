using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Npgsql;
using System.Threading;
using System.Transactions;
using System.Data.Common;

namespace CGCN.DataAccess
{
    public class PostgreHeplper
    {
        public PostgreHeplper()
        {
            
        }
        #region private methods
        private static object CheckValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }
        private static NpgsqlConnection GetTransactionNpgsqlConnection(string connectionString)
        {
            LocalDataStoreSlot namedDataSlot = Thread.GetNamedDataSlot("ConnectionDictionary");
            Dictionary<string, NpgsqlConnection> data = (Dictionary<string, NpgsqlConnection>)Thread.GetData(namedDataSlot);
            if (data == null)
            {
                data = new Dictionary<string, NpgsqlConnection>();
                Thread.SetData(namedDataSlot, data);
            }
            NpgsqlConnection connection = null;
            if (data.ContainsKey(connectionString))
            {
                return data[connectionString];
            }
            connection = new NpgsqlConnection(connectionString);
            data.Add(connectionString, connection);
            Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);
            return connection;
        }
        private static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            Dictionary<string, NpgsqlConnection> data = (Dictionary<string, NpgsqlConnection>)Thread.GetData(Thread.GetNamedDataSlot("ConnectionDictionary"));
            if (data != null)
            {
                foreach (NpgsqlConnection connection in data.Values)
                {
                    if ((connection != null) && (connection.State != ConnectionState.Closed))
                    {
                        connection.Close();
                    }
                }
                data.Clear();
            }
            Thread.FreeNamedDataSlot("ConnectionDictionary");
        }
        private static NpgsqlCommand CreateCommand(NpgsqlConnection connection, CommandType commandType, string commandText)
        {
            if ((connection != null) && (connection.State == ConnectionState.Closed))
            {
                connection.Open();
            }
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                command.CommandType = commandType;
                return command;
            }
        }
        private static NpgsqlCommand CreateCommand(NpgsqlConnection connection, CommandType commandType, string commandText, params object[] values)
        {
            if ((connection != null) && (connection.State == ConnectionState.Closed))
            {
                connection.Open();
            }
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                command.CommandType = commandType;
                if ((values == null) || (values.Length == 0))
                {
                    for (int j = 0; j < command.Parameters.Count; j++)
                    {
                        command.Parameters[j].Value = DBNull.Value;
                    }
                    return command;
                }
                command.Parameters.AddRange(values);
                return command;
            }
        }
        private static DataSet CreateDataSet(NpgsqlCommand command)
        {
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }
        private static DataTable CreateDataTable(NpgsqlCommand command)
        {
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        #endregion
        #region public methods
        public static DataSet ExecuteDataSet(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataSet(connectionString, commandType, commandText, (DbParameter[])null);
        }
        public static DataSet ExecuteDataSet(string connectionString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            if (Transaction.Current == null)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = CreateCommand(connection, commandType, commandText, parameters))
                    {
                        return CreateDataSet(command);
                    }
                }
            }
            using (NpgsqlCommand command2 = CreateCommand(GetTransactionNpgsqlConnection(connectionString), commandType, commandText, parameters))
            {
                return CreateDataSet(command2);
            }
        }
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, (DbParameter[])null);
        }
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            if (Transaction.Current == null)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = CreateCommand(connection, commandType, commandText, parameters))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            using (NpgsqlCommand command2 = CreateCommand(GetTransactionNpgsqlConnection(connectionString), commandType, commandText, parameters))
            {
                return command2.ExecuteNonQuery();
            }
        }
        public static IDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteReader(connectionString, commandType, commandText, (DbParameter[])null);
        }
        public static IDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            if (Transaction.Current == null)
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                using (NpgsqlCommand command = CreateCommand(connection, commandType, commandText, parameters))
                {
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            using (NpgsqlCommand command2 = CreateCommand(GetTransactionNpgsqlConnection(connectionString), commandType, commandText, parameters))
            {
                return command2.ExecuteReader();
            }
        }
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            if (Transaction.Current == null)
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                using (NpgsqlCommand command = CreateCommand(connection, commandType, commandText, parameters))
                {
                    return command.ExecuteScalar();
                }
            }
            using (NpgsqlCommand command2 = CreateCommand(GetTransactionNpgsqlConnection(connectionString), commandType, commandText, parameters))
            {
                return command2.ExecuteScalar();
            }
        }
        #endregion
    }
}
