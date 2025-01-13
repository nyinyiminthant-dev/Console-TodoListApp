


using Console_TodoListApp.EfcoreExamples;

Console.WriteLine(value: "Welcome To Console Todo-list App");

Console.WriteLine();
EfcoreExample efcore = new EfcoreExample();
efcore.ReadUser();
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


int login = 1;

while (login == 1 || login > 1)
{

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

    }
}
#endregion

Console.ReadLine();