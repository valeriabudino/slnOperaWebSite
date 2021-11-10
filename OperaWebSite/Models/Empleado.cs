using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OperaWebSite.Models
{
    [Table("Empleado")]//EF-->DB
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

    }
}