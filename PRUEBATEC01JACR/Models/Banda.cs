using System;
using System.Collections.Generic;

namespace PRUEBATEC01JACR.Models
{
    public partial class Banda
    {
        public Banda()
        {
            Musicos = new HashSet<Musico>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int? AñoFormacion { get; set; }

        public virtual ICollection<Musico> Musicos { get; set; }
    }
}
