


using System.Security.Cryptography;
using Console_TodoListApp.EfcoreExamples;

Console.WriteLine(value: "Welcome To Console Todo-list App");

Console.WriteLine();
EfcoreExample efcore = new EfcoreExample();

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

    efcore.CreateUser(email,password);
    Console.WriteLine("____________________");
    Console.WriteLine();

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

        
       
        

        Console.WriteLine("Add the Task   write : (nt) || Done    write : (dt) || exit write : (e)" );
        
       string task = Console.ReadLine()!;   
       Console.WriteLine();

       if(task is "nt")
    {
        Console.WriteLine("Please enter your task");
        string title = Console.ReadLine()!;
        Console.WriteLine();
        efcore.WriteTask(email,title);
    } 
       if(task is "dt")
    {
        Console.WriteLine("Please enter the title that you have done.");
        string title = Console.ReadLine()!;
        Console.WriteLine();
        efcore.DeleteTask(email, title);
    }  if(task is "e")
    {
        Console.WriteLine("Thank For Using");
      
        
    }
    
}
#endregion

Console.ReadLine();