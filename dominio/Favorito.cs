using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Favorito
    {
        public int Id { get; set; }
        public User IdUser { get; set; }
        public Articulo IdArticulo { get; set; }
    }
}
