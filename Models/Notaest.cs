using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Notaest
    {
        public int Id { get; set; }
        public string? Carnet { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public short? IPN { get; set; }
        public short? IIPN { get; set; }
        public short? SIST { get; set; }
        public short? PROYEC { get; set; }
        public short? NF { get; set; }
        public short? EXCI { get; set; }
        public short? NFCI { get; set; }
        public short? IIC { get; set; }
    }
}
