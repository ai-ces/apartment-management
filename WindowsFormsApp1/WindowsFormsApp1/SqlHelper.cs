﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    internal class SqlHelper
    {
        private string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }

        public SqlHelper()
        {
            Connection = new SqlConnection();
            ConnectionString = @"Data Source =CES/SQLEXPRESS; Initial Catalog= apartment; Integrated Security=True";
        }

        public void ExecuteProc(string procName, params SqlParameter[] ps)
        {
            SqlCommand command = SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddRange(ps);
            command.Connection = Connection;
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
        }

        public DataTable GetTable(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}