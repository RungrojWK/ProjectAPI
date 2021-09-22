using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;
using ProjectAPI.Repository.IRepository;
using AutoMapper;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var objList = _bookRepo.GetBooks();
            var objDto = new List<BookDto>();
            foreach(var obj in objList)
            {
                objDto.Add(_mapper.Map<BookDto>(obj));
            }
            return Ok(objDto);
        }
    }
}
