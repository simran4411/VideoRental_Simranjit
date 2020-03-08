using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoRental_Simran.Data;
namespace VideoRental_Simran
{
    
    public partial class Form1 : Form
    {
        int cost = 0, RentID = 0;
        int choice = 0; 

        Data.Movie obj = new Data.Movie();
        Data.Customer obj_Customer = new Data.Customer();

        Data.Rent obj_Rent = new Data.Rent();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Name.Text.ToString().Equals("") && !Age.Text.ToString().Equals("") && !Phone.Text.ToString().Equals("") && !city.Text.ToString().Equals("")) {
                String DataQuery = "insert into Client (Name,Age,Phone,City) values ('"+Name.Text.ToString()+"',"+Convert.ToInt32(Age.Text.ToString())+",'"+Phone.Text.ToString()+"','"+city.Text.ToString()+"')";
                obj_Customer.addClientData(DataQuery);
                MessageBox.Show("Client Data is Saved ");
                Name.Text = "";
                Age.Text = "";
                Phone.Text = "";
                city.Text = "";


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Title.Text.ToString().Equals("") && !Ratting.Text.ToString().Equals("") && !Year.Text.ToString().Equals("") && !Genre.Text.ToString().Equals("") && !sample.Text.ToString().Equals("")) {




                //get the curreent date and time 
                DateTime dateNow = DateTime.Now;

                // get the year 
                int Currentyear = dateNow.Year;

                //get the difference between year 
                int diffYear = Currentyear - Convert.ToInt32(Year.Text.ToString());

                //get the difference if the difference is greater then 5 then the cost is 2 dollar otherwise 5 dollar 
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                String dataQuery = "insert into Movie (Name,Ratting,Year,Copies,Genre,Cost) values('"+Title.Text.ToString()+"','"+Ratting.Text.ToString()+"',"+Convert.ToInt32(Year.Text.ToString())+","+Convert.ToInt32(sample.Text.ToString())+",'"+Genre.Text.ToString()+"',"+cost+")";
                obj.addMovieData(dataQuery);
                MessageBox.Show("Movie is Stored in the Table ");

                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MovieID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the Movie Data to Delete ");
            }
            else {


                if (obj.CountRecord("select * form Movie where MovieID=" + Convert.ToInt32(MovieID.Text.ToString()) + " and ReturnDate='Issue'") == 0)
                {


                    String DataQuery = "delete from Movie where id=" + Convert.ToInt32(MovieID.Text.ToString()) + "";
                    obj.delMovieData(DataQuery);
                    MessageBox.Show("Selected Movie is Deleted ");
                }
                else {
                    MessageBox.Show("Movie is already issued on rent ");
                }
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";


            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (!Title.Text.ToString().Equals("") && !Ratting.Text.ToString().Equals("") && !Year.Text.ToString().Equals("") && !Genre.Text.ToString().Equals("") && !sample.Text.ToString().Equals("") && ! MovieID.Text.ToString().Equals("")) {

                String DataQuery = "update Movie set Name='"+Title.Text.ToString()+"',Ratting='"+Ratting.Text.ToString()+"',Year="+Convert.ToInt32(Year.Text.ToString())+",Copies="+Convert.ToInt32(sample.Text.ToString())+",Genre='"+Genre.Text.ToString()+"',Cost="+Convert.ToInt32(cost)+ " where id=" + Convert.ToInt32(MovieID.Text.ToString()) + "";
                obj.editMovieData(DataQuery);
                MessageBox.Show("Movie Record is Updated ");
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ClientID.Text.ToString().Equals("")) {

                if (obj_Customer.CountRecord("select * from Rental where ClientID=" + Convert.ToInt32(ClientID.Text.ToString()) + " and ReturnDate='Issue'") == 0)
                {



                    String DataQuery = "delete from Client where id=" + Convert.ToInt32(ClientID.Text.ToString()) + "";
                    obj_Customer.delClientData(DataQuery);

                    MessageBox.Show("Client Data Is Deleted  ");
                }
                else {
                    MessageBox.Show("You already have a cd ");
                }
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";
                ClientID.Text = "";

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ClientID.Text.ToString().Equals("") && !Name.Text.ToString().Equals("") && !Age.Text.ToString().Equals("") && !Phone.Text.ToString().Equals("") && !city.Text.ToString().Equals(""))
            {
                String DataQuery = "Update Client set Name='"+Name.Text.ToString()+"', Age="+Convert.ToInt32(Age.Text.ToString())+", Phone='"+Phone.Text.ToString()+"',City='"+city.Text.ToString()+"' where id="+Convert.ToInt32(ClientID.Text.ToString())+"";
                obj_Customer.editClientData(DataQuery);
                MessageBox.Show("Client Details are edited ");
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";
                ClientID.Text = "";


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (RentID>=0) {
                String DataQuery = "Delete from Rental where id="+Convert.ToInt32(RentID)+"";
                obj_Rent.delRentData(DataQuery);
                MessageBox.Show("Rental Entry is deleted ");
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";
                ClientID.Text = "";


                Name.Text = "";
                Age.Text = "";
                Phone.Text = "";
                city.Text = "";




            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (RentID>0) {

                int MovieCost = obj.getCost("select * from Movie where id="+Convert.ToInt32(MovieID.Text.ToString())+"");


                DateTime new_date = DateTime.Now;

                //convert the old date from string to Date fromat
                DateTime prev_date = Convert.ToDateTime(MovieIssue.Text.ToString());


                //get the difference in the days fromat
                String Daysdiff = (new_date - prev_date).TotalDays.ToString();


                // calculate the round off value 
                Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));



                int charges = Convert.ToInt32(DaysInterval) * MovieCost;





                String DataQuery = "Update Rental set MovieID="+Convert.ToInt32(MovieID.Text.ToString())+",ClientID="+Convert.ToInt32(ClientID.Text.ToString())+",IssueDate='"+MovieIssue.Text.ToString()+"',ReturnDate='"+MovieReturn.Text.ToString()+"' where ID="+Convert.ToInt32(RentID)+"";
                obj_Rent.editRentData(DataQuery);


                MessageBox.Show("Movie is return and your charges is ==$"+charges); 

                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";
                ClientID.Text = "";


                Name.Text = "";
                Age.Text = "";
                Phone.Text = "";
                city.Text = "";


            }



        }

