using CodeUdeC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class MessageEntity
    {
        //Message Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int MessageId { get; set; }

        [Required, StringLength(600)]
        public string MessageText { get; set; }

        public byte[]? MessageImg { get; set; }

        public byte[]? MessageFile { get; set; }


        //Relationship with Role Entity (FK)
        public AppUser Users { get; set; }
    }

