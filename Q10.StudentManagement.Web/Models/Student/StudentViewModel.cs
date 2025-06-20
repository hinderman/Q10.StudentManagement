using System.ComponentModel.DataAnnotations;

namespace Q10.StudentManagement.Web.Models.Students
{
    public class StudentViewModel
    {
        public Guid pId { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string? pEmail { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string? pName { get; set; }

        [Required(ErrorMessage = "El documento es requerido")]
        public string? pDocument { get; set; }

        public bool pState { get; set; }
    }
}
