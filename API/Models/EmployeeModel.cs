using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string EmployeeName { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string Occuption { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string ImageName { get; set; }
        
    }
}