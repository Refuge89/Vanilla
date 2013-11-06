using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class PlayerCreateiInfoSpellMap : EntityTypeConfiguration<PlayerCreateInfoSpell>
    {
        public PlayerCreateiInfoSpellMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Race, t.Class, t.Spell });

            // Properties
            this.Property(t => t.Spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Note)
                .HasMaxLength(255);

        }
    }
}
