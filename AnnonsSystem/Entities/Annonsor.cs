using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnonsSystem.Entities
{
    [Table("tbl_annonsorer")]
    public class Annonsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] /* Database will generate an id*/
        public int Id { get; set; }

        public Ad Ad { get; set; }
    }
}
