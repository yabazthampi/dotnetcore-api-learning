using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOB_CRUD.Models
{
    public class JobDetail
    {

    

        [Column(TypeName ="nvarchar(100)")]
        public string JobTitle { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmploymentType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Department { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Key]
        public int JobId { get; set; }

    }
}
