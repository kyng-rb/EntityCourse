using Microsoft.EntityFrameworkCore;

namespace EntityCourse.Data.DataSeeds
{
    static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LeaguesConfiguration());
            builder.ApplyConfiguration(new TeamsConfiguration());
        }
    }
}
