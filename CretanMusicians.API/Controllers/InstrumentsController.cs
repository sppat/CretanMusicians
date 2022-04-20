using AutoMapper;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.InstrumentDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly CretanMusiciansDbContext _context;
        private readonly IMapper _mapper;

        public InstrumentsController(CretanMusiciansDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /instruments/
        [HttpGet]
        public async Task<ActionResult<List<GetInstrumentsDto>>> GetInstruments()
        {
            var instruments = await _context.Instruments.ToListAsync();
            var records = _mapper.Map<List<GetInstrumentsDto>>(instruments);

            return records;
        }

        // GET /instruments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentDto>> GetInstruments(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            var record = _mapper.Map<InstrumentDto>(instrument);

            return record;
        }

        // POST /instruments/
        [HttpPost]
        public async Task<ActionResult> PostInstruments(InstrumentDto instrumentDto)
        {
            var record = _mapper.Map<Instrument>(instrumentDto);
            var recordExists = await _context.Instruments.AnyAsync(i => i.Name == record.Name);
            if (recordExists)
            {
                return NotFound("Instrument already exists.");
            }

            _context.Instruments.Add(record);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT /instruments/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInstrument(int id, UpdateInstrumentDto instrumentDto)
        {
            if (id != instrumentDto.Id)
            {
                return BadRequest();
            }

            var record = await _context.Instruments.FindAsync(id);

            if (record == null)
            {
                return NotFound("Instrument does not exists.");
            }

            _mapper.Map(instrumentDto, record);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var recordExists = _context.Instruments.Any(i => i.Id == record.Id);
                if (!recordExists)
                {
                    return NotFound("Record does not exists.");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE /api/instruments/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstrument(int id)
        {
            var record = await _context.Instruments.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Instruments.Remove(record);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
