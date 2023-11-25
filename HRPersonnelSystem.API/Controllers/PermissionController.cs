using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.PermissionDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }



        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissionList = await _permissionService.GetAllPermissionAsync();
            List<PermissionDTO> map = permissionList.Select(item => _mapper.Map<PermissionDTO>(item)).ToList();
            return Ok(map);
        }



        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<IActionResult> Post(PermissionDTO permissionDTO)
        {
            var permission = await _permissionService.CreatePermissionAsync(permissionDTO);
            PermissionDTO map = _mapper.Map<PermissionDTO>(permission);
            return Ok(map);
        }


		// PUT api/<PermissionController>/5
		[HttpPut]
        public async Task<IActionResult> Put(PermissionDTO permission)
        {
            await _permissionService.UpdatePermissionAsync(permission);
            return Ok(permission);
        }



        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _permissionService.DeletePermissionAsync(id);
            return Ok();
        }
    }
}