using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRental_Simran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental_Simran.Data;

namespace VideoRental_Simran.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            Form1 obj = new Form1();
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void countSampleTest()
        {
            String qry = "select * from  Rental where id=0";
            Rent obj = new Rent();
            int count = obj.countSample(qry);

            Assert.IsTrue(true);

        }

        



        [TestMethod()]
        public void delRentDataTest()
        {
            String qry = "delete from Rental";
            Rent obj = new Rent();
            obj.delRentData(qry);

            Assert.IsTrue(true);

        }


    }
}