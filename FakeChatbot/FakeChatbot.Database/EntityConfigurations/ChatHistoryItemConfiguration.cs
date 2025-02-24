using FakeChatbot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeChatbot.Database.EntityConfigurations
{
    class ChatHistoryItemConfiguration : IEntityTypeConfiguration<ChatHistoryItem>
    {
        public const string TableName = "ChatHistoryItems";

        public void Configure(EntityTypeBuilder<ChatHistoryItem> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NewSequentialId()");

            builder.Property(x => x.Text).IsRequired();
            builder.HasIndex(x => x.Text);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.Mark).IsRequired(false);
        }
    }
}
