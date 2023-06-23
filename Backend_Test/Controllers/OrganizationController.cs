using System;
using Backend_Test.Models;
using Backend_Test.Repositories;
using Backend_Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test.Controllers
{

    [Route("api/organization")]
    [ApiController]
    [Authorize] //Question 4

    public class OrganizationController : Controller
    {
        private readonly ICookieService _cookieService;
        private OrganizationRepository _organizationRepository;
        public OrganizationController(OrganizationRepository orgRepository, ICookieService cookieService)
        {
            _organizationRepository = orgRepository;
            _cookieService = cookieService;
        }

        //Question 2i
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organization>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _organizationRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        //Question 2ii
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = await _organizationRepository.GetById(Id);
            return Ok(user);
        }

        //Question 2iii
        [HttpPost("InsertOrg")]
        [Authorize(Policy = "AdminOnly")] //Question 4
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> InsertOrg([FromBody] Organization organization)
        {
            // Question 3
            // Access the desired cookie information using the CookieService
            string primarySid = _cookieService.GetPrimarySidClaim();
            string name = _cookieService.GetNameClaim();

            var user = await _organizationRepository.InsertOrg(organization);
            return Ok(user);
        }

        //Question 2iv
        [HttpPost("UpdateOrg")]
        [Authorize(Policy = "AdminOnly")] //Question 4
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrg([FromBody] Organization organization)
        {
            var user = await _organizationRepository.UpdateOrg(organization);
            return Ok(user);
        }

        //Question 2v
        [HttpPost("DeleteOrg")]
        [Authorize(Policy = "AdminOnly")] //Question 4
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteOrg([FromBody] Organization organization)
        {
            var user = await _organizationRepository.DeleteOrg(organization);
            return Ok(user);
        }

    }

}