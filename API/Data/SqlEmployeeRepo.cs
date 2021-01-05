using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Data
{
    public class SqlEmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext _context ;
        public SqlEmployeeRepo(EmployeeDbContext context)
        {
            _context=context;
        }

        public void CreateEmployee(EmployeeModel employee)
        {
            if(employee==null){
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
        }

        public void DeleteCommand(EmployeeModel employee)
        {
            if(employee==null){
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(p=>p.EmployeeId==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            //nothing
        }
    }
}