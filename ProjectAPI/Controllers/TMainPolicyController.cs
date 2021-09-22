using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models.Dtos;
using ProjectAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/v{version:apiVersion}/policy")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TMainPolicyController : ControllerBase
    {
        private IMainPolicyRepository _repo;
        private readonly IMapper _mapper;

        public TMainPolicyController(IMainPolicyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TMainPolicyDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetPolicy()
        {
            var objList = _repo.GetPolicy();

            var objDto = new List<TMainPolicyDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<TMainPolicyDto>(obj));
            }

            return Ok(objDto);
        }
    }
}
