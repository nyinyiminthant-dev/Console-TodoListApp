


using System.Security.Cryptography;
using Console_TodoListApp.EfcoreExamples;

Console.WriteLine(value: "Welcome To Console Todo-list App");
Console.WriteLine();

EfcoreExample efcore = new EfcoreExample();

int count, lcount;

 count = 1;
 lcount = 1;

while (count is 1 ||count > 1)
{
    #region Whole App

    Console.Write("Register (r), ");


    Console.Write("Login (l), ");
    Console.WriteLine();


    Console.WriteLine("____________________________________________");


    string start = Console.ReadLine()!;



    #region Registration 

    if (start is "r" || start is "R")
    {
        Console.WriteLine("Registration Account.");
        Console.WriteLine("__________________________");
        Console.WriteLine();
        Console.WriteLine("Please Set Your Email");
        Console.WriteLine();
        string email = Console.ReadLine()!;
        Console.WriteLine();

        Console.WriteLine("Please Set Your Password");
        Console.WriteLine();
        string password = Console.ReadLine()!;
        Console.WriteLine();

        efcore.CreateUser(email, password);

    }

    #endregion

    #region Login




    if (start is "l" || start is "L")
    {
        Console.WriteLine("Login");
        Console.WriteLine("____________________");
        Console.WriteLine();

        Console.WriteLine("Please Enter Your Email.");
        Console.WriteLine();
        string email = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("Please Enter Your Password");
        Console.WriteLine();
        string password = Console.ReadLine()!;
        Console.WriteLine();

        efcore.LoginUser(email, password);


       

        while (lcount is 1 || lcount > 1)
        {

            Console.WriteLine("Add the Task : (nt) || Done : (dt) || exit : (e)");

            string task = Console.ReadLine()!;
            Console.WriteLine();

            if (task is "nt")
            {
                Console.WriteLine("Please enter your task");
                string title = Console.ReadLine()!;
                Console.WriteLine();
                efcore.WriteTask(email, title);
                efcore.ReadTask(email);
                lcount++;
                
            }
            if (task is "dt")
            {
                Console.WriteLine("Please enter the title that you have done.");
                string title = Console.ReadLine()!;
                Console.WriteLine();
                efcore.DeleteTask(email, title);
                efcore.ReadTask(email);
                lcount++;
               
            }
            if (task is "e")
            {
                Console.WriteLine("_____________________");
                Console.WriteLine();
                lcount = 0;
               
            }
            else
            {
                Console.WriteLine();
                lcount++;
            }
            
           
        }




    }

    Console.WriteLine("Do you want to start again? (y) or (n)");
    string round = Console.ReadLine()!;
    Console.WriteLine();

    if (round is "Y" || round is "y")
    {
        count++;
        lcount++;
        Console.WriteLine("Welcome To Console Todo-list App again.");
        Console.WriteLine();
    }
    else if (round is "N" || round is "n")
    {
        Console.WriteLine("Thank For Using");
        count = 0;
    }
    #endregion

    #endregion

}


Console.ReadLine();