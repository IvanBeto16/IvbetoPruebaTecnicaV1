using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Artista
    {
        public int IdArtista { get; set; }
        public string Nombre { get; set; }
        public int? AnioDebut { get; set; }
        public string Nacionalidad { get; set; }
        public List<object> Artistas { get; set; }
    }
}
