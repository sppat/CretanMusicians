﻿using AutoMapper;
using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.MusicianDto;
using CretanMusicians.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusiciansRepository _musiciansRepository;
        private readonly IMapper _mapper;

        public MusiciansController(IMusiciansRepository musiciansRepository, IMapper mapper)
        {
            _musiciansRepository = musiciansRepository;
            _mapper = mapper;
        }

        // GET /api/musicians/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicianDto>>> GetMusicians()
        {
            var records = await _musiciansRepository.GetAllWithDetailsAsync();
            var musicians = _mapper.Map<IEnumerable<MusicianDto>>(records);

            return Ok(musicians);
        }

        // GET /api/musicians/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicianDto>> GetMusician(int id)
        {
            var recordExists = await _musiciansRepository.Exists(id);
            if (!recordExists)
            {
                return NotFound(ResponeMessages.NotFoundMessage("Musician"));
            }

            var record = await _musiciansRepository.GetWithDetailsAsync(id);
            var musician = _mapper.Map<MusicianDto>(record);

            return Ok(musician);
        }

        // POST /api/musicians/
        [HttpPost]
        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult<CreateMusicianDto>> CreateMusician(CreateMusicianDto createMusicianDto)
        {
            var recordExists = await _musiciansRepository.Exists(createMusicianDto.Name);
            if (recordExists)
            {
                return BadRequest(ResponeMessages.AlreadeyExistsMessage("Musician"));
            }

            var musician = _mapper.Map<Musician>(createMusicianDto);
            await _musiciansRepository.AddAsync(musician);

            return Ok(ResponeMessages.SuccessfullyAddedMessage("Musician"));
        }

        // PUT /api/musicians/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> PutMusician(int id, UpdateMusicianDto updateMusicianDto)
        {
            if (id != updateMusicianDto.Id)
            {
                return BadRequest();
            }

            var record = await _musiciansRepository.GetAsync(id);

            if (record == null)
            {
                return NotFound(ResponeMessages.NotFoundMessage("Musician"));
            }

            _mapper.Map(updateMusicianDto, record);

            try
            {
                await _musiciansRepository.UpdateAsync(record);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _musiciansRepository.Exists(id))
                {
                    return NotFound(ResponeMessages.NotFoundMessage("Musician"));
                }
                else
                {
                    throw;
                }
            }

            return Ok(ResponeMessages.SuccessfullyModifiedMessage("Musician"));
        }

        // DELETE /api/musicians/1
        [HttpDelete]
        [Authorize(Roles = "Administrator, User")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            var record = await _musiciansRepository.GetAsync(id);
            if (record == null)
            {
                return NotFound(ResponeMessages.NotFoundMessage("Musician"));
            }

            await _musiciansRepository.DeleteAsync(id);

            return Ok(ResponeMessages.SuccessfullyDeletedMessage("Musician"));
        }
    }
}
