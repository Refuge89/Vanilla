using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_battlegroundMap : EntityTypeConfiguration<creature_battleground>
    {
        public creature_battlegroundMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}