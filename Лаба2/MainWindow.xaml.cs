using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Лаба2.Kontroller;
using Лаба2.Model;

namespace Лаба2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*string products;
            string[] aaa = new string[4];
            FileStream rukzak = new FileStream("C:/Users/Пользователь/Desktop/Продукты.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(rukzak);
            List<string> spisok = new List<string>();
            Menu.ItemsSource = spisok;
            while (!reader.EndOfStream)
            {
                products = Convert.ToString(reader.ReadLine());
                aaa = products.Split(':');
                Console.WriteLine(aaa[1]);
                spisok.Add(reader.ReadLine());
            }
            reader.Close();
            rukzak.Close();
            Console.WriteLine("Введите сумму для покупки: ");*/
        }
        int[] polesnost;
        int[] сena;
        public List<Elemente> Pokupki = new List<Elemente>();
        public List<int> PolezniePokupki = new List<int>();
        public List<string> PokupkiK = new List<string>();
        public List<Elemente> KategPok = new List<Elemente>();
        public List<int> BestPokupkiK = new List<int>();
        private void ChooseFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                List<string> Spisok = new List<string>();
                string prod;
                if (ofd.FileName != "")
                {
                    prod = File.ReadAllText(ofd.FileName);
                    Spisok.AddRange(prod.Split('\n'));
                }
                polesnost = new int[Spisok.Count];
                сena = new int[Spisok.Count];
                Pokupki.Clear();
                Menu.ItemsSource = null;
                for (int i = 0; i < Spisok.Count; i++)
                {
                    string[] aaa = new string[4];
                    aaa = Spisok[i].Split(':');
                    Pokupki.Add(item: new Ort() { Kategorie = aaa[0], Name = aaa[1], Preis = Convert.ToInt32(aaa[2]), Nutzlichkeit = Convert.ToInt32(aaa[3]) });
                    PokupkiK.Add(aaa[0]);
                    сena[i] = Convert.ToInt32(aaa[2]);
                    polesnost[i] = Convert.ToInt32(aaa[3]);
                }
                Menu.ItemsSource = Pokupki;
                for (int i = 0; i < PokupkiK.Count; i++)            
                    for (int j = i + 1; j < PokupkiK.Count; j++)
                        if (PokupkiK[i] == PokupkiK[j])
                            PokupkiK.RemoveAt(j);
                Kateg.ItemsSource = PokupkiK;
            }
            catch (Exception)
            {
                MessageBox.Show("Измените формат файла или путь к файлу");
                Put.Text = "Путь к файлу...";
            }

        }
        private void Itogo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int u = 0;
                Knapsack.Items.Clear();
                int geld = Math.Abs(Convert.ToInt32(Summa.Text));
                PolezniePokupki = Knapsack_problem.knapsack(сena, polesnost, geld);
                for (u = 0; u < (PolezniePokupki.Count - 1); u++)
                    Knapsack.Items.Add(Pokupki[PolezniePokupki[u]].Name);
                Knapsack.Items.Add("Итоговая полезность: " + PolezniePokupki[u]);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите сумму денег с помощью цифр");
            }
        }
        private void Kateg_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                KategPok.Clear();
                BestPokupkiK.Clear();
                Knapsack.Items.Clear();
                for (int i = 0; i < Pokupki.Count; i++)
                    if (Pokupki[i].Kategorie == PokupkiK[Kateg.SelectedIndex])
                        KategPok.Add(Pokupki[i]);
                int[] polesnostK = new int[KategPok.Count];
                int[] cenaK = new int[KategPok.Count];
                for (int i = 0; i < KategPok.Count; i++)
                {
                    cenaK[i] = KategPok[i].Preis;
                    polesnostK[i] = KategPok[i].Nutzlichkeit;
                }
                int j;
                int money = Math.Abs(Convert.ToInt32(Summa.Text));
                BestPokupkiK = Knapsack_problem.knapsack(cenaK, polesnostK, money);
                for (j = 0; j < (BestPokupkiK.Count - 1); j++)
                    Knapsack.Items.Add(KategPok[BestPokupkiK[j]].Name);
                Knapsack.Items.Add("Итоговая полезность: " + BestPokupkiK[j]);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите сумму денег");
            }
        }
    }
}
