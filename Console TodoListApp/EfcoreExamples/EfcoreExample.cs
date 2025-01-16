using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_TodoListApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Console_TodoListApp.EfcoreExamples;

public class EfcoreExample
{

    private readonly AppDbContext _appDbContext;

    public EfcoreExample()
    {
        _appDbContext = new AppDbContext();
    }



    #region user
    public void CreateUser(string email, string password)
    {
        var item = new UserModel
        {
            email = email,
            password = password
        };
         _appDbContext.users.Add(item);
        int i = _appDbContext.SaveChanges();

        string message = i > 0 ? "Account has successfully created" : "Creating account has failed";

        Console.WriteLine(message);
        Console.WriteLine("_____________________________");
        Console.WriteLine();
    }

    public void ReadUser()
    {
        var item = _appDbContext.users.AsNoTracking().ToList();

        foreach (var user in item)
        {
            Console.WriteLine("UserID => " +user.userid);
            Console.WriteLine("Email => " +user.email);
            Console.WriteLine("Password => " +user.password);
            Console.WriteLine("________________________________");
            Console.WriteLine();
        }
    } 

    public void EditUser(int userid)
    {
        var item = _appDbContext.users.AsNoTracking().FirstOrDefault(x => x.userid == userid);
        if (item is null)
        {
            Console.WriteLine("No User Found With That Id");
            return;
        }

        Console.WriteLine("UserID => " + item.userid);
        Console.WriteLine("Email => " + item.email);
        Console.WriteLine("Password => " + item.password);
        Console.WriteLine("________________________________");
        Console.WriteLine();
    }

    public void UpdateUser (int userid,string email, string password)
    {
        var item = _appDbContext.users.AsNoTracking().FirstOrDefault(x => x.userid == userid);
        if (item is null)
        {
            Console.WriteLine("No User Found With That Id");
            return;
        }

        item.userid = userid;
        item.email = email;
        item.password = password;

        _appDbContext.Entry(item).State = EntityState.Modified;
        int i = _appDbContext.SaveChanges();

        string message = i > 0 ? "Account has successfully updated" : "Updating account has failed";

        Console.WriteLine(message);
        
        Console.WriteLine();

    }

    public void Delete (int userid)
    {
        var item = _appDbContext.users.AsNoTracking().FirstOrDefault(x => x.userid == userid);
        if (item is null)
        {
            Console.WriteLine("No User Found With That Id");
            return;
        }

        _appDbContext.Entry(item).State = EntityState.Deleted;
        int i = _appDbContext.SaveChanges();


        string message = i > 0 ? "Account has successfully updated" : "Updating account has failed";
       

        Console.WriteLine(message);
       
        Console.WriteLine();
    }

   

    public void LoginUser(string email, string password)
    {


        var user = _appDbContext.users.AsNoTracking().FirstOrDefault(x => x.email == email);

        if (user is null)
        {
            Console.WriteLine("Wrong Email. Please try again.");
            return;
        }

        if (user.password != password)
        {
            Console.WriteLine("Wrong Password. Please try again.");
            return;
        }

        if (user is not null)
        {
            Console.WriteLine("Login Successful");
            Console.WriteLine();
            Console.WriteLine("________________________");
            Console.WriteLine();
            Console.WriteLine("Your Todo-lists");
            Console.WriteLine();
            ReadTask(user.email!);

            
            
            
        }


    }

    #endregion

    #region Task

    public void WriteTask (string email,string title)
    {
        var user = _appDbContext.users.AsNoTracking().Any(x => x.email == email);

        if (!user)
        {
            Console.WriteLine("The provided email does not exist. Please check and try again.");
            return;
        }

        var item = new TaskModel {
            title = title,
            email = email,
            DataTime = DateTime.Now 
        };

        _appDbContext.tasks.Add(item);
        int i = _appDbContext.SaveChanges();

        string message = i > 0 ? "You added new Task" : "Adding new Task failed";
        Console.WriteLine(message);
        Console.WriteLine();
        
    }

    public void ReadTask(string email)
    {
        var item = from task in _appDbContext.tasks.AsNoTracking()
                    join user in _appDbContext.users.AsNoTracking()
                    on task.email equals user.email
                    where user.email == email
                    select new
                    {
                        TaskTitle = task.title,
                        TaskDateTime = task.DataTime,
                        UserEmail = user.email
                    };

        if (!item.Any())
        {
            Console.WriteLine("No tasks found for the given email.");
            return;
        }

        int count = 1;
        foreach (var task in item)
        {

            Console.WriteLine($"Task ({count}) => {task.TaskTitle} || {task.TaskDateTime}");
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________________");
            count++;
        }
    }
    public void DeleteTask(string email, string title)
    {
        var item = (from task in _appDbContext.tasks.AsNoTracking()
                    join user in _appDbContext.users.AsNoTracking()
                    on task.email equals user.email
                    where task.title == title && user.email == email
                    select task).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No task found with the provided title for this email.");
            return;
        }

        _appDbContext.tasks.Remove(item);
        int i = _appDbContext.SaveChanges();

        string message = i > 0 ? "Task is done " : "Done the task failed";
        Console.WriteLine(message);
        Console.WriteLine();
    }

    #endregion
}
