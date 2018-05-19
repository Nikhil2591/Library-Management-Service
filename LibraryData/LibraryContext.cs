﻿using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public object LibraryAsset;

        public LibraryContext(DbContextOptions options) : base(options) { }


        public DbSet<Book> Books { get; set; }
        public DbSet<VideoGames> VideoGames { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<LibraryAsset> LibraryAssets { get; set; }

    }
 }