using CretanMusicians.Application.Musicians.CreateMusician;
using CretanMusicians.Application.Musicians.GetOneMusician;
using CretanMusicians.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MusiciansController : ControllerBase
    {
        private readonly ISender _mediator;

        public MusiciansController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{musicianId:guid}")]
        public async Task<ActionResult<Musician>> GetMusician(Guid musicianId)
        {
            var result = await _mediator.Send(new GetOneMusicianQuery(musicianId));
            
            return result.Match<ActionResult<Musician>>(
                musician => musician is null
                    ? NotFound(musician)
                    : Ok(musician)
                , exception =>
                {
                    if (exception is ValidationException validationException)
                    {
                        return BadRequest(validationException.Errors);
                    }
                    
                    return StatusCode(StatusCodes.Status500InternalServerError);
                });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMusicianCommand command)
        {
            return Created("", null);
        }
    }
}