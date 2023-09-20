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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        static List<Fuvar> feladatok;
        public MainWindow()
        {
            InitializeComponent();
        }


        public void FileBeolvasas(string fileNev)
        {
            feladatok = new List<Fuvar>();
            foreach (var sor in File.ReadAllLines(fileNev).Skip(1))
            {
                int taxiAzonosito = int.Parse(sor.Split(";")[0]);
                DateTime indulasIdopontja = DateTime.Parse(sor.Split(";")[1]);
                int utaztasIdotartama = int.Parse(sor.Split(";")[2]);
                double megtettTav = double.Parse(sor.Split(";")[3]);
                double viutelDij = double.Parse(sor.Split(";")[4]);
                double borravalo = double.Parse(sor.Split(";")[5]);
                string bankkartya = sor.Split(";")[6];
                feladatok.Add(new Fuvar(taxiAzonosito, indulasIdopontja, utaztasIdotartama, megtettTav, viutelDij, borravalo, bankkartya));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog beolvasas = new OpenFileDialog();
            if (beolvasas.ShowDialog() == true)
            {
                FileBeolvasas(beolvasas.FileName);
                lblHarmadikFeladat.Content = $"3. feladat {feladatok.Count()} fuvar";

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog beolvasas = new OpenFileDialog();
            if (beolvasas.ShowDialog() == true)
            {
                FileBeolvasas(beolvasas.FileName);

                lblNegyedikFeladat.Content = feladatok.Where(x => x.TaxiAzonosito == 6185).Select(x => x.ViutelDij);
               // lblNegyedikFeladat.Content = feladatok.FindAll(x => x.ViutelDij).Where(x => x.TaxiAzonosito == 6185);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog beolvasas = new OpenFileDialog();
            if (beolvasas.ShowDialog() == true)
            {
                FileBeolvasas(beolvasas.FileName);

                int bankk = feladatok.Where(x => x.Bankkartya == "bankkártya").Count();
                int kp = feladatok.Where(x => x.Bankkartya == "készpénz").Count();
                int vita = feladatok.Where(x => x.Bankkartya == "vitatott").Count();
                int ingyen = feladatok.Where(x => x.Bankkartya == "ingyenes").Count();
                int ismeretlen = feladatok.Where(x => x.Bankkartya == "ismeretlen").Count();

                lblOtodikkFeladat.Content = $"5. feladat: \nbankkártya: {bankk} fuvar" +
                    $"\nkészpénz: {kp} fuvar" +
                    $"\nvitatott: {vita} fuvar" +
                    $"\ningyenes: {ingyen} fuvar" +
                    $"\nismeretlen: {ismeretlen} fuvar";


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog beolvasas = new OpenFileDialog();
            if (beolvasas.ShowDialog() == true)
            {
                FileBeolvasas(beolvasas.FileName);

                var megtettTavok = feladatok.Select(x => x.MegtettTav).ToList();
                double osszesMegtettSzam = megtettTavok.Count();
                double atvalt =Math.Round(osszesMegtettSzam*1.6, 2);
                lblHatodikFeladat.Content = atvalt;

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            //var hibas = feladatok.Where(x => x.UtaztasIdotartama > 0 && x.ViutelDij > 0 && x.MegtettTav == 0);
            /* using (StreamWriter writetext = new StreamWriter("hibak.txt"))
             {
                 writetext.WriteLine(hibas);
             }*/
            using (StreamWriter writetext = new StreamWriter("hiba.txt"))
            {
                writetext.WriteLine(feladatok.Where(x => x.UtaztasIdotartama > 0 && x.ViutelDij > 0 && x.MegtettTav == 0));
            }


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //hetes

            double maxUtazas = feladatok.Max(x => x.UtaztasIdotartama);
            
        }
    }
}
