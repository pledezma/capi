using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace model
{
    public class cnx
    {
        //string cadena = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        public SqlConnection conectar = new SqlConnection();
        public SqlTransaction transaction;
        public cnx()
        {
            conectar.ConnectionString = GetConnectionString();
        }
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Data Source=172.16.127.6;Initial Catalog=AMI;User ID=sa;Password=coop34LF4roRu1z";
                //+ "Integrated Security=true;";
        }
        public bool abrir()
        {
            bool re = false;
            try
            {
                this.conectar.Open();
                re = true;
            }
            catch (Exception)
            {
                re = false;
            }
            return re;
        }
        public bool do_transaction(List<string> tranList) {
            bool re = false;
            try
            {
                if (conectar.State != ConnectionState.Open)
                {
                    this.abrir();
                }
                transaction = conectar.BeginTransaction("MyTransaction");
                foreach (var item in tranList)
                {
                    SqlCommand cmd = new SqlCommand(item, conectar, transaction);
                    cmd.ExecuteNonQuery();
                }  
                transaction.Commit(); 
                re = true;
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    
                }
            }
            this.cerrar();
            return re;
        }
        public bool cerrar()
        {
            bool re = false;
            try
            {
                this.conectar.Close();
                re = true;
            }
            catch (Exception)
            {
                re = false;
            }
            return re;
        }
        public DataTable hacerSelect(string _query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(_query, conectar);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                if (conectar.State != ConnectionState.Open)
                {
                    this.abrir();
                }
                dt.Load(cmd.ExecuteReader());
                this.cerrar();
            }
            catch (Exception)
            {

            }
            return dt;
        }
        public bool hacerHit(string _query)
        {
            bool res = false;
            try
            {
                SqlCommand cmd = new SqlCommand(_query, conectar);

                if (conectar.State != ConnectionState.Open)
                {
                    this.abrir();
                }
                cmd.ExecuteNonQuery();
                this.cerrar();
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

    }
}