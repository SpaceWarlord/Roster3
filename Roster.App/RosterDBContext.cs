﻿using Microsoft.EntityFrameworkCore;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata;
using Windows.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EntityFramework.Exceptions.Sqlite;

namespace Roster.App
{
    public class RosterDBContext : DbContext
    {
        //public DbSet<Equipment> Equipment { get; set; }
        //public DbSet<Ingredient> Ingredient { get; set; }
        //public DbSet<IngredientCategory> IngredientCategory { get; set; }
        //public DbSet<IngredientQuantity> IngredientQuantity { get; set; }
        //public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<RecipeUsage> RecipeUsage { get; set; }

        
        public DbSet<User> Users { get; set; }
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Worker> Workers { get; set; }        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftTemplate> ShiftTemplates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ShiftAddress> ShiftAddresseses { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<WorkerCertificate> WorkerCertificates { get; set; }

        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Test> Tests { get; set; }
        
       
        public RosterDBContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseExceptionProcessor();            
            optionsBuilder.UseSqlite("Data Source=database54.db");
            optionsBuilder.EnableSensitiveDataLogging(true);

            //optionsBuilder.UseSqlite("Data Source=recipe.db");

            //await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);

            //https://www.codeproject.com/Questions/5277740/UWP-data-binding-issue
            //optionsBuilder.UseSqlite("Data Source=\\data\\database5.db");
            //Debug.WriteLine("Path is " + Path.Combine(AppContext.BaseDirectory, "\\Data\\database5.db"));
            //optionsBuilder.UseSqlite("Data Source=" + Path.Combine(AppContext.BaseDirectory, "\\Data\\database5.db"));                

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetupContext(this.Database.IsSqlite()); // Identify if we are using a SQLite database
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
            /*
            //https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
            modelBuilder.Entity<Person>().UseTptMappingStrategy();

            modelBuilder.Entity<ParticipantAllergy>().HasKey(sc => new { sc.ParticipantId, sc.AllergyId });
            modelBuilder.Entity<RecipeIngredient>().HasKey(sc => new { sc.IngredientId, sc.RecipeId });
            modelBuilder.Entity<RecipeCombination>().HasKey(sc => new { sc.CombinbationId, sc.RecipeId });
            
            modelBuilder.Entity<Participant>().HasIndex(x => x.Nickname).IsUnique();
            modelBuilder.Entity<IngredientCategory>().HasMany(p => p.Ingredients).WithOne(d => d.Category).HasForeignKey(d => d.CategoryId);
            //modelBuilder.Entity<Supplier>().HasIndex(x => x.
            modelBuilder.Entity<IngredientCategory>().HasOne(c => c.Parent)
           .WithMany()
           .HasForeignKey(c => c.ParentId)
           .IsRequired(false);
            */

            //Table Per Type TPT
            //https://www.learnentityframeworkcore.com/inheritance/table-per-type
            modelBuilder.Entity<Person>().UseTptMappingStrategy();

            /*
            modelBuilder.Entity<Shift>()
                .HasOne(x => x.StartLocation)
                .WithOne(x => x.Shift)
                .HasForeignKey<ShiftAddress>("StartLocationId");

            modelBuilder.Entity<Shift>()
                .HasOne(x => x.EndLocation)
                .WithOne(x => x.Shift)
                .HasForeignKey<ShiftAddress>("EndLocationId");
            */

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                //https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }       
    }

    public static class DbSetExtensions
    {
        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ? dbSet.Add(entity) : null;
        }
    }

    public static class ContextSetup
    {
        public static void SetupContext(this ModelBuilder modelBuilder, bool isSQLite)
        {
            // Model building ...

            // Handle datetimes in SQLite src: https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
            if (isSQLite) // We found this in Context.cs
            {
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter()); // The converter!
                    }
                }
            }
        }
    }
}
