using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickectBooking
{
    public class SearchInfo
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TickectBookingPt;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        public static string stpt;
        public static string edpt;
        public static string cltp;
        public static int ptct;
        public static DateTime DatE;
        public static DateTime TimE;

        public static string id;
        public int num;

        public static void select()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("selectpro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($" BookingId : {reader["BookingId"]}," +
                                $"StartPoint : {reader["StartPoint"]}," +
                                $"EndingPoint : {reader["EndingPoint"]}," +
                                $"ClassType : {reader["ClassType"]}," +
                                $"PeopleCount : {reader["PeopleCount"]}," +
                                $"Datee : {reader["Datee"]}," +
                                $"Timee :{reader["Timee"]}");
                        }

                        Console.WriteLine("Selected Statement Will Be Executed Successfully");
                    }
                }

            }
           
        }

        public static void inpt()
        {
            Console.WriteLine("Enter A Starting Point");
            stpt = Console.ReadLine();
            Console.WriteLine("Enter A Ending Point");
            edpt = Console.ReadLine();
            Console.WriteLine("Enter A Class Type");
            cltp = Console.ReadLine();
            Console.WriteLine("Enter A People Count");
            ptct = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter A Date");
            DatE = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter A Time");
            TimE = Convert.ToDateTime(Console.ReadLine());

        }

        public static void insertvalue()
        {
            inpt();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insertpro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartPoint", stpt);
                    cmd.Parameters.AddWithValue("@EndingPoint", edpt);
                    cmd.Parameters.AddWithValue("@ClassType", cltp);
                    cmd.Parameters.AddWithValue("@PeopleCount", ptct);
                    cmd.Parameters.AddWithValue("@Datee", DatE);
                    cmd.Parameters.AddWithValue("@Timee", TimE);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            Console.WriteLine("The value will be inserted successfully");
        }

        public static void updateId()
        {
            Console.WriteLine("Enter the id ");
            id = Console.ReadLine();

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("updateidd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BookingId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($" BookingId : {reader["BookingId"]}," +
                                $"StartPoint : {reader["StartPoint"]}," +
                                $"EndPoint : {reader["EndingPoint"]}," +
                                $"ClassType : {reader["ClassType"]}," +
                                $"PeopleCount : {reader["PeopleCount"]}," +
                                $"Date : {reader["Datee"]}," +
                                $"Time : {reader["Timee"]},");

                        }
                    }

                }
            }

        }

        public static void update()
        {
            updateId();
            Console.WriteLine("Enter the details for update");
            inpt();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("updatepro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingId", id);
                    cmd.Parameters.AddWithValue("@StartPoint", stpt);
                    cmd.Parameters.AddWithValue("@EndingPoint", edpt);
                    cmd.Parameters.AddWithValue("@ClassType", cltp);
                    cmd.Parameters.AddWithValue("@PeopleCount", ptct);
                    cmd.Parameters.AddWithValue("@Datee", DatE);
                    cmd.Parameters.AddWithValue("@Timee", TimE);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Update statement can be done successfully");

                }
            }


        }

        public static void delete()
        {
            updateId();
            Console.WriteLine("Are you sure want to delete ticket(Y/N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if(choice == 'Y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("deletepro", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookingId", id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            else
            {
                Console.WriteLine("Property not deleted");
            }


        }
    }
}
