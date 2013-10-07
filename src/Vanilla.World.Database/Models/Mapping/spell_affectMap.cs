using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class spell_affectMap : EntityTypeConfiguration<spell_affect>
    {
        public spell_affectMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.effectId });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}