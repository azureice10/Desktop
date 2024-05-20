using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCsvIO
{
    internal class Produk
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;

        public decimal Harga { get; set; }

        public int Stok { get; set; }


    }
}
