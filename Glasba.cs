using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npa_music_player
{
    internal class Glasba
    {
        string naslov;
        string datoteka;

        public Glasba(string n, string d)
        {
            naslov = n;
            datoteka = d;
        }

        public string Naslov
        {
            get { return naslov; } 
            set { naslov = value; }
        }
        public string Datoteka
        {
            get { return datoteka; }
            set { datoteka = value; }
        }
    }
}
