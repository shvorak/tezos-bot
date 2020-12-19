using System;
using Microsoft.EntityFrameworkCore;
using TezosNotifyBot.Domain;
using TezosNotifyBot.Storage.Extensions;
using Delegate = TezosNotifyBot.Domain.Delegate;

namespace TezosNotifyBot.Storage
{
    public class TezosDataContext: DbContext
    {

        #region DbSet's

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<LastBlock> LastBlock { get; set; }
        public DbSet<Delegate> Delegates { get; set; }
        public DbSet<UserAddressDelegation> UserAddressDelegations { get; set; }
        public DbSet<DelegateRewards> DelegateRewards { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<KnownAddress> KnownAddresses { get; set; }
        public DbSet<ProposalVote> ProposalVotes { get; set; }
        public DbSet<BakingRights> BakingRights { get; set; }
        public DbSet<EndorsingRights> EndorsingRights { get; set; }
        public DbSet<BalanceUpdate> BalanceUpdates { get; set; }
        public DbSet<TwitterMessage> TwitterMessages { get; set; }

        #endregion
        
        public TezosDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations below
            modelBuilder.Entity<UserAddress>()
                .Property(b => b.NotifyTransactions)
                .HasDefaultValue(true);
            modelBuilder.Entity<UserAddress>()
                .Property(b => b.NotifyDelegations)
                .HasDefaultValue(true);
            modelBuilder.Entity<UserAddress>()
                .Property(b => b.NotifyMisses)
                .HasDefaultValue(true);
            modelBuilder.Entity<UserAddress>()
                .Property(b => b.NotifyCycleCompletion)
                .HasDefaultValue(true);
            modelBuilder.Entity<ProposalVote>()
                .Property(b => b.Ballot)
                .HasDefaultValue(0);
            modelBuilder.Entity<ProposalVote>()
                .Property(b => b.Level)
                .HasDefaultValue(0);
            
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserAddress>();
            modelBuilder.Entity<UserAddressDelegation>();
            modelBuilder.Entity<Message>();
            modelBuilder.Entity<Delegate>();
            modelBuilder.Entity<KnownAddress>();
            modelBuilder.Entity<TwitterMessage>();
            modelBuilder.Entity<BalanceUpdate>();
            modelBuilder.Entity<Proposal>();
            modelBuilder.Entity<ProposalVote>();

            modelBuilder.Entity<AddressConfig>()
                .HasData(
                    new AddressConfig("tz1aRoaRhSpRYvFdyvgWLL6TGyRoGF51wDjM", "💎")
                );

            modelBuilder.Entity<TezosRelease>(builder =>
                {
                    builder.HasKey(x => x.Tag);
                    builder.Property(x => x.Tag).ValueGeneratedNever();
                })
                ;
            
            // MUST BE BELOW ANY OTHER CONFIGURATIONS
            modelBuilder.ApplyPostgresConventions();
        }
    }
}