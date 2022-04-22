using AutoMapper;
using CretanMusicians.API.Contracts;
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
        private readonly IInstrumentsRepository _instrumentsRepository;
        private readonly IMapper _mapper;

        public InstrumentsController(IInstrumentsRepository instrumentsRepository, IMapper mapper)
        {
            _instrumentsRepository = instrumentsRepository;
            _mapper = mapper;
        }

        // GET /instruments/
        [HttpGet]
        public async Task<ActionResult<List<GetInstrumentsDto>>> GetInstruments()
        {
            var instruments = await _instrumentsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetInstrumentsDto>>(instruments);

            return records;
        }

        // GET /instruments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentDto>> GetInstruments(int id)
        {
            var instrument = await _instrumentsRepository.GetAsync(id);
            var record = _mapper.Map<InstrumentDto>(instrument);

            return record;
        }

        // POST /instruments/
        [HttpPost]
        public async Task<ActionResult> PostInstruments(InstrumentDto instrumentDto)
        {
            var record = _mapper.Map<Instrument>(instrumentDto);
            var recordExists = _instrumentsRepository.Exists(record.Name);
            if (recordExists)
            {
                return NotFound("Instrument already exists.");
            }

            await _instrumentsRepository.AddAsync(record);

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

            var record = await _instrumentsRepository.GetAsync(id);

            if (record == null)
            {
                return NotFound("Instrument does not exists.");
            }

            _mapper.Map(instrumentDto, record);

            try
            {
                await _instrumentsRepository.UpdateAsync(record);
            }
            catch (DbUpdateConcurrencyException)
            {
                var recordExists = await _instrumentsRepository.Exists(id);
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
            var record = await _instrumentsRepository.GetAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            await _instrumentsRepository.DeleteAsync(id);

            return Ok();
        }
    }
}
