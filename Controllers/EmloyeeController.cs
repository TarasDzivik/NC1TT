﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NC1TestTask.IRpository;
using NC1TestTask.Models.DTOs;

namespace NC1TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmloyeeController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public EmloyeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Calls
        #region Get methods
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAll();
                var results = _mapper.Map<IList<EmployeeDTO>>(employees);
                return Ok(results);
            }
            catch (Exception ex)
            {
                // here we could to log an error for example
                // _logger.LogError(ex, $"Something get wrong in the {nameof(GetEmployees)}");
                return StatusCode(500, $"At this time there is no possibility to do that. Try again later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.Get(q => q.EmployeeId == id, new List<string> {"EmloyeeProgLanguages"} );
                var result = _mapper.Map<EmployeeDTO>(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, $"At this time there is no possibility to do that. Try again later.");
            }
        }
        #endregion
        #endregion
    }
}
