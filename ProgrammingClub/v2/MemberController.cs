﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.Helpers;
using ProgrammingClub.Services;
using ProgrammingClub.v1.DTOs;
using ProgrammingClub.v2.DTOs;
using System.Net;

namespace ProgrammingClub.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        private readonly IMapper _mapper;
        public MembersController(IMembersService membersService, IMapper mapper)
        {
            _membersService = membersService;
            _mapper = mapper;
        }

        // GET api/<MembersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var members = await _membersService.GetAllMembersAsync();
                if (members.Count() <= 0)
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoMembersFound);
                }
                var membersV2s = _mapper.Map<IEnumerable<MemberV2Dto>>(members);
                return Ok(membersV2s);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}