        private void Client_Click(object sender, EventArgs e)
        {
            choice = 1;
            String DataQuery = "select * from Client";
            DataTable tbl = new DataTable();

                tbl=obj_Customer.srchRecord(DataQuery);
            dataGridView1.DataSource = tbl;


        }

        private void Movie_Click(object sender, EventArgs e)
        {
            choice = 2;
            String DataQuery = "select * from Movie";
            DataTable tbl = new DataTable();

            tbl = obj_Customer.srchRecord(DataQuery);
            dataGridView1.DataSource = tbl;
        }

        private void Rental_Click(object sender, EventArgs e)
        {
            choice = 3;
            String DataQuery = "select * from Rental";
            DataTable tbl = new DataTable();

            tbl = obj_Customer.srchRecord(DataQuery);
            dataGridView1.DataSource = tbl;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (choice == 1) {
                //client 
                ClientID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Age.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                city.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();



            } else if (choice == 2) {
                MovieID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Title.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Ratting.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Year.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Genre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                sample.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            } else if (choice==3) {

                RentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MovieID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ClientID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                MovieIssue.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }
            choice = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!ClientID.Text.ToString().Equals("") && !MovieID.Text.ToString().Equals("")) {

                int countClient = obj_Customer.CountRecord("select * from Rental where ClientID=" + Convert.ToInt32(ClientID.Text.ToString()) + " and ReturnDate='Issue'");
                int countSample = obj.CountSample("select * from Movie where id="+Convert.ToInt32(MovieID.Text.ToString())+"");
                int countIssue = obj.CountRecord("select * from Rental Where MovieID="+Convert.ToInt32(MovieID.Text.ToString())+" and ReturnDate='Issue'");

                if (countClient > 1)
                {
                    MessageBox.Show("You already have 2 cd on rent ");
                }
                else if (countIssue < countSample)
                {




                    String DataQuery = "insert into Rental (MovieID,ClientID,IssueDate,ReturnDate) values (" + Convert.ToInt32(MovieID.Text.ToString()) + "," + Convert.ToInt32(ClientID.Text.ToString()) + ",'" + MovieIssue.Text.ToString() + "','Issue')";
                    obj_Rent.addRentData(DataQuery);
                    MessageBox.Show("Movie is Issued on Rent ");
                }
                else {
                    MessageBox.Show("all samples are already booked ");
                }
                Title.Text = "";
                Year.Text = "";
                Ratting.Text = "";
                Genre.Text = "";
                sample.Text = "";
                MovieID.Text = "";
                ClientID.Text = "";


                Name.Text = "";
                Age.Text = "";
                Phone.Text = "";
                city.Text = "";

                  
            }




        }
    }
}
