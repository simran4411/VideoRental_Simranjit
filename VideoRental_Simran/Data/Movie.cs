using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental_Simran.Data
{
   public class Movie : DataConnection
    {
        //this code is used to pass the record in the  database 
        public void addMovieData(String qry) {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }

        //this code is used to pass the record in the  database 
        public void delMovieData(String qry)
        {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }

        public void editMovieData(String qry)
        {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }

        public int CountRecord(String Qry)
        {
            DataTable tbl = new DataTable();

            tbl = srchRecord(Qry);
            return tbl.Rows.Count;

        }
        public int CountSample(String Qry)
        {
            DataTable tbl = new DataTable();

            tbl = srchRecord(Qry);
            return Convert.ToInt32(tbl.Rows[tbl.Rows.Count-1]["Copies"].ToString());

        }


        public int getCost(String Qry)
        {
            DataTable tbl = new DataTable();

            tbl = srchRecord(Qry);
            return Convert.ToInt32(tbl.Rows[tbl.Rows.Count - 1]["Cost"].ToString());

        }




    }
}
