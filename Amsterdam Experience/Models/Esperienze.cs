namespace Amsterdam_Experience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Esperienze")]
    public partial class Esperienze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Esperienze()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        
        public int idEsperienze { get; set; }

        [Required]
        [Display(Name = "ESPERIENZA")]
        public string nomeEsperienza { get; set; }

        [Required]
        [Display(Name = "DESCRIZIONE")]
        public string descrizioneEsperienza { get; set; }

        [Required]
        [Display(Name = "FOTO")]
        public string fotoEsperienza { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "PREZZO")]
        public decimal prezzoEsperienza { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        [Display(Name = "DATA")]
        public DateTime dataEsperienza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
