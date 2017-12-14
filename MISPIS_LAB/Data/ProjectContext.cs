using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISPIS_LAB.Models;

namespace MISPIS_LAB.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Main> Mains { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}