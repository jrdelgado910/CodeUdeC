using CodeUdeC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class ContributorEntity
    {
        //Contributors Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int ContributorId { get; set; }

        [Required]
        public DateTime ContributorDate { get; set; }


        //Relationship with User Entity (FK)
        public AppUser Users { get; set; }


        //Relationship with Project Entity (FK)
        public ProjectEntity Proyects { get; set; }
    }

