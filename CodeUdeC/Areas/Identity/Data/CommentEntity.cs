using CodeUdeC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class CommentEntity
    {
        //Comments Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int CommentId { get; set; }

        [Required, StringLength(600)]
        public string CommentText { get; set; }

        public string? CommentImg { get; set; }


        //Relationship with User Entity (FK)
        public AppUser Users { get; set; }


    }

