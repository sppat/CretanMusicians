using AutoMapper;
using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.OriginDto;
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
                return NotFound();
            }

            var record = _mapper.Map<OriginDto>(origin);

            return record;
        }

        // POST /api/origins/
        [HttpPost]
        public async Task<ActionResult> PostOrigin(PostOriginsDto originDto)
        {
            var origin = _mapper.Map<Origin>(originDto);
            if (_originsRepository.Exists(origin.Name))
            {
                return BadRequest();
            }

            await _originsRepository.AddAsync(origin);

            return Ok();
        }

        // PUT /api/origins/1
        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrigin(int id, PutOriginsDto putOriginsDto)
        {
            if (id != putOriginsDto.Id)
            {
                return BadRequest();
            }

            var record = await _originsRepository.GetAsync(id);

            if (record == null)
            {
                return NotFound();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE /api/origins/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrigin(int id)
        {
            var origin = await _originsRepository.GetAsync(id);
            if (origin == null)
            {
                return NotFound();
            }

            _originsRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
