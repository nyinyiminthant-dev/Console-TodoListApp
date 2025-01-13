using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_TodoListApp.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Console_TodoListApp.Dtos;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Myconnection._sqlConnectionStringBuilder.ConnectionString);
        }
    }

    public DbSet<UserModel> users { get; set; }
    public DbSet<TaskModel> tasks { get; set; }
}
