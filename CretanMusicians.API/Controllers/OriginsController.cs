using AutoMapper;
using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.OriginDto;
using CretanMusicians.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly IOriginsRepository _originsRepository;
        private readonly IMapper _mapper;

        private const string entity = "Origin";

        public OriginsController(IMapper mapper, IOriginsRepository originsRepository)
        {
            _mapper = mapper;
            _originsRepository = originsRepository;
        }

        // GET /api/origins/
        [HttpGet]
        public async Task<ActionResult<List<GetOriginsDto>>> GetOrigins()
        {
            var origins = await _originsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetOriginsDto>>(origins);

            return records;
        }

        // GET /api/origin/1
        [HttpGet("{id}")]
        public async Task<ActionResult<OriginDto>> GetOrigin(int id)
        {
            var origin = await _originsRepository.GetAsync(id);
            if (origin == null)
            {
                return NotFound(ResponeMessages.NotFoundMessage(entity));
            }

            var record = _mapper.Map<OriginDto>(origin);

            return record;
        }

        // POST /api/origins/
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PostOrigin(PostOriginsDto originDto)
        {
            var origin = _mapper.Map<Origin>(originDto);
            if (_originsRepository.Exists(origin.Name))
            {
                return BadRequest(ResponeMessages.AlreadeyExistsMessage(entity));
            }

            await _originsRepository.AddAsync(origin);

            return Ok(ResponeMessages.SuccessfullyAddedMessage(entity));
        }

        // PUT /api/origins/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PutOrigin(int id, PutOriginsDto putOriginsDto)
        {
            if (id != putOriginsDto.Id)
            {
                return BadRequest();
            }

            var record = await _originsRepository.GetAsync(id);

            if (record == null)
            {
                return NotFound(ResponeMessages.NotFoundMessage(entity));
            }

            _mapper.Map(putOriginsDto, record);

            try
            {
                await _originsRepository.UpdateAsync(record);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _originsRepository.Exists(id))
                {
                    return NotFound(ResponeMessages.NotFoundMessage(entity));
                }
                else
                {
                    throw;
                }
            }

            return Ok(ResponeMessages.SuccessfullyModifiedMessage(entity));
        }

        // DELETE /api/origins/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteOrigin(int id)
        {
            var origin = await _originsRepository.GetAsync(id);
            if (origin == null)
            {
                return NotFound(ResponeMessages.NotFoundMessage(entity));
            }

            await _originsRepository.DeleteAsync(id);

            return Ok(ResponeMessages.SuccessfullyDeletedMessage(entity));
        }
    }
}
