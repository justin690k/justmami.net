using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace justmami.Infrastructure;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=C:\\Users\\MSBR\\source\\repos\\justmami.net\\justmami.Infrastructure\\userDatabase.db";

        optionsBuilder.UseSqlite(connectionString);
    }
}
