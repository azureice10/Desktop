using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace FileCsvIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            int vId = Convert.ToInt16(textBox1.Text);
            string vNama = textBox2.Text;
            decimal vHarga = Convert.ToDecimal(textBox3.Text);
            int vStok = (int) numericUpDown1.Value;

            var records = new List<Produk>
                {
                    new() { Id = vId, Nama = vNama, Harga = vHarga, Stok = vStok },
                };

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var stream = File.Open("produk.csv", FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);
            csv.WriteRecords(records);

        }
    }
}
