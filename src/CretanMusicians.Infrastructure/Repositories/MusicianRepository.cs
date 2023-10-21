using CretanMusicians.Application.Contracts.Dto.InstrumentDto;
using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Pagination;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Entities;
using CretanMusicians.Domain.ValueObjects;
using CretanMusicians.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.Infrastructure.Repositories;

public class MusicianRepository : IMusicianRepository
{
    private readonly AppDbContext _context;

    public MusicianRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<MusicianDetailsDto>> GetManyMusiciansAsync(PaginationParams @params)
    {
        var musicians = _context.Musicians
            .AsNoTracking()
            .OrderBy(m => m.Id);

        var paginationMetadata = new PaginationMetadata(
            currentPage: @params.Page,
            totalCount: musicians.Count(),
            itemsPerPage: @params.ItemsPerPage);

        var items = await musicians
            .AsNoTracking()
            .Include(m => m.Instruments)
            .Skip((@params.Page - 1) * @params.ItemsPerPage)
            .Take(@params.ItemsPerPage)
            .Select(m => m.ToDetailsDto())
            .ToListAsync();

        return new PaginatedResult<MusicianDetailsDto>(items, paginationMetadata);
    }

    public async Task<Musician?> GetOneByIdAsync(MusicianId musicianId)
        => await _context.Musicians
            .Include(m => m.Instruments)
            .Where(m => m.Id == musicianId)
            .SingleOrDefaultAsync();

    public async Task AddAsync(Musician musician) => await _context.AddAsync(musician);

    public async Task<bool> MusicianFullNameExistsAsync(string firstName, string lastName)
        => await _context.Musicians
            .AnyAsync(m =>
                m.FirstName.ToLower() == firstName.ToLower() &&
                m.LastName.ToLower() == lastName.ToLower());
}