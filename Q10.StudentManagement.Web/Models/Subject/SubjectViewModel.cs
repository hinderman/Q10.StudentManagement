using System.ComponentModel.DataAnnotations;

namespace Q10.StudentManagement.Web.Models.Subject
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public int Credits { get; set; }

        public bool State { get; set; }
    }
}
