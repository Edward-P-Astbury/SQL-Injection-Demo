using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Injection_Demo
{
    public class SqlDbConnect
    {
        private SqlConnection _connection;
        public SqlCommand _command;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable;

        public SqlDbConnect()
        {
            // Connect to SQL server database
            _connection = new SqlConnection(@"Data Source=DESKTOP-J29SF5J\SQLEXPRESS;Initial Catalog=SQL-Injection;Integrated Security=True"); // local express instance of the database
            _connection.Open();
        }

        // Insecure way.
        public void SqlQuery(string query)
        {
            _command = new SqlCommand(query, _connection);
        }

        public DataTable RetrieveQuery()
        {
            _adapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _adapter.Fill(_dataTable);
            return _dataTable;
        }

        public void NonQuery()
        {
            _command.ExecuteNonQuery(); // executes a query that is not expecting to produce any results, the return value is the number of rows affected
            _connection.Close();
        }
    }
}