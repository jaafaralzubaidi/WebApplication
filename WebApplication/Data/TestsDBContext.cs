using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class TestsDBContext : DbContext
    {
        public DbSet<Test> Test { get; set; }
    }
}