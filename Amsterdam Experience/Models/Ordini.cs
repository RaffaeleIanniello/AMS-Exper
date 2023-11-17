namespace Amsterdam_Experience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [Key]
        public int idOrdini { get; set; }

        public int fkUtenti { get; set; }

        public int fkEsperienze { get; set; }
        [NotMapped]
        public int quantita { get; set; }

        public virtual Esperienze Esperienze { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
