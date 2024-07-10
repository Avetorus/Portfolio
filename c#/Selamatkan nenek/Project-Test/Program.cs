using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Test
{
    class Program
    {
        protected void display(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        static void Main(string[] args)
        {
            /*-----------------------------------------------------------------------------------*/
            // Tempat Variabel menampung nilai dalam program tersebut.
            //"ulang1" disini untuk pengulangan ketika user meilih opsi "Y" untuk melanjutkan permainan 
            //Variable Kemenangan untuk menambah poin kemenangan ketika pemain telah membeli obat A dan melanjutkan permainan
            int Kemenangan = 0;
        ulang1:
            string nama;
            int chapter = 0;
            bool exitLoop = false;
            //Harga
            int hargaLily = 50,
                hargaAceta = 10,
                hargaProfen = 8,
                hargaAspirin = 6;
            //Jumlah Item
            int lily = 0,
                aceta = 0,
                profen = 0,
                aspirin = 0;
            //Saldo
            int saldo = 30;

            Program p = new Program();
            /*-----------------------------------------------------------------------------------*/



            /*-----------------------------------------------------------------------------------*/
            //Bagian User Input Nama karakter 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Kemenangan : " + Kemenangan);

        //Input Username Character
        name:
            Console.Title = "Input Username";
            Console.ForegroundColor = ConsoleColor.Cyan;
            p.display(45, 13, "Masukkan Nama Karakter Anda: ");
            nama = Console.ReadLine().ToUpper();
            if (string.IsNullOrWhiteSpace(nama))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                p.display(45, 14, "Nama tidak boleh kosong");
                Console.ReadKey();
                Console.Clear();
                Console.ResetColor();
                goto name;
            }
            Console.Clear();
            Console.ResetColor();
        /*-----------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------*/
        //"ulang" disini ketika pemain "Game Over" dan melanjutkan permainan dan akan memasuki program loading...
        ulang:
            Console.Title = "Loading...";
            //Loading
            int loading = 1;
            //loading
            for (loading = 1; loading < 10000; loading += 3)
            {
                Random ran = new Random();
                int xRandom = ran.Next(1, 90);
                int yRandom = ran.Next(1, 20);
                p.display(xRandom, yRandom, nama);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                p.display(55, 13, "Good Luck...");
            }
            Console.ReadKey();
            Console.Clear();
            /*-----------------------------------------------------------------------------------*/


            /*-----------------------------------------------------------------------------------*/
            //Dibagian sini ialah ketika User sudah memasuki tahap Introduction
            Console.Title = "Story";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            p.display(55, 13, $"Chapter - {chapter} \n");
            Console.ForegroundColor = ConsoleColor.Green;
            p.display(45, 15, "Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("to Start ................");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            //Story
            p.display(20, 10, $"\tPada suatu hari, di sebuah desa kecil yang damai. Seorang anak muda bernama {nama} ");
            p.display(20, 11, $"sedang sibuk membantu neneknya yang sedang sakit dan terbaring lemah karena demam tinggi.");
            p.display(20, 12, $"{nama} sangat khawatir dan tahu bahwa nenek membutuhkan obat segera untuk meredakan demamnya.");
            p.display(20, 13, $"Tetapi koin yang dimiliki tidak cukup untuk menyembuhkan penyakit nenek, namun {nama} segera");
            p.display(20, 14, $"bergegas membawa {saldo} koin yang tersisa untuk membeli obat apapun dan berspekulasi obat");
            p.display(20, 15, $"tesebut akan membantu meredakan penyakit nenek.");
            p.display(20, 16, $"\tSetibanya di Apotek Pak Jojo, {nama} memberitahu pada Pak Jojo bahwasannya dia sedang");
            p.display(20, 17, $"mencari obat untuk menyembuhkan neneknya yang sedang terkena demam tinggi, lalu Pak Jojo");
            p.display(20, 18, $"memperlihatkan list obat yang tersedia yang masing-masing obat tersebut memiliki tingkat");
            p.display(20, 19, $"penyembuhan yang berbeda. Semakin tinggi tingkat penyembuhannya, semakin mahal juga harganya.");
            Console.ForegroundColor = ConsoleColor.Green;
            p.display(20, 21, $"Tekan Apapun untuk melihat list item ...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        /*-----------------------------------------------------------------------------------*/



        /*-----------------------------------------------------------------------------------*/
        //Dibagian ini memsasuki Apotek Pak Jojo dan user bisa membeli dan melihat informasi item 
        shop:
            Console.Title = "Apotek Pak Jojo";
            //Informasi
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Informasi: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A -> 100 HP");
            Console.WriteLine("B -> +30 HP");
            Console.WriteLine("C -> +20 HP");
            Console.WriteLine("D -> +10 HP");
            p.display(45, 10, "Apotek Pak Jojo");
            Console.ForegroundColor = ConsoleColor.Yellow;
            p.display(45, 11, "Saldo anda : ");
            Console.ForegroundColor = ConsoleColor.Red;
            p.display(58, 11, $"{saldo} koin");
            Console.ResetColor();
            p.display(45, 12, $"A. Lily ({hargaLily} koin)");
            p.display(45, 13, $"B. Aceta ({hargaAceta} koin)");
            p.display(45, 14, $"C. Profen ({hargaProfen} koin)");
            p.display(45, 15, $"D. Aspirin ({hargaAspirin} koin)");
            /*-----------------------------------------------------------------------------------*/



            /*-----------------------------------------------------------------------------------*/
            //Dibagian ini user ditanya apakah user masih tertarik untuk membelinya
            p.display(45, 17, $"Apakah kamu masih ingin membelinya? [Y/N] ");
            string yn = Console.ReadLine().ToUpper();
            //Opsi Membeli Item
            if (yn == "Y")
            {
                //Disini ketika user menekan "Y" maka akan diberikan berbagai pilihan item yang akan dibeli 
                //Hingga melakukan pengecekan apakah user memiliki koin yang cukup untuk membelinya
                //Jika tidak cukup maka akan menampilkan hasil "saldo anda tidak mencukupi".
                //Terkhusus pada Opsi A jika user dapat membelinya, maka user akan mendapatkan 1 poin kemenangan, yang merupakan ending dari game tersebut.
                p.display(45, 18, $"Mau ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Beli ");
                Console.ResetColor();
                Console.Write("Apa? [A/B/C/D]: ");
                string pilih = Console.ReadLine();
                Console.Clear();
                if (pilih.ToLower() == "a")//Opsi A................................................................................
                {
                    Console.Clear();
                    if ((saldo - hargaLily) >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        p.display(45, 13, "Terima kasih sudah membeli Lily");
                        saldo -= 50;
                        lily++;
                        Console.Title = "The End";
                        //loading
                        for (loading = 1; loading < 10000; loading += 3)
                        {
                            Random ran = new Random();
                            int xRandom = ran.Next(1, 90);
                            int yRandom = ran.Next(1, 20);
                            p.display(xRandom, yRandom, nama);
                            Console.Clear();
                        }
                        while (!exitLoop)
                        {
                            Console.Title = "The End";
                            Console.ForegroundColor = ConsoleColor.Green;
                            p.display(40, 16, "Kamu telah menyembuhkan Nenek");
                            p.display(40, 18, "Apakah masih ingin bermain lagi? [Y/N]: ");
                            string lanjut = Console.ReadLine().ToUpper();
                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya 
                            {
                                chapter++;
                                Kemenangan++;
                                Console.Clear();
                                Console.ResetColor();
                                goto ulang1;
                            }
                            else if (lanjut == "n")
                            {
                                exitLoop = true;
                            }
                            else if (string.IsNullOrWhiteSpace(lanjut))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh kosong");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(55, 13, "Sudah Yakin?");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        p.display(45, 13, "Saldo anda tidak mencukupi");
                        Console.ReadKey();
                    }
                }
                else if (pilih.ToLower() == "b")//Opsi B.........................................................................
                {
                    if ((saldo - hargaAceta >= 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        p.display(45, 13, "Terima kasih sudah membeli Aceta");
                        saldo -= 10;
                        aceta++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        p.display(45, 13, "Saldo anda tidak mencukupi");
                        Console.ReadKey();
                    }
                }
                else if (pilih.ToLower() == "c")//Opsi C...............................................................................
                {
                    if ((saldo - hargaProfen >= 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        p.display(45, 13, "Terima kasih sudah membeli Profen");
                        saldo -= 6;
                        profen++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        p.display(45, 13, "Saldo anda tidak mencukupi");
                        Console.ReadKey();
                    }
                }
                else if (pilih.ToLower() == "d")//Opsi D..................................................................................
                {
                    if ((saldo - hargaAspirin >= 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        p.display(45, 13, "Terima kasih sudah membeli Aspirin");
                        saldo -= 8;
                        aspirin++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        p.display(45, 13, "Saldo anda tidak mencukupi");
                        Console.ReadKey();
                    }
                }
                else if (string.IsNullOrWhiteSpace(pilih))//Opsi Kosong
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    p.display(45, 13, "Inputan tidak boleh kosong");
                    Console.ReadKey();
                    Console.Clear();
                    goto shop;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    p.display(40, 13, "Inputan harus [A/B/C/D], Silahkan Input ulang!!");
                    Console.ReadKey();
                    Console.Clear();
                    goto shop;
                }
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                goto shop;
            }
            /*-----------------------------------------------------------------------------------*/



            /*-----------------------------------------------------------------------------------*/
            //Masih dibagian yang tadi ketika user ditanya apakah user masih tertarik untuk membelinya
            //Ketika user memilih "N", maka user langsung diarahkan ke bagian challange
            else if (yn == "N")
            {
                //Disini ketika user diberi pilihan yaitu:
                //1. Melawan dengan suwit
                //2. Dibunuh
                Console.Clear();
            ot:
                Console.Title = "Story";
                p.display(15, 10, $"\tDikarenakan rasa cemas {nama} pada neneknya yang sedang sakit parah, Ia pun segera bergegas");
                p.display(15, 11, $"pulang. Namun saat sedang di tengah perjalanan pulang, {nama} diberhentikan oleh seorang preman yang ingin");
                p.display(15, 12, $"mencuri sisa koin yang dimilikinya. Preman itu memberi peringatan kalau {nama} tidak");
                p.display(15, 13, $"memberinya koin yang dimiliki oleh {nama}, maka dia akan membunuhnya.");
                p.display(15, 14, $"Tetapi Preman tersebut memberikan {nama} 2 opsi yaitu: ");
                Console.ForegroundColor = ConsoleColor.Red;
                p.display(15, 16, $"1. Melawan dengan Suwit");
                p.display(15, 17, $"2. Dibunuh");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                p.display(15, 20, $":) Pilihlah diantara pilihan 1 atau 2 : ");
                string ot = Console.ReadLine();
                int otNumber;
                bool otBool = int.TryParse(ot, out otNumber);

                //Disini ketika user memilih 1 yaitu melawan dengan suwit
                if (otNumber == 1)
                {
                    //disini merupakan program yang memanfaatkan statement Random built in untuk mengacak pilihan preman
                    Console.Clear();
                    Random random = new Random();
                    string pemain, preman;
                    int hpPemain = 100, hpPreman = 100;
                    // HP Item
                    int hpLily = 100,
                        hpAceta = 30,
                        hpProfen = 20,
                        hpAspirin = 10;
                suwit:
                obat:
                    if (hpPreman > 0 && hpPemain > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"HP Pemain : {hpPemain}\n\n");
                        p.display(107, 0, "HP Preman ");
                        Console.Write($"{hpPreman}");
                        pemain = "";
                        preman = "";
                        Console.ResetColor();

                        //Disini untuk mengecek kalau salah satu item >= 1, maka akan diberi pilihan ingin memakai obat atau tidak
                        //kalau sama sekali tidak ada item, maka akan lompat ke bagian battle suwit
                        if (lily >= 1 || aceta >= 1 || profen >= 1 || aspirin >= 1)
                        {
                            /*-----------------------------------------------------------------------------------*/
                            //Dsini ketika user diberi pilihan untuk memakai obat atau tidak
                            Console.ForegroundColor = ConsoleColor.Red;
                            p.display(0, 1, "Informasi: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            p.display(0, 2, $"A ({lily})-> 100 HP");
                            p.display(0, 3, $"B ({aceta})-> +30 HP");
                            p.display(0, 4, $"C ({profen})-> +20 HP");
                            p.display(0, 5, $"D ({aspirin})-> +10 HP");
                            p.display(40, 10, "Apakah ingin memakai obatnya?[Y/N]: ");
                            string obat = Console.ReadLine().ToUpper();
                            if (obat == "Y")
                            {
                                p.display(40, 11, "Silahkan pilih [A/B/C/D]: ");
                                string pilihObat = Console.ReadLine().ToUpper();
                                if (pilihObat == "A" && lily >= 1)//Opsi pilih obat A dan obat >= 1, maka HP bertambah................................................
                                {
                                    hpPemain += hpLily;
                                    lily--;
                                    //dibagian ini ketika pemain melebihi batas maksimum akan overdosis
                                    if (hpPemain >= 100)
                                    {
                                        Console.Clear();
                                        Console.Title = "Overdosis";
                                        //loading
                                        for (loading = 1; loading < 10000; loading += 3)
                                        {
                                            Random ran = new Random();
                                            int xRandom = ran.Next(1, 90);
                                            int yRandom = ran.Next(1, 20);
                                            p.display(xRandom, yRandom, nama);
                                            Console.Clear();
                                            loading += 2;
                                        }
                                        while (!exitLoop)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            p.display(55, 13, "Game Over");
                                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                                            string lanjut = Console.ReadLine().ToUpper();
                                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                                            {
                                                chapter++;
                                                Console.Clear();
                                                Console.ResetColor();
                                                goto ulang;
                                            }
                                            else if (lanjut == "N")//keluar dari program
                                            {
                                                exitLoop = true;
                                            }
                                            else if (string.IsNullOrWhiteSpace(lanjut))
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh kosong");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                        }
                                        Environment.Exit(0);
                                    }
                                }
                                else if (pilihObat == "A" && lily <= 0)//Opsi A dan obat <= 0, maka tidak memiliki obat................................................
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 10, "Anda tidak memiliki obat tersebut");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                                /*-----------------------------------------------------------------------------------*/



                                /*-----------------------------------------------------------------------------------*/
                                else if (pilihObat == "B" && aceta >= 1)//Opsi B dan obat >= 0, maka HP bertambah................................................
                                {
                                    hpPemain += hpAceta;
                                    aceta--;
                                    //dibagian ini ketika pemain melebihi batas maksimum akan overdosis
                                    if (hpPemain >= 100)
                                    {
                                        Console.Clear();
                                        Console.Title = "Overdosis";
                                        //loading
                                        for (loading = 1; loading < 10000; loading += 3)
                                        {
                                            Random ran = new Random();
                                            int xRandom = ran.Next(1, 90);
                                            int yRandom = ran.Next(1, 20);
                                            p.display(xRandom, yRandom, nama);
                                            Console.Clear();
                                            loading += 2;
                                        }
                                        while (!exitLoop)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            p.display(55, 13, "Game Over");
                                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                                            string lanjut = Console.ReadLine().ToUpper();
                                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                                            {
                                                chapter++;
                                                Console.Clear();
                                                Console.ResetColor();
                                                goto ulang;
                                            }
                                            else if (lanjut == "N")//keluar dari program
                                            {
                                                exitLoop = true;
                                            }
                                            else if (string.IsNullOrWhiteSpace(lanjut))
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh kosong");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                        }
                                        Environment.Exit(0);
                                    }
                                }
                                else if (pilihObat == "B" && aceta <= 0)//Opsi B dan obat <= 0, maka tidak meiliki obat................................................
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 10, "Anda tidak memiliki obat tersebut");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                                /*-----------------------------------------------------------------------------------*/



                                /*-----------------------------------------------------------------------------------*/
                                else if (pilihObat == "C" && profen >= 1)//Opsi C dan obat >= 0, maka HP bertambah................................................
                                {
                                    hpPemain += hpProfen;
                                    profen--;
                                    //dibagian ini ketika pemain melebihi batas maksimum akan overdosis
                                    if (hpPemain >= 100)
                                    {
                                        Console.Clear();
                                        Console.Title = "Overdosis";
                                        //loading
                                        for (loading = 1; loading < 10000; loading += 3)
                                        {
                                            Random ran = new Random();
                                            int xRandom = ran.Next(1, 90);
                                            int yRandom = ran.Next(1, 20);
                                            p.display(xRandom, yRandom, nama);
                                            Console.Clear();
                                            loading += 2;
                                        }
                                        while (!exitLoop)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            p.display(55, 13, "Game Over");
                                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                                            string lanjut = Console.ReadLine().ToUpper();
                                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                                            {
                                                chapter++;
                                                Console.Clear();
                                                Console.ResetColor();
                                                goto ulang;
                                            }
                                            else if (lanjut == "N")//keluar dari program
                                            {
                                                exitLoop = true;
                                            }
                                            else if (string.IsNullOrWhiteSpace(lanjut))
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh kosong");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                        }
                                        Environment.Exit(0);
                                    }
                                }
                                else if (pilihObat == "C" && profen <= 0)//Opsi C dan obat <= 0, maka tidak memiliki obat................................................
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 10, "Anda tidak memiliki obat tersebut");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                                /*-----------------------------------------------------------------------------------*/



                                /*-----------------------------------------------------------------------------------*/
                                else if (pilihObat == "D" && aspirin >= 1)//Opsi D dan obat >= 0, maka HP bertambah................................................
                                {
                                    hpPemain += hpAspirin;
                                    aspirin--;
                                    //dibagian ini ketika pemain melebihi batas maksimum akan overdosis
                                    if (hpPemain >= 100)
                                    {
                                        Console.Clear();
                                        Console.Title = "Overdosis";
                                        //loading
                                        for (loading = 1; loading < 10000; loading += 3)
                                        {
                                            Random ran = new Random();
                                            int xRandom = ran.Next(1, 90);
                                            int yRandom = ran.Next(1, 20);
                                            p.display(xRandom, yRandom, nama);
                                            Console.Clear();
                                            loading += 2;
                                        }
                                        while (!exitLoop)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            p.display(55, 13, "Game Over");
                                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                                            string lanjut = Console.ReadLine().ToUpper();
                                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                                            {
                                                chapter++;
                                                Console.Clear();
                                                Console.ResetColor();
                                                goto ulang;
                                            }
                                            else if (lanjut == "N")//keluar dari program
                                            {
                                                exitLoop = true;
                                            }
                                            else if (string.IsNullOrWhiteSpace(lanjut))
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh kosong");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                        }
                                        Environment.Exit(0);
                                    }
                                }
                                else if (pilihObat == "D" && aspirin <= 0)//Opsi D dan obat <= 0, maka tidak memiliki obat................................................
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 10, "Anda tidak memiliki obat tersebut");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                                /*-----------------------------------------------------------------------------------*/



                                /*-----------------------------------------------------------------------------------*/
                                else if (string.IsNullOrWhiteSpace(pilihObat))
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(45, 13, "Inputan tidak boleh kosong");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(45, 13, "Inputan tidak boleh yang lain");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.ResetColor();
                                    goto obat;
                                }
                            }
                            else if (obat == "N")
                            {
                                //Disini akan lompat ke bagian battle suwit
                            }
                            else if (string.IsNullOrWhiteSpace(obat))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 10, "Inputan tidak boleh kosong");
                                Console.ReadKey();
                                Console.Clear();
                                goto obat;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                Console.ReadKey();
                                Console.Clear();
                                Console.ResetColor();
                                goto obat;
                            }
                            /*-----------------------------------------------------------------------------------*/
                        }



                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"HP Pemain : {hpPemain}\n");
                        p.display(107, 0, "HP Preman ");
                        Console.Write($"{hpPreman}");
                        pemain = "";
                        preman = "";
                        Console.ResetColor();
                        p.display(37, 10, "Masukkan BATU, GUNTING, KERTAS : ");
                        pemain = Console.ReadLine().ToUpper();
                        while (pemain != "BATU" && pemain != "GUNTING" && pemain != "KERTAS")
                        {
                            if (string.IsNullOrWhiteSpace(pemain))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(44, 12, "Senjata kamu tidak boleh kosong!!");
                                Console.ReadKey();
                                Console.Clear();
                                Console.ResetColor();
                                goto suwit;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            p.display(44, 12, "Senjata kamu tidak boleh yang lain!!");
                            Console.ReadKey();
                            Console.Clear();
                            Console.ResetColor();
                            goto suwit;
                        }
                        switch (random.Next(1, 4))
                        {
                            case 1:
                                preman = "BATU";
                                break;
                            case 2:
                                preman = "GUNTING";
                                break;
                            case 3:
                                preman = "KERTAS";
                                break;
                        }

                        p.display(40, 12, "Kamu :" + pemain);
                        p.display(40, 13, "Preman: " + preman);
                        switch (pemain)
                        {
                            case "BATU":
                                if (preman == "BATU")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    p.display(40, 14, "Hasil Seri!");
                                }
                                else if (preman == "GUNTING")
                                {
                                    p.display(40, 14, "Kamu Menang!");
                                    saldo += 2;
                                    hpPreman -= 15;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    p.display(40, 15, "Kamu Mendapatkan 2 koin");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 16, "Saldo Kamu menjadi " + saldo);
                                }
                                else if (preman == "KERTAS")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 14, "Kamu Kalah!");
                                    hpPemain -= 15;
                                }
                                Console.ReadKey();
                                Console.ResetColor();
                                Console.Clear();
                                goto suwit;
                            case "KERTAS":
                                if (preman == "BATU")
                                {
                                    p.display(40, 14, "Kamu Menang!");
                                    saldo += 2;
                                    hpPreman -= 15;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    p.display(40, 15, "Kamu Mendapatkan 2 koin");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 16, "Saldo Kamu menjadi " + saldo);
                                }
                                else if (preman == "GUNTING")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 14, "Kamu Kalah!");
                                    hpPemain -= 15;
                                }
                                else if (preman == "KERTAS")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    p.display(40, 14, "Hasil Seri!");
                                }
                                Console.ReadKey();
                                Console.ResetColor();
                                Console.Clear();
                                goto suwit;
                            case "GUNTING":
                                if (preman == "BATU")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 14, "Kamu Kalah!");
                                    hpPemain -= 15;
                                }
                                else if (preman == "GUNTING")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    p.display(40, 14, "Hasil Seri!");
                                }
                                else if (preman == "KERTAS")
                                {
                                    p.display(40, 14, "Kamu Menang!");
                                    saldo += 2;
                                    hpPreman -= 15;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    p.display(40, 15, "Kamu Mendapatkan 2 koin");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    p.display(40, 16, "Saldo Kamu menjadi " + saldo);
                                }
                                Console.ReadKey();
                                Console.ResetColor();
                                Console.Clear();
                                goto suwit;
                        }
                    }
                    Console.Clear();
                    //Disini ketika penmain kalah dari preman 
                    if (hpPemain <= 0)
                    {
                        Console.Title = "Game Over";
                        //loading
                        for (loading = 1; loading < 10000; loading += 3)
                        {
                            Random ran = new Random();
                            int xRandom = ran.Next(1, 90);
                            int yRandom = ran.Next(1, 20);
                            p.display(xRandom, yRandom, nama);
                            Console.Clear();
                            loading += 2;
                        }
                        while (!exitLoop)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            p.display(55, 13, "Game Over");
                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                            string lanjut = Console.ReadLine().ToUpper();
                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                            {
                                chapter++;
                                Console.Clear();
                                Console.ResetColor();
                                goto ulang;
                            }
                            else if (lanjut == "N")//Keluar dari program
                            {
                                do
                                {
                                    bool exitCek = exitLoop == false ? exitLoop = true : false;
                                } while (exitLoop != true);
                            }
                            else if (string.IsNullOrWhiteSpace(lanjut))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh kosong");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        Environment.Exit(0);
                    }
                    //Disini ketika pemain menang dari preman 
                    else if (hpPreman <= 0)
                    {
                        Console.Title = "Champion";
                        //loading
                        for (loading = 1; loading < 10000; loading += 3)
                        {
                            Random ran = new Random();
                            int xRandom = ran.Next(1, 90);
                            int yRandom = ran.Next(1, 20);
                            p.display(xRandom, yRandom, nama);
                            Console.Clear();
                            loading += 2;
                        }
                        while (!exitLoop)
                        {
                            Console.Title = "Champion";
                            Console.ForegroundColor = ConsoleColor.Green;
                            p.display(55, 13, "Champion");
                            p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                            string lanjut = Console.ReadLine().ToUpper();
                            if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi tidak bertambah poin kemenangan, point kemenangan bertambah kalau obat A telah dibeli
                            {
                                chapter++;
                                Console.Clear();
                                Console.ResetColor();
                                goto ulang;
                            }
                            else if (lanjut == "N")//Keluar dari program
                            {
                                do
                                {
                                    bool exitCek = exitLoop == false ? exitLoop = true : false;
                                } while (exitLoop != true);
                            }
                            else if (string.IsNullOrWhiteSpace(lanjut))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh kosong");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                p.display(45, 13, "Inputan tidak boleh yang lain");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        Environment.Exit(0);
                    }
                }
                /*-----------------------------------------------------------------------------------*/



                /*-----------------------------------------------------------------------------------*/
                //Disini ketika user memilih opsi 2 yaitu dibunuh 
                else if (otNumber == 2)
                {
                    Console.Clear();
                    Console.Title = "Game Over";
                    //loading
                    for (loading = 1; loading < 10000; loading += 3)
                    {
                        Random ran = new Random();
                        int xRandom = ran.Next(1, 90);
                        int yRandom = ran.Next(1, 20);
                        p.display(xRandom, yRandom, nama);
                        Console.Clear();
                        loading += 2;
                    }
                    while (!exitLoop)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        p.display(55, 13, "Game Over");
                        p.display(40, 18, "Apakah masih ingin melanjutkannya? [Y/N]: ");
                        string lanjut = Console.ReadLine().ToUpper();
                        if (lanjut == "Y")//Lanjut ke Chapter berikutnya, tapi poin kemenangan tidak bertambah 
                        {
                            chapter++;
                            Console.Clear();
                            Console.ResetColor();
                            goto ulang;
                        }
                        else if (lanjut == "N")//keluar dari program
                        {
                            do
                            {
                                bool exitCek = exitLoop == false ? exitLoop = true : false;       
                            } while (exitLoop != true);  
                        }
                        else if (string.IsNullOrWhiteSpace(lanjut))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            p.display(45, 13, "Inputan tidak boleh kosong");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            p.display(45, 13, "Inputan tidak boleh yang lain");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    Environment.Exit(0);
                }
                else if (string.IsNullOrWhiteSpace(ot))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    p.display(45, 13, "Inputan tidak boleh kosong");
                    Console.ReadKey();
                    Console.Clear();
                    Console.ResetColor();
                    goto ot;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    p.display(45, 13, "Inputan tidak boleh yang lain");
                    Console.ReadKey();
                    Console.Clear();
                    Console.ResetColor();
                    goto ot;
                }
            }
            /*-----------------------------------------------------------------------------------*/



            /*-----------------------------------------------------------------------------------*/
            //Dibagian ini user ditanya apakah user masih tertarik untuk membelinya
            //dibagian ini ketika user input kosong
            else if (string.IsNullOrWhiteSpace(yn))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                p.display(45, 13, "Inputan tidak boleh kosong");
                Console.ReadKey();
                Console.Clear();
                goto shop;
            }
            //dibagian ini ketika user input yang lain
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                p.display(45, 13, "Inputan tidak boleh yang lain.");
                Console.ReadKey();
                Console.Clear();
                goto shop;
            }
            /*-----------------------------------------------------------------------------------*/
        }
    }
}
