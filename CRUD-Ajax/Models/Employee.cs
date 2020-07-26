using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_Ajax.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}