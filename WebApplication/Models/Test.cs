using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        [StringLength(1)]
        public string Title { get; set; }
        [Required]
        [StringLength(2)]
        public string Author { get; set; }
        [Required]
        [StringLength(7)]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}