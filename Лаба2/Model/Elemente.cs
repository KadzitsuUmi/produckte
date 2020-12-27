using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2.Model
{
    public interface Elemente
    {
        string Kategorie { get; set; }
        string Name { get; set; }
        int Preis { get; set; }
        int Nutzlichkeit { get; set; }
    }
}
