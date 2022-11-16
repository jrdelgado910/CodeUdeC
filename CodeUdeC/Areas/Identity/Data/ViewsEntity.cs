using CodeUdeC.Areas.Identity.Data;
using CodeUdeC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class ViewsEntity
    {
        //Views Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int ViewsId { get; set; }

        public DateTime ViewsDate { get; set; }

        //Relationship with User Entity (FK)
        public AppUser? Users { get; set; }

    }
