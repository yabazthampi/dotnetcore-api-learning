using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOB_CRUD.Models
{
    public class JobDetailContext : DbContext
    {
        public JobDetailContext(DbContextOptions<JobDetailContext> options) : base(options)
        {


        }

        public DbSet<JobDetail> JobDetails { get; set; }
    }
}
