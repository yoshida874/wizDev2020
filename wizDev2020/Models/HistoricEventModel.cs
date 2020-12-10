using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wizDev2020.Models
{
    public class HistoricEventModel
    {
        [Key]
        public int Id { get; set; }
        public string event_name { get; set; }
    }
}
