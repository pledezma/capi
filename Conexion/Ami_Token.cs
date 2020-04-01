using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace model
{
    /*
        create table Ami_Token(
        id int identity,
        status varchar(100),
        token varchar(200) ,
        meter varchar(200) ,
        tokenType varchar(250),
        period int, 
        executedDate dateTime
        primary key(id)
        )
    */
    public class Ami_Token
    {
        public int id { get; set; }
        public int status { get; set; }
        public string token { get; set; }
        public string meter { get; set; }
        public string tokenType { get; set; }
        public int period { get; set; }
        public DateTime executedDate { get; set; }

        public bool setData(string q)
        {
            bool r = false; 

            cnx cnx = new cnx();

            if (cnx.abrir())
            {
                r = cnx.hacerHit(q);
            }
            return r;
        }
        public bool updateData(string q)
        {
            bool r = false;

            cnx cnx = new cnx();

            if (cnx.abrir())
            {
                r = cnx.hacerHit(q);
            }
            return r;
        }
        public bool insert()
        {
            bool r = false;

            string q =
               "INSERT INTO AMI.dbo.Ami_Token " +
               "(token,status, meter, tokenType, period, executedDate) " +
               "VALUES('" + token + "'," + status + ", '" + meter + "','" + tokenType + "', " + period + ", GETDATE()); ";
            r = setData(q);
            return r;
        }
        
        private Ami_Token[] getData(string q)
        {
            model.cnx cnx = new cnx();
            DataTable dataTable = new DataTable();
            Ami_Token t = null;
            Ami_Token[] tarr = null;            
            dataTable = cnx.hacerSelect(q);
            int cantidad = dataTable.Rows.Count;
            if (dataTable != null && cantidad > 0)
            {
                tarr = new Ami_Token[cantidad];
                for (int i = 0; i < cantidad; i++)
                {
                    t = new Ami_Token();
                    t.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    t.meter = dataTable.Rows[i]["meter"].ToString();
                    t.period = int.Parse(dataTable.Rows[i]["period"].ToString()); 
                    t.status = int.Parse(dataTable.Rows[i]["status"].ToString());
                    t.token = dataTable.Rows[i]["token"].ToString();
                    t.tokenType = dataTable.Rows[i]["tokenType"].ToString(); 

                    tarr[i] = t ;
                }
            }

            return tarr;
        }

        public Ami_Token[] getAllTokenByStatus(int status) {
            string q = "select * from Ami_Token where status = " + status + " and tokenType = '" + tokenType + "' order by id desc;";
            Ami_Token[] tarr = getData(q);
            return tarr;
        }
        public Ami_Token[] getAllTokenByTokenType( )
        {
            string q = "select * from Ami_Token where tokenType = '" + tokenType + "' and  status = " + status + "  order by id desc;";
            Ami_Token[] tarr = getData(q);
            return tarr;
        }
        public bool updateStatusByToken() {
            bool r = false; 
            string q =
               "UPDATE AMI.dbo.Ami_Token " +
               "SET status = " + status + " where token = '" + token + "' ; ";
            r = updateData(q);
            return r; 
        }
        public bool updateStatusByMeter__()
        {
            bool r = false;
            string q =
               "UPDATE AMI.dbo.Ami_Token " +
               "SET status = " + status + " where meter = '" + meter + "' ; ";
            r = updateData(q);
            return r;
        }
        public Ami_Token[] getTokenProcesadoInPeriodoByMeter()
        {
            string q = " select top(1)* from Ami_Token inner join Ami_Period " +
                    " on Ami_Token.period = Ami_Period.id " +
                    " where Ami_Period.status = 1 "+
                    " and Ami_Token.meter = " + meter +
                    " and Ami_Token.status = " + status +
                    " and Ami_Token.tokenType = '" + tokenType + "'" +
                    " order by Ami_Token.id asc"; 
            Ami_Token[] tarr = getData(q);
            return tarr;
        }
        public Ami_Token[] getTokenByMeter()
        {
            string q = " select top(1)* from Ami_Token inner join Ami_Period " +
                    " on Ami_Token.period = Ami_Period.id " +
                    " where Ami_Period.status = 1 " +
                    " and Ami_Token.meter = " + meter + 
                    " and Ami_Token.tokenType = '" + tokenType + "'" +
                    " order by Ami_Token.id asc";
            Ami_Token[] tarr = getData(q);
            return tarr;
        }

    }
} 
