using Assigment_PS_Quick.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Db_con
{
    public class DataContexts :DbContext
    {
        public DataContexts(DbContextOptions o) : base(o) { }



        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<EntryData> EntryDatas { get; set; }
        public DbSet<LoginData> Logins { get; set; }

    }


   
    
}
