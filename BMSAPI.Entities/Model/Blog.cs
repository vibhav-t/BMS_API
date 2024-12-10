using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Entities.Model
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
