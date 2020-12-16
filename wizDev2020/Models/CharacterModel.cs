using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wizDev2020.Models
{
    public class CharacterModel
    {
        [Key]
        public int Id { get; set; }
        public string character_name { get; set; }
    }
}
