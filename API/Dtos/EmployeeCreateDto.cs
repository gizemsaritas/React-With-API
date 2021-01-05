using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class EmployeeCreateDto
    {
        [Column(TypeName="nvarchar(50)")]
        public string EmployeeName { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string Occuption { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string ImageName { get; set; }
    }
}