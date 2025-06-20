using System.ComponentModel.DataAnnotations;

namespace Q10.StudentManagement.Web.Models.Subject
{
    public class SubjectViewModel
    {
        public Guid pId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string? pName { get; set; }

        [Required(ErrorMessage = "El codigo es requerido")]
        public string? pCode { get; set; }

        [Required(ErrorMessage = "Los creditos son requeridos")]
        public int pCredits { get; set; }

        public bool pState { get; set; }
    }
}
