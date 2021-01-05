using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using API.Models;

namespace API.Data
{
    public interface IEmployeeRepo
    {
         bool SaveChanges();
         IEnumerable<EmployeeModel> GetAllEmployees();
         EmployeeModel GetEmployeeById(int id);
         void CreateEmployee(EmployeeModel employee);
         void UpdateEmployee(EmployeeModel employee);
         void DeleteCommand(EmployeeModel employee);
    }
}