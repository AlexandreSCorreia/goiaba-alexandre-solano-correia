using System.ComponentModel.DataAnnotations;


namespace goiaba_api.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "The first name field is mandatory")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The first name must have a minimum of 3 characters and a maximum of 50 characters")]
        public string FirstName { get; set; }

        [Range(1,150, ErrorMessage ="The Age field must be between 1 and 150.")]
        public int Age { get; set; }
        
        public string Surname { get; set; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        


    }
}