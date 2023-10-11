using CretanMusicians.Domain.Entities;

namespace CretanMusicians.Application.Contracts.Repositories;

public interface IMusicianRepository
{
    Task<Musician> GetOneByIdAsync(Guid musicianId);
}