using System;

using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace SQLiteApp.Standard
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Note> Notes { get; set;}

        private readonly string _dataBasePath;

        public DatabaseContext(string dataBasePath)
        {
            _dataBasePath = dataBasePath;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dataBasePath}");
        }
    }
}
