using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace goiaba_api.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo primeiro nome é obrigatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O primeiro nome deve ter no minimo 3 caracteres e no maximo 50 caracteres")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O sobrenome deve ter no minimo 3 caracteres e no maximo 50 caracteres")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "O campo age é obrigatorio")]
        public int Age { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mmZ}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }


    }
}