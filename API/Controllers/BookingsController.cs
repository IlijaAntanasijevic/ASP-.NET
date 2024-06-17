﻿using Application.DTO.Bookings;
using Application.UseCases.Commands.Bookings;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public BookingsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] BookingDto data, ICreateBookingCommand command)
        {
            _handler.HandleCommand(command,data);
            return Created();
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}