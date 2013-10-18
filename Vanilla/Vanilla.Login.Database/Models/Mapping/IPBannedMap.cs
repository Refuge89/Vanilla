namespace Vanilla.Database.Login.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class IPBannedMap : EntityTypeConfiguration<IPBanned>
    {
        public IPBannedMap()
        {
            // Primary Key
            this.HasKey(t => new { Ip = t.Ip, Bandate = t.Bandate });

            // Properties
            this.Property(t => t.Ip)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Bandate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Bannedby)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Banreason)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
