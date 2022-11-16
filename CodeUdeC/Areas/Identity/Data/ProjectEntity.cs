
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeUdeC.Areas.Identity.Data;

    public class ProjectEntity
    {
        //Projects Entity Atributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
        public int ProjectId { get; set; }

        [Required, StringLength(60)]
        public string ProjectTitle { get; set; }

        [Required, StringLength(60)]
        public string ProjectDescription { get; set; }

        public string ProjectUser { get; set; }

        public byte[]? ProjectFile { get; set; }

        public string ProjectExt { get; set; }


    }

