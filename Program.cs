using TickectBooking;
class sample
{
    public static void Menu()
    {
        Console.WriteLine("Choose Operation You Want To Perform \n 1.Select  \n 2.Insert  \n 3.Update  \n 4.Delete  \n 5.Exit");
        int options = Convert.ToInt32(Console.ReadLine());
     

        switch (options)
        {

            case 1:
                SearchInfo.select();
                break;
            case 2:
                SearchInfo.insertvalue();
                break;
            case 3:
                SearchInfo.update();
                break;
            case 4:
                SearchInfo.delete();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
   
}
public class Program
{
    public static void Main(string[] args)
    {
        //SearchInfo obj = new SearchInfo();  

        //SearchInfo.select();
        //SearchInfo.insertvalue();
        // SearchInfo.updateId();
        //SearchInfo.update();
        //SearchInfo.delete();
        Login.dtcheck();
        //Login.ShowMenu();


       // Login.input();
       // Login.valadd();
       // Login.dtcheck();
        




    }
}