using System.Collections;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var commandItems = _repository.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(commandItems));
        }
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
        {
            var commandItem = _repository.GetEmployeeById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(commandItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(employeeCreateDto);
            _repository.CreateEmployee(employeeModel);
            _repository.SaveChanges();
            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);
            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.EmployeeId }, employeeReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeUpdateDto, employeeModelFromRepo);
            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
         [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDocument)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepo);

            patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeModelFromRepo);
            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/commands/{api}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id){
            var employeeModelFromRepo=_repository.GetEmployeeById(id);
            if(employeeModelFromRepo==null){
                return NotFound();
            }
            _repository.DeleteCommand(employeeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}