using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Pagination;
using CretanMusicians.Domain.Entities;
using CretanMusicians.Domain.ValueObjects;

namespace CretanMusicians.Application.Contracts.Repositories;

public interface IMusicianRepository
{
    Task<PaginatedResult<MusicianDetailsDto>> GetManyMusiciansAsync(PaginationParams @params);
    Task<Musician?> GetOneByIdAsync(MusicianId musicianId);
    Task AddAsync(Musician musician);
    Task<bool> MusicianFullNameExistsAsync(string firstName, string lastName);
}