using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wizDev2020.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string user_name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string user_password { get; set; }

        public int character_id { get; set; }
    } 
}
