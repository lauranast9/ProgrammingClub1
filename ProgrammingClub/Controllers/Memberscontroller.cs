﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using ProgrammingClub.Helpers;
using ProgrammingClub.Models;
using ProgrammingClub.Models.CreateOrUpdateModels;
using ProgrammingClub.Services;


namespace ProgrammingClub.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        // GET: api/<MembersController>
        [HttpGet]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var members = await _membersService.GetAllMembersAsync();
                if (members.Count() <= 0)
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoMembersFound);
                }
                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
       
        public async Task<IActionResult> GetV2()
        {
            try
            {
                var members = await _membersService.GetAllMembersAsync();
                if (members.Count() <= 0)
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoMembersFound);
                }
                return Ok("Return V2");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api by ID/<MembersController>/2
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                Member member = await _membersService.GetMemberByIdAsync(id);
                if (member != null)
                    return StatusCode((int)HttpStatusCode.OK, member);
                return StatusCode((int)HttpStatusCode.NotFound, ErrorMessagesEnum.MemberNotFound);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<MembersController>/3
        [HttpPost]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Post([FromBody] Member member)
        {
            try
            {
                if (member != null)
                {
                    await _membersService.AddMemberAsync(member);
                    return StatusCode((int)HttpStatusCode.Created, SuccessMessages.MemberAdded);
                }
                return StatusCode((int)HttpStatusCode.BadRequest, ErrorMessagesEnum.InvalidData);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<MembersController>/4
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Member member)
        {
            try
            {
                if (member == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, ErrorMessagesEnum.InvalidData);
                }
                var updatedMember = await _membersService.UpdateMemberAsync(id, member);

                if (updatedMember != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, SuccessMessages.MemberUpdated);
                }

                return StatusCode((int)HttpStatusCode.NotFound, ErrorMessagesEnum.MemberNotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PATCH api/<MembersController>/5
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchMember(Guid id, [FromBody] UpdateMemberPartially member)
        {
            try
            {
                if (member == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, ErrorMessagesEnum.InvalidData);
                }
                Member updateMember = await _membersService.UpdateMemberPartiallyAsync(id, member);
                if (updateMember != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, SuccessMessages.MemberAdded);
                }
                return StatusCode((int)HttpStatusCode.NotFound, ErrorMessagesEnum.MemberNotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<MembersController>/6
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _membersService.DeleteMemberAsync(id);
                return StatusCode((int)HttpStatusCode.OK, SuccessMessages.MemberDelete);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}