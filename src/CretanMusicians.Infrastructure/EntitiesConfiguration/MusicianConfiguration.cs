using CretanMusicians.Domain.Entities;
using CretanMusicians.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CretanMusicians.Infrastructure.EntitiesConfiguration;

public class MusicianConfiguration : IEntityTypeConfiguration<Musician>
{
    public void Configure(EntityTypeBuilder<Musician> builder)
    {
        builder.HasKey(m => m.Id);
        builder
            .Property(m => m.Id)
            .HasConversion(
                idToGuid => idToGuid.Value,
                idToMusicianId => MusicianId.Create(idToMusicianId));
        builder.OwnsMany(m => m.Instruments, mi =>
        {
            mi.ToTable("instruments");
        });
    }
}