using AutoMapper;
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
        private readonly CretanMusiciansDbContext _context;
        private readonly IMapper _mapper;
        public OriginsController(CretanMusiciansDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/origins/
        [HttpGet]
        public async Task<ActionResult<List<GetOriginsDto>>> GetOrigins()
        {
            var origins = await _context.Origins.ToListAsync();
            var records = _mapper.Map<List<GetOriginsDto>>(origins);

            return records;
        }

        // GET /api/origin/1
        [HttpGet("{id}")]
        public async Task<ActionResult<OriginDto>> GetOrigin(int id)
        {
            var origin = await _context.Origins.FindAsync(id);
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
            if (RecordExists(originDto.Name))
            {
                return BadRequest();
            }

            _context.Origins.Add(origin);

            await _context.SaveChangesAsync();

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

            var record = await _context.Origins.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            _mapper.Map(putOriginsDto, record);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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
            var origin = await _context.Origins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }

            _context.Origins.Remove(origin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordExists(string name)
        {
            return _context.Origins.Any(elem => elem.Name == name);
        }

        private bool RecordExists(int id)
        {
            return _context.Origins.Any(elem => elem.Id == id);
        }
    }
}
