using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickectBooking
{
    public class Login
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TickectBookingPt;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string uname;
        public static string pswd;
        public static void input()
        {
            Console.WriteLine("Enter a user name");
            uname = Console.ReadLine();
            Console.WriteLine("Enter a user password");
            pswd = Console.ReadLine();

        }
        public static void ShowMenu()
        {

           
            sample.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                sample.Menu();
            }
        }
        public static void valadd()
        {
            input();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("inval", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", uname);
                    cmd.Parameters.AddWithValue("@password", pswd);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Registration Successfull");
                    ShowMenu();
                }
            }

        }
       
        public static void dtcheck()
        {
            input();
            using (var con = new SqlConnection(connectionString))
            {
                
                using (var cmd = new SqlCommand("select dbo.func(@us,@pas)", con))
                {
                    
                    cmd.Parameters.AddWithValue("@us", uname);
                    cmd.Parameters.AddWithValue("@pas", pswd);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        Console.WriteLine("Welcome" + " " + uname);
                        ShowMenu();
                    }
                    else
                    {
                        Console.WriteLine("Your Profile is not available");
                        Console.WriteLine("Make Choice \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                valadd();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;

                        }
                    }


                }

            }

        }

    }
}
