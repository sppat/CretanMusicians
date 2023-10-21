using CretanMusicians.Api.ApiContracts.MusicianContracts;
using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Pagination;
using CretanMusicians.Application.Musicians.CreateMusician;
using CretanMusicians.Application.Musicians.GetManyMusicians;
using CretanMusicians.Application.Musicians.GetOneMusician;
using CretanMusicians.Domain.Exceptions;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PaginatedResult<MusicianDetailsDto>>> GetMusicians(
            [FromQuery] PaginationContract contractParams)
        {
            var paginationParams = new PaginationParams
            {
                ItemsPerPage = contractParams.ItemsPerPage,
                Page = contractParams.Page
            };

            var result = await _mediator.Send(new GetManyMusiciansQuery(paginationParams));

            return result.Match<ActionResult<PaginatedResult<MusicianDetailsDto>>>(
                items => Ok(items),
                exception => HandleFailure(exception));
        }

        [HttpGet("{musicianId:guid}", Name = "GetMusician")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MusicianDetailsDto>> GetMusician(Guid musicianId)
        {
            var result = await _mediator.Send(new GetOneMusicianQuery(musicianId));

            return result.Match<ActionResult<MusicianDetailsDto>>(
                musician => musician is null
                    ? NotFound(musician)
                    : Ok(musician)
                , exception => HandleFailure(exception));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MusicianDetailsDto>> Create(CreateMusicianContract request)
        {
            var command = new CreateMusicianCommand(
                InstrumentName: request.InstrumentName,
                FirstName: request.FirstName,
                LastName: request.LastName);

            var result = await _mediator.Send(command);

            return result.Match<ActionResult<MusicianDetailsDto>>(
                musician => CreatedAtRoute(nameof(GetMusician), new { MusicianId = musician!.Id }, musician),
                exception => HandleFailure(exception));
        }

        private ActionResult HandleFailure(Exception exception)
        {
            if (exception is not ValidationException validationException)
            {
                return Problem(
                    title: GeneralExceptionMessages.InternalServerErrorMessage,
                    statusCode: StatusCodes.Status500InternalServerError);
            }

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation errors"
            };

            validationException.Errors.ToList().ForEach(e =>
            {
                problemDetails.Extensions.Add(e.PropertyName, e.ErrorMessage);
            });

            return BadRequest(problemDetails);
        }
    }
}