﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TezosNotifyBot.Storage;

namespace TezosNotifyBot.Storage.Migrations
{
    [DbContext(typeof(TezosDataContext))]
    [Migration("20201221121521_AddMessageKind")]
    partial class AddMessageKind
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TezosNotifyBot.Domain.AddressConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Icon")
                        .HasColumnType("text")
                        .HasColumnName("icon");

                    b.HasKey("Id")
                        .HasName("pk_address_config");

                    b.ToTable("address_config");

                    b.HasData(
                        new
                        {
                            Id = "tz1aRoaRhSpRYvFdyvgWLL6TGyRoGF51wDjM",
                            Icon = "💎"
                        },
                        new
                        {
                            Id = "tz1NortRftucvAkD1J58L32EhSVrQEWJCEnB",
                            Icon = "🥨"
                        });
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.BakingRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.HasKey("Id")
                        .HasName("pk_baking_rights");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_baking_rights_delegate_id");

                    b.ToTable("baking_rights");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.BalanceUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<long>("Amount")
                        .HasColumnType("bigint")
                        .HasColumnName("amount");

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<int>("Slots")
                        .HasColumnType("integer")
                        .HasColumnName("slots");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_balance_update");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_balance_update_delegate_id");

                    b.ToTable("balance_update");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.Delegate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_delegate");

                    b.ToTable("delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.DelegateRewards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<long>("Accured")
                        .HasColumnType("bigint")
                        .HasColumnName("accured");

                    b.Property<int>("Cycle")
                        .HasColumnType("integer")
                        .HasColumnName("cycle");

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<long>("Delivered")
                        .HasColumnType("bigint")
                        .HasColumnName("delivered");

                    b.Property<long>("Rewards")
                        .HasColumnType("bigint")
                        .HasColumnName("rewards");

                    b.HasKey("Id")
                        .HasName("pk_delegate_rewards");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_delegate_rewards_delegate_id");

                    b.ToTable("delegate_rewards");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.EndorsingRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<int>("SlotCount")
                        .HasColumnType("integer")
                        .HasColumnName("slot_count");

                    b.HasKey("Id")
                        .HasName("pk_endorsing_rights");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_endorsing_rights_delegate_id");

                    b.ToTable("endorsing_rights");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.KnownAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_known_address");

                    b.ToTable("known_address");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.LastBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Hash")
                        .HasColumnType("text")
                        .HasColumnName("hash");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.HasKey("Id")
                        .HasName("pk_last_block");

                    b.ToTable("last_block");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CallbackQueryData")
                        .HasColumnType("text")
                        .HasColumnName("callback_query_data");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<bool>("FromUser")
                        .HasColumnType("boolean")
                        .HasColumnName("from_user");

                    b.Property<int>("Kind")
                        .HasColumnType("integer")
                        .HasColumnName("kind");

                    b.Property<int>("TelegramMessageId")
                        .HasColumnType("integer")
                        .HasColumnName("telegram_message_id");

                    b.Property<string>("Text")
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_message");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_message_user_id");

                    b.ToTable("message");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<string>("Hash")
                        .HasColumnType("text")
                        .HasColumnName("hash");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Period")
                        .HasColumnType("integer")
                        .HasColumnName("period");

                    b.HasKey("Id")
                        .HasName("pk_proposal");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_proposal_delegate_id");

                    b.ToTable("proposal");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.ProposalVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Ballot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("ballot");

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("level");

                    b.Property<int>("ProposalID")
                        .HasColumnType("integer")
                        .HasColumnName("proposal_id");

                    b.Property<int>("VotingPeriod")
                        .HasColumnType("integer")
                        .HasColumnName("voting_period");

                    b.HasKey("Id")
                        .HasName("pk_proposal_vote");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_proposal_vote_delegate_id");

                    b.HasIndex("ProposalID")
                        .HasDatabaseName("ix_proposal_vote_proposal_id");

                    b.ToTable("proposal_vote");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.TezosRelease", b =>
                {
                    b.Property<string>("Tag")
                        .HasColumnType("text")
                        .HasColumnName("tag");

                    b.Property<string>("AnnounceUrl")
                        .HasColumnType("text")
                        .HasColumnName("announce_url");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("ReleasedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("released_at");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Tag")
                        .HasName("pk_tezos_release");

                    b.ToTable("tezos_release");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.TwitterMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Text")
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<string>("TwitterId")
                        .HasColumnType("text")
                        .HasColumnName("twitter_id");

                    b.HasKey("Id")
                        .HasName("pk_twitter_message");

                    b.ToTable("twitter_message");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("EditUserAddressId")
                        .HasColumnType("integer")
                        .HasColumnName("edit_user_address_id");

                    b.Property<int>("Explorer")
                        .HasColumnType("integer")
                        .HasColumnName("explorer");

                    b.Property<string>("Firstname")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<bool>("HideHashTags")
                        .HasColumnType("boolean")
                        .HasColumnName("hide_hash_tags");

                    b.Property<bool>("Inactive")
                        .HasColumnType("boolean")
                        .HasColumnName("inactive");

                    b.Property<string>("Language")
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<string>("Lastname")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<int>("NetworkIssueNotify")
                        .HasColumnType("integer")
                        .HasColumnName("network_issue_notify");

                    b.Property<int>("UserState")
                        .HasColumnType("integer")
                        .HasColumnName("user_state");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<bool>("VotingNotify")
                        .HasColumnType("boolean")
                        .HasColumnName("voting_notify");

                    b.Property<int>("WhaleAlertThreshold")
                        .HasColumnType("integer")
                        .HasColumnName("whale_alert_threshold");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<decimal>("AmountThreshold")
                        .HasColumnType("numeric")
                        .HasColumnName("amount_threshold");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric")
                        .HasColumnName("balance");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<decimal>("DelegationAmountThreshold")
                        .HasColumnType("numeric")
                        .HasColumnName("delegation_amount_threshold");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<bool>("NotifyBakingRewards")
                        .HasColumnType("boolean")
                        .HasColumnName("notify_baking_rewards");

                    b.Property<bool>("NotifyCycleCompletion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("notify_cycle_completion");

                    b.Property<bool>("NotifyDelegations")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("notify_delegations");

                    b.Property<bool>("NotifyMisses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("notify_misses");

                    b.Property<bool>("NotifyTransactions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("notify_transactions");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_address");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_address_user_id");

                    b.ToTable("user_address");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.UserAddressDelegation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("DelegateId")
                        .HasColumnType("integer")
                        .HasColumnName("delegate_id");

                    b.Property<int>("UserAddressId")
                        .HasColumnType("integer")
                        .HasColumnName("user_address_id");

                    b.HasKey("Id")
                        .HasName("pk_user_address_delegation");

                    b.HasIndex("DelegateId")
                        .HasDatabaseName("ix_user_address_delegation_delegate_id");

                    b.HasIndex("UserAddressId")
                        .HasDatabaseName("ix_user_address_delegation_user_address_id");

                    b.ToTable("user_address_delegation");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.BakingRights", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_baking_rights_delegates_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.BalanceUpdate", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_balance_update_delegates_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.DelegateRewards", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_delegate_rewards_delegate_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.EndorsingRights", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_endorsing_rights_delegate_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.Message", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_message_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.Proposal", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_proposal_delegate_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.ProposalVote", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_proposal_vote_delegate_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TezosNotifyBot.Domain.Proposal", "Proposal")
                        .WithMany()
                        .HasForeignKey("ProposalID")
                        .HasConstraintName("fk_proposal_vote_proposal_proposal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.UserAddress", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_address_user_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TezosNotifyBot.Domain.UserAddressDelegation", b =>
                {
                    b.HasOne("TezosNotifyBot.Domain.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .HasConstraintName("fk_user_address_delegation_delegate_delegate_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TezosNotifyBot.Domain.UserAddress", "UserAddress")
                        .WithMany()
                        .HasForeignKey("UserAddressId")
                        .HasConstraintName("fk_user_address_delegation_user_address_user_address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");

                    b.Navigation("UserAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
