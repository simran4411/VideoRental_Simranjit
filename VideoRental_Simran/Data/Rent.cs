using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental_Simran.Data
{
    public class Rent: DataConnection
    {

        //this code is used to pass the record in the  database 
        public void addRentData(String qry)
        {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }

        //this code is used to pass the record in the  database 
        public void delRentData(String qry)
        {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }

        public void editRentData(String qry)
        {
            //calling the method from the Database Connection file 
            SqlQuery(qry);

        }


        public int countSample(String Qry) {
            DataTable tbl = new DataTable();

            tbl = srchRecord(Qry);
            return tbl.Rows.Count;


        }

    }
}
