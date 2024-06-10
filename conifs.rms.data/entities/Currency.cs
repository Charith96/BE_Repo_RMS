using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }

        public string CurrencyName { get; set; } = "";
    }
}
