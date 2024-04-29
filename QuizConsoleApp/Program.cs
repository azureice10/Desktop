using QuizConsoleApp;

List<User> users =
        [
            new("john_doe", "password", 1),
            new("jane_smith", "test", 2),
            new("admin", "1234", 3)
        ];

List<Kopi> daftarKopi =
[
            new Kopi("Arabica", 15000, 10),
            new Kopi("Robusta", 12000, 15),
            new Kopi("Luwak", 50000, 5),
            new Kopi("Espresso", 20000, 12)
        ];

// Meminta input dari pengguna untuk username dan password
Console.Write("Username: ");
string usernameInput = Console.ReadLine();
Console.Write("Password: ");
string passwordInput = Console.ReadLine();

// Mencari user yang sesuai dengan input menggunakan LINQ
User loginUser = users.FirstOrDefault(user => user.Username == usernameInput && user.Password == passwordInput);

// Memeriksa apakah user ditemukan dan menampilkan informasi jika ditemukan
if (loginUser != null)
{
    Console.WriteLine("Login berhasil!");

    // Jika user adalah admin, maka beri opsi untuk menambahkan item kopi baru
    if (loginUser.Level == 3)
    {
        UrutkanKopiBerdasarkanStok(daftarKopi);
        TambahItemKopi();
    }
    else
    {
        UrutkanKopiBerdasarkanStok(daftarKopi);
        Console.Write("\nCari Kopi Berdasarkan Nama (Kosongkan untuk melewati): ");
        string namaKopi = Console.ReadLine();
        Console.Write("Rentang Harga (Minimum): ");
        double minHarga;
        while (!double.TryParse(Console.ReadLine(), out minHarga))
        {
            Console.WriteLine("Masukkan harga yang valid.");
            Console.Write("Rentang Harga (Minimum): ");
        }
        Console.Write("Rentang Harga (Maksimum): ");
        double maxHarga;
        while (!double.TryParse(Console.ReadLine(), out maxHarga))
        {
            Console.WriteLine("Masukkan harga yang valid.");
            Console.Write("Rentang Harga (Maksimum): ");
        }

        // Menampilkan hasil pencarian
        CariKopi(daftarKopi, namaKopi, minHarga, maxHarga);
    }
}
else
{
    Console.WriteLine("Login gagal. Username atau password salah.");
}

static void TambahItemKopi()
{
    Console.WriteLine("\nTambahkan item kopi baru:");
    Console.Write("Nama Kopi: ");
    string namaKopi = Console.ReadLine();
    Console.Write("Harga: ");
    double hargaKopi;
    while (!double.TryParse(Console.ReadLine(), out hargaKopi))
    {
        Console.WriteLine("Masukkan harga yang valid.");
        Console.Write("Harga: ");
    }
    Console.Write("Jumlah Stok: ");
    int stokKopi;
    while (!int.TryParse(Console.ReadLine(), out stokKopi))
    {
        Console.WriteLine("Masukkan stok yang valid.");
        Console.Write("Stok: ");
    }

    // Membuat objek Kopi baru dan menampilkannya
    Kopi newCoffee = new(namaKopi, hargaKopi, stokKopi);
    Console.WriteLine("\nItem kopi baru berhasil ditambahkan:");
    newCoffee.TampilkanInfo();
}

static void CariKopi(List<Kopi> daftarKopi, string namaKopi, double minHarga, double maxHarga)
{
    // Melakukan pencarian kopi berdasarkan nama dan rentang harga
    var hasilPencarian = daftarKopi.Where(kopi =>
        (string.IsNullOrEmpty(namaKopi) || kopi.Nama.ToLower().Contains(namaKopi.ToLower())) &&
        (kopi.Harga >= minHarga && kopi.Harga <= maxHarga)
    );

    // Menampilkan hasil pencarian
    if (hasilPencarian.Any())
    {
        Console.WriteLine("\nHasil Pencarian:");
        foreach (var kopi in hasilPencarian)
        {
            kopi.TampilkanInfo();
        }
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\nTidak ditemukan kopi sesuai kriteria pencarian.");
    }
}

static void UrutkanKopiBerdasarkanStok(List<Kopi> daftarKopi)
{
    // Mengurutkan daftar kopi berdasarkan jumlah stok secara descending
    var daftarKopiUrutStok = daftarKopi.OrderByDescending(kopi => kopi.Stok).ToList();

    // Menampilkan daftar kopi yang sudah diurutkan
    Console.WriteLine("\nDaftar Kopi yang tersedia Berdasarkan Stok:");
    foreach (var kopi in daftarKopiUrutStok)
    {
        kopi.TampilkanInfo();
    }
}