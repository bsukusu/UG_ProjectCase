using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UGCase.Models
{
    public class musteri
    {

        public int Id { get; set; }
        public string Unvan { get; set; }

        public ICollection<musteriFatura> MusteriFaturalar { get; set; }
    }
}
