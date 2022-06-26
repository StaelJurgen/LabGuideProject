using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using System;
using System.Security.Claims;

namespace PRI.Project.Labogids.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region UserSeeding
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            //admin user
            var adminOne = new ApplicationUser
            {
                Id = "1",
                UserName = "admin.one@labguide.com",
                NormalizedUserName = "ADMIN.ONE@LABGUIDE.COM",
                Email = "admin.one@labguide.com",
                NormalizedEmail = "ADMIN.ONE@LABGUIDE.COM",
                FirstName = "Admin",
                LastName = "One",
                DateOfBirth = new DateTime(2001,01,01),
                Address = "Spoorwegstraat 4",
                PostalCode = 8000,
                City = "Brugge",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            var adminTwo = new ApplicationUser
            {
                Id = "2",
                UserName = "admin.two@labguide.com",
                NormalizedUserName = "ADMIN.TWO@LABGUIDE.COM",
                Email = "admin.two@labguide.com",
                NormalizedEmail = "ADMIN.TWO@LABGUIDE.COM",
                FirstName = "Admin",
                LastName = "Two",
                DateOfBirth = new DateTime(2002, 02, 02),
                Address = "Spoorwegstraat 4",
                PostalCode = 8000,
                City = "Brugge",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            //user
            var userOne = new ApplicationUser
            {
                Id = "3",
                UserName = "user.one@labguide.com",
                NormalizedUserName = "USER.ONE@LABGUIDE.COM",
                Email = "user.one@labguide.com",
                NormalizedEmail = "USER.ONE@LABGUIDE.COM",
                FirstName = "User",
                LastName = "One",
                DateOfBirth = new DateTime(2006, 06, 06),
                Address = "Spoorwegstraat 4",
                PostalCode = 8000,
                City = "Brugge",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            var userTwo = new ApplicationUser
            {
                Id = "4",
                UserName = "user.two@labguide.com",
                NormalizedUserName = "USER.TWO@LABGUIDE.COM",
                Email = "user.two@labguide.com",
                NormalizedEmail = "USER.TWO@LABGUIDE.COM",
                FirstName = "User",
                LastName = "Two",
                DateOfBirth = new DateTime(2007, 07, 07),
                Address = "Spoorwegstraat 4",
                PostalCode = 8000,
                City = "Brugge",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            var userThree = new ApplicationUser
            {
                Id = "5",
                UserName = "user.three@labguide.com",
                NormalizedUserName = "USER.THREE@LABGUIDE.COM",
                Email = "user.three@labguide.com",
                NormalizedEmail = "USER.THREE@LABGUIDE.COM",
                FirstName = "User",
                LastName = "Three",
                DateOfBirth = new DateTime(2007, 07, 07),
                Address = "Spoorwegstraat 4",
                PostalCode = 8000,
                City = "Brugge",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            adminOne.PasswordHash = passwordHasher.HashPassword(adminOne, "admin1");
            adminTwo.PasswordHash = passwordHasher.HashPassword(adminTwo, "admin2");
            userOne.PasswordHash = passwordHasher.HashPassword(userOne, "user1");
            userTwo.PasswordHash = passwordHasher.HashPassword(userTwo, "user2");
            userThree.PasswordHash = passwordHasher.HashPassword(userThree, "user3");

            modelBuilder.Entity<ApplicationUser>().HasData(adminOne);
            modelBuilder.Entity<ApplicationUser>().HasData(adminTwo);
            modelBuilder.Entity<ApplicationUser>().HasData(userOne);
            modelBuilder.Entity<ApplicationUser>().HasData(userTwo);
            modelBuilder.Entity<ApplicationUser>().HasData(userThree);

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string> { Id = 1, UserId = "1", ClaimType = ClaimTypes.Role, ClaimValue = "admin" });
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string> { Id = 2, UserId = "2", ClaimType = ClaimTypes.Role, ClaimValue = "admin" });
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string> { Id = 3, UserId = "3", ClaimType = ClaimTypes.Role, ClaimValue = "user" });
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string> { Id = 4, UserId = "4", ClaimType = ClaimTypes.Role, ClaimValue = "user" });
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string> { Id = 5, UserId = "5", ClaimType = ClaimTypes.Role, ClaimValue = "user" });
            #endregion

            modelBuilder.Entity<Laboratory>().HasData
                (new Laboratory[]
                {
                    new Laboratory{Id = 1, Name = "AZ Sint-Lucas", Address = "Sint-Lucaslaan 18", City = "Brugge", PostalCode = 8310, Country = "België"},
                    new Laboratory{Id = 2, Name = "AZ Sint-Jan", Address = "Ruddershove 10", City = "Brugge", PostalCode = 8000, Country = "België"},
                    new Laboratory{Id = 3, Name = "UZ Gent", Address = "Corneel Heymanslaan 10", City = "Gent", PostalCode= 9000, Country="België"},
                    new Laboratory{Id = 4, Name = "UZ Brussel", Address = "Laarbeeklaan 101", City = "Jette", PostalCode = 1090, Country="België"},
                    new Laboratory{Id = 5, Name = "UZ Antwerpen", Address = "Drie eikenstraat 655", City = "Edegem", PostalCode = 2650, Country = "België"},
                    new Laboratory{Id = 6, Name = "AZ Zeno", Address = "Kalvekeetdijk 260", City = "Knokke-Heist", PostalCode = 8300, Country = "België"},
                    new Laboratory{Id = 7, Name = "AZ Alma", Address = "Ringlaan 15", City = "Eeklo", PostalCode = 9900, Country = "België"}
                });
            modelBuilder.Entity<ReferenceValue>().HasData
                (new ReferenceValue[]
                {   //Hemoglobine
                    new ReferenceValue{Id = 1, PropertyId = 1, MinimumValue = 14.5, MaximumValue = 22.0, Unit = "g/dl", MaximalAge = 1, Period = TimeReference.D},
                    new ReferenceValue{Id = 2, PropertyId = 1, MinimumValue = 14.0, MaximumValue = 22.0, Unit = "g/dL", MaximalAge = 1, Period = TimeReference.W},
                    new ReferenceValue{Id = 3, PropertyId = 1, MinimumValue = 12.5, MaximumValue = 20.0, Unit = "g/dL", MaximalAge = 2, Period = TimeReference.W},
                    new ReferenceValue{Id = 4, PropertyId = 1, MinimumValue = 11.0, MaximumValue = 18.0, Unit = "g/dL", MaximalAge = 1, Period = TimeReference.M},
                    new ReferenceValue{Id = 5, PropertyId = 1, MinimumValue = 10.0, MaximumValue = 13.5, Unit = "g/dL", MaximalAge = 6, Period = TimeReference.M},
                    new ReferenceValue{Id = 6, PropertyId = 1, MinimumValue = 10.5, MaximumValue = 13.5, Unit = "g/dL", MaximalAge = 2, Period = TimeReference.J},
                    new ReferenceValue{Id = 7, PropertyId = 1, MinimumValue = 11.0, MaximumValue = 14.0, Unit = "g/dL", MaximalAge = 6, Period = TimeReference.J},
                    new ReferenceValue{Id = 8, PropertyId = 1, MinimumValue = 11.5, MaximumValue = 15.5, Unit = "g/dL", MaximalAge = 12, Period = TimeReference.J},
                    new ReferenceValue{Id = 9, PropertyId = 1, MinimumValue = 13.0, MaximumValue = 17.0, Unit = "g/dL", MaximalAge = 18, Sex = "M", Period = TimeReference.J},
                    new ReferenceValue{Id = 10, PropertyId = 1, MinimumValue = 12.0, MaximumValue = 15.4, Unit = "g/dL", MaximalAge = 18, Sex = "F", Period = TimeReference.J},
                    new ReferenceValue{Id = 11, PropertyId = 1, MinimumValue = 13.2, MaximumValue = 16.8, Unit = "g/dL", Sex = "M"},
                    new ReferenceValue{Id = 12, PropertyId = 1, MinimumValue = 11.8, MaximumValue = 15.5, Unit = "g/dL", Sex = "F"},
                    //IJzer
                    new ReferenceValue{Id = 13, PropertyId = 2, MinimumValue = 65, MaximumValue = 175, Unit = "µg/dL", Sex = "M"},
                    new ReferenceValue{Id = 14, PropertyId = 2, MinimumValue = 50, MaximumValue = 170, Unit = "µg/dL", Sex = "F"},
                    //Transferrine
                    new ReferenceValue{Id = 15, PropertyId = 3, MinimumValue = 1.68, MaximumValue = 2.96, Unit = "g/L", Sex = "M"},
                    new ReferenceValue{Id = 16, PropertyId = 3, MinimumValue = 1.68, MaximumValue = 3.72, Unit = "g/L", Sex = "F"},
                    //Ferritine
                    new ReferenceValue{Id = 17, PropertyId = 4, MinimumValue = 22, MaximumValue = 322, Unit = "µg/dL", Sex = "M"},
                    new ReferenceValue{Id = 18, PropertyId = 4, MinimumValue = 10, MaximumValue = 291, Unit = "µg/dL", Sex = "F"},
                    //TSH
                    new ReferenceValue{Id = 19, PropertyId = 5, MinimumValue = 0.87, MaximumValue = 6.15, Unit = "mU/L", MaximalAge = 2, Period = TimeReference.J},
                    new ReferenceValue{Id = 20, PropertyId = 5, MinimumValue = 0.67, MaximumValue = 4.16, Unit = "mU/L", MaximalAge = 12, Period = TimeReference.J},
                    new ReferenceValue{Id = 21, PropertyId = 5, MinimumValue = 0.48, MaximumValue = 4.17, Unit = "mU/L", MaximalAge = 20, Period = TimeReference.J},
                    new ReferenceValue{Id = 22, PropertyId = 5, MinimumValue = 0.55, MaximumValue = 4.78, Unit = "mU/L" },
                    //FT3
                    new ReferenceValue{Id = 23, PropertyId = 6, MinimumValue = 5.10, MaximumValue = 8.00, Unit = "pmol/L", MaximalAge = 2, Period = TimeReference.J},
                    new ReferenceValue{Id = 24, PropertyId = 6, MinimumValue = 5.10, MaximumValue = 7.40, Unit = "pmol/L", MaximalAge = 12, Period = TimeReference.J},
                    new ReferenceValue{Id = 25, PropertyId = 6, MinimumValue = 4.70, MaximumValue = 7.20, Unit = "pmol/L", MaximalAge = 20, Period = TimeReference.J},
                    new ReferenceValue{Id = 26, PropertyId = 6, MinimumValue = 3.50, MaximumValue = 6.50, Unit = "pmol/L" },
                    //FT4
                    new ReferenceValue{Id = 27, PropertyId = 7, MinimumValue = 12.10, MaximumValue = 18.60, Unit = "pmol/L", MaximalAge = 2, Period = TimeReference.J},
                    new ReferenceValue{Id = 28, PropertyId = 7, MinimumValue = 11.10, MaximumValue = 18.10, Unit = "pmol/L", MaximalAge = 12, Period = TimeReference.J},
                    new ReferenceValue{Id = 29, PropertyId = 7, MinimumValue = 10.70, MaximumValue = 18.40, Unit = "pmol/L", MaximalAge = 20, Period = TimeReference.J},
                    new ReferenceValue{Id = 30, PropertyId = 7, MinimumValue = 11.50, MaximumValue = 22.70, Unit = "pmol/L" },
                    //ANCA - Alma
                    new ReferenceValue{Id = 31, PropertyId = 8, StringValue = "Negatief"},
                    //HBa1c - Zeno
                    new ReferenceValue{Id = 32, PropertyId = 9, MinimumValue = 3.9, MaximumValue = 6.2, Unit = "%"},
                    //Anti-cardiolipine IgG - UZ Gent
                    new ReferenceValue{Id = 33, PropertyId = 10, MaximumValue = 20.0, Unit = "U/mL"},
                });
            modelBuilder.Entity<RequestDefinition>().HasData
                (new RequestDefinition[]
                {
                    new RequestDefinition{Id = 1, BillingCode = 127013}, // HB
                    new RequestDefinition{Id = 2, BillingCode = 540551, CumulationRule = "IJzer afzonderlijk en ijzer met ijzerbindend vermogen (apart nomenclatuurnummer) mogen onderling niet gecumuleerd worden."}, // IJzer
                    new RequestDefinition{Id = 3, BillingCode = 541030, CumulationRule = "IJzer met ijzerbindend vermogen en transferrine mogen onderling niet gecumuleerd worden."}, // Transferrine                   
                    new RequestDefinition{Id = 4, BillingCode = 541472, CumulationRule = "Ferritine: geen cumul van RIA-techniek met andere techniek."}, // Ferritine
                    new RequestDefinition{Id = 5, BillingCode = 546173, CumulationRule = "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG"}, // TSH
                    new RequestDefinition{Id = 6, BillingCode = 546276, CumulationRule = "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG"}, // FT4
                    new RequestDefinition{Id = 7, BillingCode = 546291, CumulationRule = "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG"}, // FT3
                    new RequestDefinition{Id = 8, BillingCode = 556371}, // ANCA
                    new RequestDefinition{Id = 9, BillingCode = 540750, DiagnoseRule = "Doseren van glycohemoglobine in hemolysaat mag enkel aangerekend worden voor een patiënt met diabetes mellitus, mucoviscidose of chronische pancreatitis.", CumulationRule = "Geglycosyleerd hemoglobine of fructosamine mogen niet onderling gecumuleerd worden."}, // HbA1c
                    new RequestDefinition{Id = 10, BillingCode = 554433, DiagnoseRule = "In geval van aanwezigheid klinische criteria antifosfolipidensyndroom (vasculaire trombose en/ of miskraam) of systemische luypus erythematodes."} // Anti-cardiolipine IgG
                });
            modelBuilder.Entity<Specimen>().HasData
                (new Specimen[]
                {
                    new Specimen{Id = 1, Name = "EDTA-plasma", Image = "edta.jpg"},
                    new Specimen{Id = 2, Name = "EDTA-volbloed", Image = "edta.jpg"},
                    new Specimen{Id = 3, Name = "Serum", Image = "serum.jpg"},
                    new Specimen{Id = 4, Name = "Citraatplasma", Image = "citraat.jpg"}
                });
            modelBuilder.Entity<StorageCondition>().HasData
                (new StorageCondition[]
                {
                    //Hemoglobine
                    new StorageCondition{Id = 1, Temperature = "20°C", TimePeriod = 4, TimeReference = TimeReference.U},
                    //IJzer
                    new StorageCondition{Id = 2, Temperature = "20°C", TimePeriod = 4, TimeReference = TimeReference.D},
                    new StorageCondition{Id = 3, Temperature = "2 - 8°C", TimePeriod = 7, TimeReference = TimeReference.D},
                    new StorageCondition{Id = 4, Temperature = "-20°C", TimePeriod = 60, TimeReference = TimeReference.D },
                    //Transferrine
                    new StorageCondition{Id = 5, Temperature = "20°C", TimePeriod = 8, TimeReference = TimeReference.U},
                        // 7 dagen bij 2 - 8 °C, dus SC.ID = 2
                    new StorageCondition{Id = 6, Temperature = "-20°C", TimePeriod = 1, TimeReference = TimeReference.M},
                    new StorageCondition{Id = 7, Temperature = "-70°C", TimePeriod = 1, TimeReference= TimeReference.J },
                    //Ferritine
                        // 8u bij 20°C, dus SC.ID = 5
                        // 7d bij 2 - 8°C, dus SC.ID = 2
                    new StorageCondition{Id = 8, Temperature = "-20°C", TimePeriod = 3, TimeReference = TimeReference.M},
                    //TSH
                    new StorageCondition{Id = 9, Temperature = "20°C", TimePeriod = 1, TimeReference = TimeReference.D},
                        // 7d bij 2 - 8°C, dus SC.ID = 2
                        // 1m bij -20°C, dus SC.ID = 6
                    //FT3
                        // 8u bij 20°C, dus SC.ID = 5
                    new StorageCondition {Id = 10, Temperature = "2 - 8°C", TimePeriod = 8, TimeReference = TimeReference.U},
                    new StorageCondition {Id = 11, Temperature = "-20°C", TimePeriod = 2, TimeReference = TimeReference.D},
                    //FT4
                        // 8u bij 20°C, dus SC.ID = 5
                    new StorageCondition {Id = 12, Temperature = "2 - 8°C", TimePeriod = 2, TimeReference = TimeReference.D},
                        // 3m bij -20°c, dus SC.ID = 8
                    //HbA1c
                        // geen
                    //ANCA
                        // geen
                    //ACA
                        // 8u bij 20°C, dus SC.ID = 5
                        // 1m bij -20°C, dus SC.ID = 6
                });
            modelBuilder.Entity<Property>().HasData
                (new Property[]
                {
                    //Hemoglobine
                    new Property{Id = 1, Name = "Hemoglobine", Synonym = "Haemoglobine", LaboratoryId = 1, RequestCode = "100", RequestDefinitionId = 1, SpecimenId = 2, TurnAroundTime = 10, TimePeriod = TimeReference.Min},
                    //IJzer
                    new Property{Id = 2, Name = "IJzer", LaboratoryId = 1, RequestCode = "221", RequestDefinitionId = 2, SpecimenId = 3, TurnAroundTime = 60, TimePeriod = TimeReference.Min},
                    //Transferrine
                    new Property{Id = 3, Name = "Transferrine", LaboratoryId = 1, RequestCode = "222", RequestDefinitionId = 3, SpecimenId = 3, TurnAroundTime = 60, TimePeriod = TimeReference.Min},
                    //Ferritine
                    new Property{Id = 4, Name = "Ferritine", LaboratoryId = 1, RequestCode = "224", RequestDefinitionId = 4, SpecimenId = 3, TurnAroundTime = 60, TimePeriod = TimeReference.Min},
                    //TSH
                    new Property{Id = 5, Name = "TSH", Synonym = "Thyroïd stimulerend hormoon", LaboratoryId = 1, RequestCode = "401", RequestDefinitionId = 5, SpecimenId = 3, TurnAroundTime = 120, TimePeriod = TimeReference.Min}, 
                    //FT3
                    new Property{Id = 6, Name = "Vrij T3", Synonym = "FT3", LaboratoryId = 1, RequestCode = "413", RequestDefinitionId = 6, SpecimenId = 3, TurnAroundTime = 120, TimePeriod = TimeReference.Min},
                    //FT4
                    new Property{Id = 7, Name = "Vrij T4", Synonym = "FT4", LaboratoryId = 1, RequestCode = "412", RequestDefinitionId = 7, SpecimenId = 3, TurnAroundTime = 120, TimePeriod = TimeReference.Min},
                    //HbA1c
                    new Property{Id = 8, Name = "Hemoglobine A1c", Synonym = "HbA1c", LaboratoryId = 6, RequestCode = "280", RequestDefinitionId = 8, SpecimenId = 2, TurnAroundTime = 24, TimePeriod = TimeReference.U},
                    //ANCA
                    new Property{Id = 9, Name = "ANCA",Synonym = "Antineutrofiele cytoplasmatische antistoffen", LaboratoryId = 7, RequestCode = "514", RequestDefinitionId = 9, SpecimenId = 3, TurnAroundTime = 1, TimePeriod = TimeReference.W},
                    //ACA
                    new Property{Id = 10, Name = "ACA IgG", Synonym ="Anticardiolipine A IgG", LaboratoryId = 3, RequestCode = "V_ACA-IgG", RequestDefinitionId = 10, SpecimenId = 4, TurnAroundTime = 1, TimePeriod = TimeReference.W}
                });
            modelBuilder.Entity($"{nameof(Property)}{nameof(StorageCondition)}").HasData
                (new[]
                {
                    new {PropertiesId = 1, StorageConditionsId = 1},
                    new {PropertiesId = 2, StorageConditionsId = 2},
                    new {PropertiesId = 2, StorageConditionsId = 3},
                    new {PropertiesId = 2, StorageConditionsId = 4},
                    new {PropertiesId = 3, StorageConditionsId = 2},
                    new {PropertiesId = 3, StorageConditionsId = 5},
                    new {PropertiesId = 3, StorageConditionsId = 6},
                    new {PropertiesId = 3, StorageConditionsId = 7},
                    new {PropertiesId = 4, StorageConditionsId = 2},
                    new {PropertiesId = 4, StorageConditionsId = 5},
                    new {PropertiesId = 4, StorageConditionsId = 8},
                    new {PropertiesId = 5, StorageConditionsId = 2},
                    new {PropertiesId = 5, StorageConditionsId = 6},
                    new {PropertiesId = 5, StorageConditionsId = 9},
                    new {PropertiesId = 6, StorageConditionsId = 5},
                    new {PropertiesId = 6, StorageConditionsId = 10},
                    new {PropertiesId = 6, StorageConditionsId = 11},
                    new {PropertiesId = 7, StorageConditionsId = 5},
                    new {PropertiesId = 7, StorageConditionsId = 8},
                    new {PropertiesId = 7, StorageConditionsId = 12},
                    new {PropertiesId = 10, StorageConditionsId = 5},
                    new {PropertiesId = 10, StorageConditionsId = 6},
                });
        }
    }
}
