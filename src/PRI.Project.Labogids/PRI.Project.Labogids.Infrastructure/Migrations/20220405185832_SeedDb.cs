using Microsoft.EntityFrameworkCore.Migrations;

namespace PRI.Project.Labogids.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Laboratories",
                columns: new[] { "Id", "Address", "City", "Country", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Sint-Lucaslaan 18", "Brugge", "België", "AZ Sint-Lucas", 8310 },
                    { 2, "Ruddershove 10", "Brugge", "België", "AZ Sint-Jan", 8000 },
                    { 3, "Corneel Heymanslaan 10", "Gent", "België", "UZ Gent", 9000 },
                    { 4, "Laarbeeklaan 101", "Jette", "België", "UZ Brussel", 1090 },
                    { 5, "Drie eikenstraat 655", "Edegem", "België", "UZ Antwerpen", 2650 },
                    { 6, "Kalvekeetdijk 260", "Knokke-Heist", "België", "AZ Zeno", 8300 },
                    { 7, "Ringlaan 15", "Eeklo", "België", "AZ Alma", 9900 }
                });

            migrationBuilder.InsertData(
                table: "RequestDefinitions",
                columns: new[] { "Id", "BillingCode", "CumulationRule", "DiagnoseRule", "Name" },
                values: new object[,]
                {
                    { 9, 540750, "Geglycosyleerd hemoglobine of fructosamine mogen niet onderling gecumuleerd worden.", "Doseren van glycohemoglobine in hemolysaat mag enkel aangerekend worden voor een patiënt met diabetes mellitus, mucoviscidose of chronische pancreatitis.", null },
                    { 8, 556371, null, null, null },
                    { 7, 546291, "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG", null, null },
                    { 6, 546276, "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG", null, null },
                    { 10, 554433, null, "In geval van aanwezigheid klinische criteria antifosfolipidensyndroom (vasculaire trombose en/ of miskraam) of systemische luypus erythematodes.", null },
                    { 4, 541472, "Ferritine: geen cumul van RIA-techniek met andere techniek.", null, null },
                    { 3, 541030, "IJzer met ijzerbindend vermogen en transferrine mogen onderling niet gecumuleerd worden.", null, null },
                    { 2, 540551, "IJzer afzonderlijk en ijzer met ijzerbindend vermogen (apart nomenclatuurnummer) mogen onderling niet gecumuleerd worden.", null, null },
                    { 1, 127013, null, null, null },
                    { 5, 546173, "Maximum twee van TSH, FT4, T4 en T3RU, T4 en TBG, FT3, T3 en T3RU, FT3 en TBG", null, null }
                });

            migrationBuilder.InsertData(
                table: "Specimens",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "EDTA-plasma" },
                    { 2, null, "EDTA-volbloed" },
                    { 3, null, "Serum" },
                    { 4, null, "Citraatplasma" }
                });

            migrationBuilder.InsertData(
                table: "StorageConditions",
                columns: new[] { "Id", "Name", "Temperature", "TimePeriod", "TimeReference" },
                values: new object[,]
                {
                    { 10, null, "2 - 8°C", 8, 1 },
                    { 9, null, "20°C", 1, 2 },
                    { 8, null, "-20°C", 3, 4 },
                    { 7, null, "-70°C", 1, 5 },
                    { 6, null, "-20°C", 1, 4 },
                    { 2, null, "20°C", 4, 2 },
                    { 4, null, "-20°C", 60, 2 },
                    { 3, null, "2 - 8°C", 7, 2 },
                    { 1, null, "20°C", 4, 1 },
                    { 11, null, "-20°C", 2, 2 },
                    { 5, null, "20°C", 8, 1 },
                    { 12, null, "2 - 8°C", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "LaboratoryId", "Name", "RequestCode", "RequestDefinitionId", "SpecimenId", "Synonym", "TimePeriod", "TurnAroundTime" },
                values: new object[,]
                {
                    { 1, 1, "Hemoglobine", "100", 1, 2, "Haemoglobine", 0, 10 },
                    { 8, 6, "Hemoglobine A1c", "280", 8, 2, "HbA1c", 1, 24 },
                    { 2, 1, "IJzer", "221", 2, 3, null, 0, 60 },
                    { 3, 1, "Transferrine", "222", 3, 3, null, 0, 60 },
                    { 4, 1, "Ferritine", "224", 4, 3, null, 0, 60 },
                    { 5, 1, "TSH", "401", 5, 3, "Thyroïd stimulerend hormoon", 0, 120 },
                    { 6, 1, "Vrij T3", "413", 6, 3, "FT3", 0, 120 },
                    { 7, 1, "Vrij T4", "412", 7, 3, "FT4", 0, 120 },
                    { 9, 7, "ANCA", "514", 9, 3, "Antineutrofiele cytoplasmatische antistoffen", 3, 1 },
                    { 10, 3, "ACA IgG", "V_ACA-IgG", 10, 4, "Anticardiolipine A IgG", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "PropertyStorageCondition",
                columns: new[] { "PropertiesId", "StorageConditionsId" },
                values: new object[,]
                {
                    { 4, 2 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 10, 5 },
                    { 4, 5 },
                    { 4, 8 },
                    { 5, 2 },
                    { 5, 6 },
                    { 5, 9 },
                    { 6, 5 },
                    { 6, 10 },
                    { 6, 11 },
                    { 7, 5 },
                    { 7, 8 },
                    { 7, 12 },
                    { 3, 2 },
                    { 2, 4 },
                    { 10, 6 },
                    { 2, 2 },
                    { 1, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "ReferenceValues",
                columns: new[] { "Id", "MaximalAge", "MaximumValue", "MinimumValue", "Name", "Period", "PropertyId", "Sex", "StringValue", "Unit" },
                values: new object[,]
                {
                    { 15, 0, 2.96, 1.6799999999999999, null, 0, 3, "M", null, "g/L" },
                    { 25, 20, 7.2000000000000002, 4.7000000000000002, null, 5, 6, null, null, "pmol/L" },
                    { 26, 0, 6.5, 3.5, null, 0, 6, null, null, "pmol/L" },
                    { 7, 6, 14.0, 11.0, null, 5, 1, null, null, "g/dL" },
                    { 6, 2, 13.5, 10.5, null, 5, 1, null, null, "g/dL" },
                    { 5, 6, 13.5, 10.0, null, 4, 1, null, null, "g/dL" },
                    { 27, 2, 18.600000000000001, 12.1, null, 5, 7, null, null, "pmol/L" },
                    { 29, 20, 18.399999999999999, 10.699999999999999, null, 5, 7, null, null, "pmol/L" },
                    { 30, 0, 22.699999999999999, 11.5, null, 0, 7, null, null, "pmol/L" },
                    { 4, 1, 18.0, 11.0, null, 4, 1, null, null, "g/dL" },
                    { 3, 2, 20.0, 12.5, null, 3, 1, null, null, "g/dL" },
                    { 2, 1, 22.0, 14.0, null, 3, 1, null, null, "g/dL" },
                    { 32, 0, 6.2000000000000002, 3.8999999999999999, null, 0, 9, null, null, "%" },
                    { 33, 0, 20.0, 0.0, null, 0, 10, null, null, "U/mL" },
                    { 28, 12, 18.100000000000001, 11.1, null, 5, 7, null, null, "pmol/L" },
                    { 24, 12, 7.4000000000000004, 5.0999999999999996, null, 5, 6, null, null, "pmol/L" },
                    { 8, 12, 15.5, 11.5, null, 5, 1, null, null, "g/dL" },
                    { 9, 18, 17.0, 13.0, null, 5, 1, "M", null, "g/dL" },
                    { 10, 18, 15.4, 12.0, null, 5, 1, "F", null, "g/dL" },
                    { 22, 0, 4.7800000000000002, 0.55000000000000004, null, 0, 5, null, null, "mU/L" }
                });

            migrationBuilder.InsertData(
                table: "ReferenceValues",
                columns: new[] { "Id", "MaximalAge", "MaximumValue", "MinimumValue", "Name", "Period", "PropertyId", "Sex", "StringValue", "Unit" },
                values: new object[,]
                {
                    { 21, 20, 4.1699999999999999, 0.47999999999999998, null, 5, 5, null, null, "mU/L" },
                    { 20, 12, 4.1600000000000001, 0.67000000000000004, null, 5, 5, null, null, "mU/L" },
                    { 19, 2, 6.1500000000000004, 0.87, null, 5, 5, null, null, "mU/L" },
                    { 11, 0, 16.800000000000001, 13.199999999999999, null, 0, 1, "M", null, "g/dL" },
                    { 12, 0, 15.5, 11.800000000000001, null, 0, 1, "F", null, "g/dL" },
                    { 18, 0, 291.0, 10.0, null, 0, 4, "F", null, "µg/dL" },
                    { 17, 0, 322.0, 22.0, null, 0, 4, "M", null, "µg/dL" },
                    { 31, 0, 0.0, 0.0, null, 0, 8, null, "Negatief", null },
                    { 13, 0, 175.0, 65.0, null, 0, 2, "M", null, "µg/dL" },
                    { 14, 0, 170.0, 50.0, null, 0, 2, "F", null, "µg/dL" },
                    { 16, 0, 3.7200000000000002, 1.6799999999999999, null, 0, 3, "F", null, "g/L" },
                    { 23, 2, 8.0, 5.0999999999999996, null, 5, 6, null, null, "pmol/L" },
                    { 1, 1, 22.0, 14.5, null, 2, 1, null, null, "g/dl" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "PropertyStorageCondition",
                keyColumns: new[] { "PropertiesId", "StorageConditionsId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StorageConditions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RequestDefinitions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
