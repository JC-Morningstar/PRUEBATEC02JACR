using System;
using System.Collections.Generic;

namespace PRUEBATEC01JACR.Models
{
    public partial class Musico
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Instrumento { get; set; }
        public int? Edad { get; set; }
        public int? BandaId { get; set; }

        public virtual Banda? Banda { get; set; }
    }
}
