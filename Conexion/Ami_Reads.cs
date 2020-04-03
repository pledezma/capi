using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    public class Ami_Reads
    {
        public DateTime fecha_lectura { get; set; }
        public int whd { get; set; }
        public string cod_medidor { get; set; }
        public int whr { get; set; }
        public int whnet { get; set; }
        public string token_result { get; set; }
        public string esn { get; set; }
        public string serialnumber { get; set; }
        public string readjson { get; set; }
        public string token_request { get; set; }
        public int period { get; set; }

        public DateTime executedDate { get; set; }

        public bool insert()
        {
            bool r = false;
            string q =
                "INSERT INTO AMI.dbo.Ami_Reads " +
                "(fecha_lectura, whd, cod_medidor, whr, whnet, token_result, esn, serialnumber, readjson, token_request, period) " +
                "VALUES('" + fecha_lectura.ToString("yyyy-MM-dd HH:mm:ss")  + "',"+ whd + ",'" + cod_medidor + "',"+ whr + ","+ whnet + ",'" + token_result + "','" + esn + "','" + serialnumber + "','" + readjson + "','" + token_request + "',"+ period + "); ";
             
            cnx cnx = new cnx();

            if (cnx.abrir())
            {
                r = cnx.hacerHit(q);
            }
            return r;
        }
        public string qInsert()
        { 
            string q =
                "INSERT INTO AMI.dbo.Ami_Reads " +
                "(fecha_lectura, whd, cod_medidor, whr, whnet, token_result, esn, serialnumber, readjson, token_request, period) " +
                "VALUES('" + fecha_lectura.ToString("yyyy-MM-dd HH:mm:ss") + "'," + whd + ",'" + cod_medidor + "'," + whr + "," + whnet + ",'" + token_result + "','" + esn + "','" + serialnumber + "','" + readjson + "','" + token_request + "'," + period + "); ";

            
            return q;
        }
        public bool transaction(List<string> tranList)
        {
            bool r = false;
            cnx cnx = new cnx();
            r = cnx.do_transaction(tranList);
            return r;
        }
    }
} 