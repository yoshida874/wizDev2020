using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wizDev2020.Models
{
    public class HistricMonumentModel
    {
        [Key]
        public int Id { get; set; }
        public string monument_name { get; set; }
        public string monument_information { get; set; }
        public decimal monument_longitude { get; set; }
        public decimal monument_latitude { get; set; }
    }
}
