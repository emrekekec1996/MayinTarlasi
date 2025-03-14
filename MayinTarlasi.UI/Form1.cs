namespace MayinTarlasi.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<Button, bool> mayinlar = new Dictionary<Button, bool>();
        private int satirSayisi;
        private int sutunSayisi;
        private int mayinOrani = 20; // %20 ihtimalle mayın koyulacak

        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            ButonOlustur();
        }

        private void ButonOlustur()
        {
            // Önceki butonları temizle
            grpMayinlar.Controls.Clear();
            mayinlar.Clear();

            Random rnd = new Random();
            int buttonBoyutu = 30;
            int bosluk = 2;

            // GroupBox'ın başlığı butonları engellemesin diye iç padding ayarlandı
            grpMayinlar.Padding = new Padding(10, 30, 10, 10);

            // Sınırları aşmamak için uygun satır/sütun hesapla
            sutunSayisi = (grpMayinlar.Width - 10) / (buttonBoyutu + bosluk);
            satirSayisi = (grpMayinlar.Height - 40) / (buttonBoyutu + bosluk);

            int toplamGenislik = sutunSayisi * (buttonBoyutu + bosluk) - bosluk;
            int toplamYukseklik = satirSayisi * (buttonBoyutu + bosluk) - bosluk;

            // Başlangıç noktası: Başlığı kapatmaması için aşağı kaydırıldı
            int baslangicX = (grpMayinlar.Width - toplamGenislik) / 2;
            int baslangicY = 30; // **Başlık alanı kadar boşluk bırakıldı**

            int konumX = baslangicX;
            int konumY = baslangicY;

            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    Button button = new Button
                    {
                        Width = buttonBoyutu,
                        Height = buttonBoyutu,
                        Location = new Point(konumX, konumY),
                        BackColor = Color.LightGray,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Tag = new Point(i, j)
                    };

                    button.Click += Button_Click;

                    bool mayinVarMi = rnd.Next(100) < mayinOrani;
                    mayinlar.Add(button, mayinVarMi);

                    grpMayinlar.Controls.Add(button);

                    konumX += buttonBoyutu + bosluk;
                }
                konumX = baslangicX;
                konumY += buttonBoyutu + bosluk;
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is Button tiklananButon)
            {
                if (mayinlar[tiklananButon])
                {
                    tiklananButon.BackColor = Color.Red;
                    tiklananButon.Text = "💣";
                    OyunBitti();
                }
                else
                {
                    int yakinMayinSayisi = MayinSayisiniHesapla(tiklananButon);
                    if (yakinMayinSayisi > 0)
                    {
                        tiklananButon.Text = yakinMayinSayisi.ToString();
                        tiklananButon.BackColor = Color.White;
                    }
                    else
                    {
                        tiklananButon.BackColor = Color.White;
                        tiklananButon.Enabled = false;
                    }
                }
            }
        }

        private int MayinSayisiniHesapla(Button buton)
        {
            Point konum = (Point)buton.Tag;
            int x = konum.X;
            int y = konum.Y;
            int mayinSayisi = 0;

            foreach (var kvp in mayinlar)
            {
                Point butonKonumu = (Point)kvp.Key.Tag;
                if (Math.Abs(butonKonumu.X - x) <= 1 && Math.Abs(butonKonumu.Y - y) <= 1)
                {
                    if (kvp.Value)
                    {
                        mayinSayisi++;
                    }
                }
            }
            return mayinSayisi;
        }

        private void OyunBitti()
        {
            foreach (var kvp in mayinlar)
            {
                if (kvp.Value)
                {
                    kvp.Key.Text = "💣";
                    kvp.Key.BackColor = Color.DarkRed;
                }
                kvp.Key.Enabled = false;
            }
            MessageBox.Show("Oyunu Kaybettiniz!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}