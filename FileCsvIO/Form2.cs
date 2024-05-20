using CsvHelper;
using QRCoder;
using System.Data;
using System.Globalization;

namespace FileCsvIO
{
    public partial class Form2 : Form
    {
        private List<Produk> records;
        private decimal vHarga;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using var reader = new StreamReader("produk.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            records = csv.GetRecords<Produk>().ToList();
            foreach (var record in records)
            {
                if (record.Stok >= 1)
                {
                    comboBox1.Items.Add(record.Nama);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vHarga = records[comboBox1.SelectedIndex].Harga;
            label3.Text = vHarga.ToString();
            GetHarga();
            numericUpDown1.Maximum = records[comboBox1.SelectedIndex].Stok;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetHarga();
        }

        private void GetHarga()
        {
            decimal vTotal = numericUpDown1.Value * vHarga;
            label5.Text = vTotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Nproduk = comboBox1.Text;
            string myItem = $"{Nproduk} x {numericUpDown1.Value} = Rp.{label5.Text}";
            ListViewItem existingItem = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text.StartsWith(Nproduk + " x"));
            if (existingItem != null)
            {
                DialogResult = MessageBox.Show("Item sudah ada, ingin diganti?", "Duplicate Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    existingItem.Text = myItem;
                }
            }
            else
            {
                ListViewItem listItem = new(myItem);
                listView1.Items.Add(listItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0) 
            { 
            SumPrices();
            GenerateQr(out QRCodeGenerator qrGenerator, out QRCodeData qrCodeData, out PngByteQRCode qrCode, out MemoryStream ms);
            }
            else
            {
                MessageBox.Show("Tambahkan item dahulu!");
            }
        }

        private void GenerateQr(out QRCodeGenerator qrGenerator, out QRCodeData qrCodeData, out PngByteQRCode qrCode, out MemoryStream ms)
        {
            Guid myuuid = Guid.NewGuid();
            string orderId = myuuid.ToString();
            qrGenerator = new();
            qrCodeData = qrGenerator.CreateQrCode(orderId, QRCodeGenerator.ECCLevel.Q);
            qrCode = new(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);
            ms = new(qrCodeImage);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void SumPrices()
        {
            decimal totalSum = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                string itemText = item.Text;
                string[] parts = itemText.Split(new string[] { " x ", " = Rp." }, StringSplitOptions.None);

                if (parts.Length == 3)
                {
                    string priceText = parts[2];

                    if (decimal.TryParse(priceText, out decimal price))
                    {
                        totalSum += price;
                    }
                }
            }

            MessageBox.Show($"Total harga: Rp.{totalSum}", "Total Harga", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
