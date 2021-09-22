using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Repository.IRepository;
using AutoMapper;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/v{version:apiVersion}/author")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AuthorV2Controller : ControllerBase
    {
        private IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorV2Controller(IAuthorRepository authorRepo, IMapper mapper)
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
            var obj = _authorRepo.GetAuthors().FirstOrDefault();
            return Ok(_mapper.Map<AuthorDto>(obj));
        }
    }
}
