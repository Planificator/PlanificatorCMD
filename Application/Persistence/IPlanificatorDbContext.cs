using Application.Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IPlanificatorDbContext
    {
        DbSet<Photo> Photos { get; set; }
        DbSet<Presentation> Presentations { get; set; }
        DbSet<PresentationSpeaker> PresentationSpeakers { get; set; }
        DbSet<PresentationTag> PresentationTags { get; set; }
        DbSet<SpeakerProfile> SpeakerProfiles { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}