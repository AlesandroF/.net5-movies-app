using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class => Set<T>();
        public bool HasChanges() => ChangeTracker.HasChanges();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(GetGenres());
        }

        private Genre[] GetGenres()
        {
            return new List<Genre>
            {
                new(1, 1, new DateTime(2020, 12, 01), "Ação"),
                new(2, 1, new DateTime(2020, 12, 01), "Aventura"),
                new(3, 1, new DateTime(2020, 12, 01), "Comédia"),
                new(4, 1, new DateTime(2020, 12, 01), "Drama"),
                new(5, 1, new DateTime(2020, 12, 01), "Faroeste"),
                new(6, 1, new DateTime(2020, 12, 01), "Musical"),
                new(7, 1, new DateTime(2020, 12, 01), "Suspense"),
                new(8, 1, new DateTime(2020, 12, 01), "Terror"),
                new(9, 1, new DateTime(2020, 12, 01), "Romance"),
            }.ToArray();
        }
    }
}