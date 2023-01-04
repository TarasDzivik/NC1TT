using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NC1TestTask.Data.Entities;
using NC1TestTask.IRpository;
using NC1TestTask.Models.DTOs;
using System.Diagnostics;

namespace NC1TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ProgrammingLanguageController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<IActionResult> GetProgrammingLanguage()
        {
            try
            {
                var language = await _unitOfWork.ProgLanguages.GetAll();
                var results = _mapper.Map<IList<ProgrammingLanguageDTO>>(language);
                return Ok(results);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something get wrong in the {nameof(GetProgrammingLanguage)}", (ex.Message));
                // here we could to log an error for example
                // _logger.LogError(ex, $"Something get wrong in the {nameof(GetEmployees)}");
                return StatusCode(500, $"At this time there is no possibility to do that. Try again later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgrammingLanguageById(int id)
        {
            try
            {
                var language = await _unitOfWork.ProgLanguages.Get(q => q.PLId == id, new List<string> { "EmployeeProgLanguages" });
                if (language == null)
                {
                    return NotFound($"There are no programming language with id: {id}");
                }
                var result = _mapper.Map<ProgrammingLanguageDTO>(language);
                return Ok(result);
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
        public async Task<IActionResult> CreateProgrammingLanguage([FromBody] CreateProgrammingLanguageDTO languageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var language = _mapper.Map<ProgrammingLanguage>(languageDTO);
                await _unitOfWork.ProgLanguages.Insert(language);
                await _unitOfWork.Save();
                return CreatedAtAction("GetProgrammingLanguage", language.PLId,  language);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500, "Can't create a Programming Language.");
            }
        }
        #endregion

        #region Update
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProgrammingLanguage(int id, [FromBody] UpdateProgrammingLanguageDTO languageDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                Debug.WriteLine($"Invalid UPDATE in {nameof(UpdateProgrammingLanguage)}, check model state.");
                return BadRequest();
            }
            try
            {
                var language = await _unitOfWork.ProgLanguages.Get(d => d.PLId == id);
                if (language == null)
                {
                    return NotFound($"There are no Programming Language with id: {id}");
                }

                _mapper.Map(languageDTO, language);
                _unitOfWork.ProgLanguages.Update(language);
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
        public async Task<IActionResult> DeleteProgrammingLanguage([FromQuery] int id)
        {
            if (id < 1)
            {
                Console.WriteLine("You have entered an invalid ID!");
                return BadRequest();
            }
            try
            {
                var language = await _unitOfWork.ProgLanguages.Get(d => d.PLId == id);
                if (language == null)
                {
                    return NotFound($"There are no Programming Language with id: {id}");
                }
                await _unitOfWork.ProgLanguages.Delete(id);
                await _unitOfWork.Save();
                return Ok($"The Programming Language with id: {id} successfuly deleted!");
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
