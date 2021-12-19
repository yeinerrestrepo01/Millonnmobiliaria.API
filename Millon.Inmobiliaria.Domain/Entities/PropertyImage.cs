using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Entities
{
    public partial class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey("IdProperty")]
        public virtual Property PropertyNavegation { get; set; }
    }
}
