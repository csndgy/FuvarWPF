using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Fuvar
    {
        int taxiAzonosito;
        DateTime indulasIdopontja;
        int utaztasIdotartama;
        double megtettTav;
        double viutelDij;
        double borravalo;
        string bankkartya;

        public Fuvar(int taxiAzonosito, DateTime indulasIdopontja, int utaztasIdotartama, double megtettTav, double viutelDij, double borravalo, string bankkartya)
        {
            this.taxiAzonosito = taxiAzonosito;
            this.indulasIdopontja = indulasIdopontja;
            this.utaztasIdotartama = utaztasIdotartama;
            this.megtettTav = megtettTav;
            this.viutelDij = viutelDij;
            this.borravalo = borravalo;
            this.bankkartya = bankkartya;
        }

        public int TaxiAzonosito { get => taxiAzonosito; set => taxiAzonosito = value; }
        public DateTime IndulasIdopontja { get => indulasIdopontja; set => indulasIdopontja = value; }
        public int UtaztasIdotartama { get => utaztasIdotartama; set => utaztasIdotartama = value; }
        public double MegtettTav { get => megtettTav; set => megtettTav = value; }
        public double ViutelDij { get => viutelDij; set => viutelDij = value; }
        public double Borravalo { get => borravalo; set => borravalo = value; }
        public string Bankkartya { get => bankkartya; set => bankkartya = value; }
    }
}
