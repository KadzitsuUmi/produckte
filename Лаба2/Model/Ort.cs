using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2.Model
{
    public class Ort : Elemente
    {
        string _Kategorie, _Name;
        int _Preis, _Nutzlichkeit;
        public string kategorie;
        public string name;
        public int preis; 
        public int nutzlichkeit;
        public Ort()
        {
            _Kategorie = kategorie;
            _Name = name;
            _Preis = preis;
            _Nutzlichkeit = nutzlichkeit;
        }
        public string Kategorie { get => _Kategorie; set => _Kategorie = value; }
        public string Name { get => _Name; set => _Name = value; }
        public int Preis { get => _Preis; set => _Preis = value; }
        public int Nutzlichkeit { get => _Nutzlichkeit; set => _Nutzlichkeit = value; }
    }

   

}
