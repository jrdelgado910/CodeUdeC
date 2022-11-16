using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class UpdateEntity
    {
        //Updates Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int UpdateId { get; set; }

        [Required, StringLength(600)]
        public string UpdateDescription { get; set; }

        public byte[]? UpdateImg { get; set; }

        public byte[]? UpdateFile { get; set; }

        public DateTime UpdateDate { get; set; }



    }
