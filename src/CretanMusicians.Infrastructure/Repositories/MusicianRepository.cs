using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Entities;

namespace CretanMusicians.Infrastructure.Repositories;

public class MusicianRepository : IMusicianRepository
{
    public Task<Musician> GetOneByIdAsync(Guid musicianId)
    {
        return Task.FromResult(new Musician());
    }
}