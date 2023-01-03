using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NC1TestTask.Data.Entities;
using NC1TestTask.IRpository;
using NC1TestTask.Models.DTOs;
using System.Diagnostics;

namespace NC1TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Calls
        #region Gets
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _unitOfWork.Departments.GetAll();
                var results = _mapper.Map<IList<DepartmentDTO>>(departments);
                return Ok(results);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something get wrong in the {nameof(GetDepartments)}", (ex.Message));
                // here we could to log an error for example
                // _logger.LogError(ex, $"Something get wrong in the {nameof(GetEmployees)}");
                return StatusCode(500, $"At this time there is no possibility to do that. Try again later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var department = await _unitOfWork.Departments.Get(q => q.DepartmentId == id, new List<string> { "Employees" });
                if (department == null)
                {
                    return NotFound($"There are no Employee with id: {id}");
                }
                var result = _mapper.Map<DepartmentDTO>(department);
                return Ok(result); //TODO: Rewrite return type to get only nesesary info about Employee (without water)
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500, $"At this time there is no possibility to do that. Try again later.");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var department = _mapper.Map<Department>(departmentDTO);
                await _unitOfWork.Departments.Insert(department);
                await _unitOfWork.Save();
                return CreatedAtAction("GetDepartment", department.DepartmentId, department);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500, "Can't create a Department.");
            }
        }
        #endregion

        #region Put
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                Debug.WriteLine($"Invalid UPDATE in {nameof(UpdateDepartment)}, check model state.");
                return BadRequest();
            }
            try
            {
                var department = await _unitOfWork.Departments.Get(d => d.DepartmentId == id);
                if (department == null)
                {
                    return NotFound($"There are no Department with id: {id}");
                }

                _mapper.Map(departmentDTO, department);
                _unitOfWork.Departments.Update(department);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500, "Internal server error!");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int id)
        {
            if (id < 1)
            {
                Console.WriteLine("You have entered an invalid ID!");
                return BadRequest();
            }
            try
            {
                var department = await _unitOfWork.Departments.Get(d => d.DepartmentId == id);
                if (department == null)
                {
                    return NotFound($"There are no Department with id: {id}");
                }
                await _unitOfWork.Departments.Delete(id);
                await _unitOfWork.Save();
                return Ok($"The Department with id: {id} successfuly deleted!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500, "Internal Server Error!");
            }
        }
        #endregion
        #endregion
    }
}
