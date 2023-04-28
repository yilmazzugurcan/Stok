using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok.ORM
{
    public class Stok
    {
        public int StokID { get; set; }
        public string StokModeli { get; set; }
        public int StokSeriNo { get; set; }
        public int StokAdedi { get; set; }
        public DateTime StokTarih { get; set; }
        public string KayitYapan { get; set; }
    }
}
