using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Application.Models
{
    public class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        //[Required]
        public string ImageURL{ get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Date Upload")]
        [DataType(DataType.Date)]
        public DateTime DateUploaded { get; set; }
    }
}
