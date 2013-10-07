using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class pet_spell_cooldownMap : EntityTypeConfiguration<pet_spell_cooldown>
    {
        public pet_spell_cooldownMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.spell });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}