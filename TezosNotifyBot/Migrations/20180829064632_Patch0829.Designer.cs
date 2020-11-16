﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TezosNotifyBot.Model;

namespace TezosNotifyBot.Migrations
{
    [DbContext(typeof(BotDataContext))]
    [Migration("20180829064632_Patch0829")]
    partial class Patch0829
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("TezosNotifyBot.Model.Delegate", b =>
                {
                    b.Property<int>("DelegateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("DelegateId");

                    b.ToTable("Delegates");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.LastBlock", b =>
                {
                    b.Property<int>("LastBlockID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.HasKey("LastBlockID");

                    b.ToTable("LastBlock");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CallbackQueryData");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("FromUser");

                    b.Property<int>("TelegramMessageId");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("EditUserAddressId");

                    b.Property<string>("Firstname");

                    b.Property<bool>("HideHashTags");

                    b.Property<bool>("Inactive");

                    b.Property<string>("Language");

                    b.Property<string>("Lastname");

                    b.Property<int>("UserState");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.UserAddress", b =>
                {
                    b.Property<int>("UserAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<decimal>("AmountThreshold");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<bool>("NotifyBakingRewards");

                    b.Property<int>("UserId");

                    b.HasKey("UserAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.UserAddressDelegation", b =>
                {
                    b.Property<int>("UserAddressDelegationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DelegateId");

                    b.Property<int>("UserAddressId");

                    b.HasKey("UserAddressDelegationId");

                    b.HasIndex("DelegateId");

                    b.HasIndex("UserAddressId");

                    b.ToTable("UserAddressDelegations");
                });

            modelBuilder.Entity("TezosNotifyBot.Model.Message", b =>
                {
                    b.HasOne("TezosNotifyBot.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TezosNotifyBot.Model.UserAddress", b =>
                {
                    b.HasOne("TezosNotifyBot.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TezosNotifyBot.Model.UserAddressDelegation", b =>
                {
                    b.HasOne("TezosNotifyBot.Model.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("DelegateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TezosNotifyBot.Model.UserAddress", "UserAddress")
                        .WithMany()
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
