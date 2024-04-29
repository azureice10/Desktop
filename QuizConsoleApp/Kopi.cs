
namespace QuizConsoleApp
{
    internal class Kopi(string nama, double harga, int stok)
    {
        // Atribut-atribut kopi
        public string Nama { get; set; } = nama;
        public double Harga { get; set; } = harga;
        public int Stok { get; set; } = stok;

        // Metode untuk menampilkan informasi kopi
        public void TampilkanInfo()
        {
            Console.WriteLine("Nama Kopi: " + Nama);
            Console.WriteLine("Harga: " + Harga);
            Console.WriteLine("Stok: " + Stok);
        }
    }
}

