using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IDataProtector _protect;

        public TMainPolicyController(IMainPolicyRepository repo, IMapper mapper, IDataProtectionProvider provider)
        {
            _repo = repo;
            _mapper = mapper;
            _protect = provider.CreateProtector("MyIdProtector");
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TMainPolicyDto>))]
        [ProducesResponseType(400)]
        [Authorize(Roles = "1")]
        [ProducesDefaultResponseType]
        public IActionResult GetPolicy()
        {
            var objList = _repo.GetPolicy();

            var objDto = new List<TMainPolicyDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<TMainPolicyDto>(obj));
            }

            var output = objDto.Select(e =>
            {
                e.PolicyType = _protect.Protect(e.PolicyType.ToString());

                e.PolicyNumber = _protect.Protect(e.PolicyNumber.ToString());

                return e;
            });
            return Ok(output);
        }
    }
}
