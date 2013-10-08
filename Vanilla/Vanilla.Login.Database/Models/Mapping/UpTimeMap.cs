using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class UpTimeMap : EntityTypeConfiguration<UpTime>
    {
        public UpTimeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RealmID, t.StartTime });

            // Properties
            this.Property(t => t.RealmID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StartTime)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StartString)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}