using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Infrastructure.DatabaseContext;

namespace CretanMusicians.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IMusicianRepository? _musicianRepository;
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IMusicianRepository MusicianRepository
        => _musicianRepository ??= new MusicianRepository(_context);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

}