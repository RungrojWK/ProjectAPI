using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Repository.IRepository;
using AutoMapper;
using ProjectAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Controllers
{
    [Route("api/v{version:apiVersion}/author")]
    //[Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of bookstores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var objList = _authorRepo.GetAuthors();

            var objDto = new List<AuthorDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<AuthorDto>(obj));
            }

            return Ok(objDto);
        }
        /// <summary>
        /// Get individual author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId:int}", Name = "GetAuthor")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        //[Authorize]
        [ProducesDefaultResponseType]
        public IActionResult GetAuthor(int authorId)
        {
            var obj = _authorRepo.GetAuthors(authorId);
            if (obj == null)
            {
                return NotFound();
            }
            //var objDto = _mapper.Map<AuthorDto>(obj);
            var objDto = new AuthorDto()
            {
                AuthorId = obj.AuthorId,
                LastName = obj.LastName,
                FirstName = obj.FirstName
            };
            return Ok(objDto);
        }
        //[HttpGet("{firstName:string}", Name = "GetAuthor")]
        //[ProducesResponseType(200, Type = typeof(AuthorDto))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesDefaultResponseType]
        //public IActionResult GetName(string firstName)
        //{
        //    var obj = _authorRepo.GetName(firstName);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    //var objDto = _mapper.Map<AuthorDto>(obj);
        //    var objDto = new AuthorDto()
        //    {
        //        AuthorId = obj.AuthorId,
        //        LastName = obj.LastName,
        //        FirstName = obj.FirstName
        //    };
        //    return Ok(objDto);
        //}
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAuthor([FromBody] AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_authorRepo.AuthorExists(authorDto.FirstName))
            {
                ModelState.AddModelError("", "Author Exists!");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authorObj = _mapper.Map<Author>(authorDto);
            if (!_authorRepo.CreateAuthor(authorObj))
            {
                ModelState.AddModelError("", $"Someting went wrong when saving the record {authorObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAuthor", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                authorId = authorObj.AuthorId
            }, authorObj);
        }
        [HttpPatch("{authorId:int}", Name = "UpdateAuthor")]
        [ProducesResponseType(204, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorDto authorDto)
        {
            if (authorDto == null || authorId != authorDto.AuthorId)
            {
                return BadRequest(ModelState);
            }
            var authorObj = _mapper.Map<Author>(authorDto);
            if (!_authorRepo.UpdateAuthor(authorObj))
            {
                ModelState.AddModelError("", $"Someting went wrong when updating the record {authorObj.FirstName}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{authorId:int}", Name = "DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAuthor(int authorId)
        {
            if (!_authorRepo.AuthorExists(authorId))
            {
                return NotFound();
            }
            var authorObj = _authorRepo.GetAuthors(authorId);
            if (!_authorRepo.DeleteAuthor(authorObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {authorObj.FirstName}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        //[HttpGet()]
        //public IActionResult GetAuthor(string name)
        //{
        //    var obj = _authorRepo.GetAuthors(name);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    var objDto = _mapper.Map<AuthorDto>(obj);
        //    return Ok(objDto);
        //}
    }
}
