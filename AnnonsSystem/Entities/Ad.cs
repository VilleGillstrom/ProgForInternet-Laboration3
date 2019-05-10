using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnonsSystem.Entities
{
    [Table("tbl_ads")]
    public class Ad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ad_id")] /* Database will generate an id*/
        public int Id { get; set; }

        [ForeignKey("Annonsor")]
        [Column("ad_annonsor_id")]
        public int AnnonsorId { get; set; }
        public Annonsor Annonsor { get; set; }

        [Column("ad_rubrik")]
        public string Rubrik { get; set; }

        [Column("ad_innehall")]
        public string Innehall { get; set; }

        [Column("ad_pris_vara")]
        public int PrisVara{ get; set; }

        [Column("ad_pris_annons")]
        public int PrisAnnons { get; set; }
    }
}
