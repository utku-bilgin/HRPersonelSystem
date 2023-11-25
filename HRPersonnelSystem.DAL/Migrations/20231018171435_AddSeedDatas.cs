using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRPersonnelSystem.DAL.Migrations
{
    public partial class AddSeedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdvancePayment",
                keyColumn: "Id",
                keyValue: new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 14, 33, 383, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"),
                column: "ConcurrencyStamp",
                value: "13e658f7-fc79-4888-8129-559041275e4a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"),
                column: "ConcurrencyStamp",
                value: "03ac2b0c-e7d9-48df-a8b9-1139f4e741fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"),
                column: "ConcurrencyStamp",
                value: "9287bd34-de46-4fd3-8c94-737b64136bce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "341dd073-73a0-4d5d-8c34-8a744dc614a1", "AQAAAAEAACcQAAAAEKXq+f5DQwLWgCe72/aTYkYMVcZbDcoI33DmYgzNbBoxQu+5WlmbMHC/otIPAjMAkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "590c8ffa-cb4f-4d60-b781-f2965867583d", "AQAAAAEAACcQAAAAEEm+rnqOjy2gPdeLQCqk8ao9yfzZ0LaoCCNa5pCaw1DrgixXSNojimqS9ZyRHAToOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07c424e1-40af-4f8c-8fb0-e7160fda87ba", "AQAAAAEAACcQAAAAECy50a82l0UMDZmOHMqnwhFpuGFNmG+9kxCn8SBALcnwm2cOT9MOPFmSfRbUWtGHuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8778a3cc-48db-490f-b10d-2226b959706d", "AQAAAAEAACcQAAAAEK0za8OXK9q3NTZBLmmuVvDQex1YYff13X/ix0TkMzhqrkqhOOEEsq/XTbvFpOzxgA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Employee_Address", "Employee_BirthDate", "Employee_BirthPlace", "Employee_CompanyId", "ConcurrencyStamp", "Employee_DateOfHire", "Employee_DateOfTermination", "Employee_Department", "Discriminator", "Email", "EmailConfirmed", "Employee_FirstName", "Employee_Gender", "Employee_ImagePath", "Employee_IsActive", "Employee_Job", "Employee_LastName", "LockoutEnabled", "LockoutEnd", "Employee_MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Employee_Salary", "Employee_SecondLastName", "SecurityStamp", "Employee_TCNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"), 0, " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​", new DateTime(1994, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "İzmir", new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "1897c0dd-8784-4fb1-9948-72dce652857a", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software", "Employee", "sinem.unal@bilgeadamboost.com", true, "Sinem", 0, "Sinem.jpg", true, "Developer", "Ünal", false, null, null, "SINEM.UNAL@BILGEADAMBOOST.COM", "SINEM.UNAL@BILGEADAMBOOST.COM", "AQAAAAEAACcQAAAAEL78jAQOWmk6iUw/Y+Ig1mFVos3wAWE3m0Iv2qyrkT14tt1kR1Cp9TDrLlTKp2EcHQ==", "05001905122", true, 37000.0, null, "1", "92345678919", false, "sinem.unal@bilgeadamboost.com" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2025, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(558), new DateTime(2023, 2, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(554), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(527), new DateTime(1998, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "CompanyName", "CompanyTitle", "ContractEndDate", "ContractStartDate", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "ImagePath", "IsActive", "IsDeleted", "MersisNumber", "ModifiedBy", "ModifiedDate", "NumberOfEmployees", "Phone", "TaxNumber", "TaxOffice", "YearOfEstablishment" },
                values: new object[] { new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"), "Büyükyali merkez mh. onbir sk. No : 20 Saat Plaza. Çekmeköy / Istanbul", "Dijital Teknoloji", "LTD.ŞTI.", new DateTime(2024, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(575), new DateTime(2023, 9, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(573), "Admin", new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(565), null, null, "info@dijitalteknoloji.com", "Dijital.jpg", true, false, "0490000911900015", null, null, 20, "0212 473 99 99", "4900009119", "Aksaray V.D", new DateTime(2018, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("2ffbe4d4-c782-4a19-bd89-0a8624bed3ee"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 14, 33, 383, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("3397bff8-1261-4603-8965-9d596246e4b8"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 14, 33, 383, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("230ae8d2-be96-40bf-8639-566de6ba3a73"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3030), new DateTime(2024, 1, 16, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3034), new DateTime(2024, 1, 26, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3033) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("305ef3c8-fc05-46b2-b054-c49ad270be26"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(2979), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(2991), new DateTime(2023, 11, 7, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("38b5f216-c008-4e81-9cac-337f8ad7e283"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3065), new DateTime(2024, 7, 14, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3068), new DateTime(2024, 7, 19, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3067) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("702dabb3-d6d4-4ec0-a6f1-ae329c81b649"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3052), new DateTime(2024, 8, 13, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3058), new DateTime(2024, 9, 7, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3055) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("736b4a73-d1e5-4c87-80b7-8584824b4e57"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3076), new DateTime(2024, 5, 3, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3081), new DateTime(2024, 5, 5, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3079) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("7fe8e741-7e57-41ea-ae05-1697b1c18f77"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3042), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3046), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(3045) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyDirector_Address", "CompanyDirector_BirthDate", "CompanyDirector_BirthPlace", "CompanyId", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "CompanyDirector_DateOfTermination", "CompanyDirector_Department", "Discriminator", "Email", "EmailConfirmed", "CompanyDirector_FirstName", "CompanyDirector_Gender", "CompanyDirector_ImagePath", "CompanyDirector_IsActive", "CompanyDirector_Job", "CompanyDirector_LastName", "LockoutEnabled", "LockoutEnd", "CompanyDirector_MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "CompanyDirector_Salary", "CompanyDirector_SecondLastName", "SecurityStamp", "CompanyDirector_TCNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"), 0, "Pusula Mah. Çıkmaz Sok. No:18 Kızılay/Ankara", new DateTime(1978, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakkari", new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"), "153269f9-55e9-416e-9f82-fad80589e659", new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilişim Teknojileri", "CompanyDirector", "seyma.acik@bilgeadamboost.com", true, "Şeyma", 0, "Seyma.jpg", true, "Ekip Lideri", "Açık", false, null, null, "SEYMA.ACIK@BILGEADAMBOOST.COM", "SEYMA.ACIK@BILGEADAMBOOST.COM", "AQAAAAEAACcQAAAAEAaN3ECUav35i22ocQfgAI5ADotiWCoXGrQzXeUt804QJGgVS4K/4hlxOcYEb+hdyQ==", "0522222200", true, 51000.0, null, "1", "12345678919", false, "seyma.acik@bilgeadamboost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"));

            migrationBuilder.UpdateData(
                table: "AdvancePayment",
                keyColumn: "Id",
                keyValue: new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"),
                column: "ConcurrencyStamp",
                value: "78251fcb-3a01-4e55-b0aa-1f6652dab181");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"),
                column: "ConcurrencyStamp",
                value: "953ab15f-0739-430f-b922-71d47965a256");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"),
                column: "ConcurrencyStamp",
                value: "7aab2df0-9fa9-404c-8dd3-7ccf4f745298");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc8b64d5-3b50-4cf0-8ab9-161e34dba91d", "AQAAAAEAACcQAAAAEDn6OIY52YoN+mUTpt13jXqACQRRnHqeTS7xHBoSxv56wMqZM0ZhYLzXqh/4Hss44A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b83c2747-f59b-4811-917a-178d174fa5f8", "AQAAAAEAACcQAAAAECjwxUYo3zZk5xkLB+IzmtdaCwjl+Rf7rr28qFFssowRY+hSl1AhFO+OJOpFBHUr0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fbe172f-f005-4688-b29b-c1f423696851", "AQAAAAEAACcQAAAAEDeR4uXwJ1Xdg5upZntp1MG7egardw5b1m5bsLdcp+6GL+iYe3CfmP02sdXWHQinIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a614f822-f19d-42e3-beef-0bfef414c67e", "AQAAAAEAACcQAAAAEO5HxusDSaTVmHFDRXTukrhgmQYvMBpiqd7QymHCWreNWpJ+hiQZm2wNo4xoDXjwIg==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2025, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3036), new DateTime(2023, 2, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3033), new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3011), new DateTime(1998, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3031) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("2ffbe4d4-c782-4a19-bd89-0a8624bed3ee"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("3397bff8-1261-4603-8965-9d596246e4b8"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("230ae8d2-be96-40bf-8639-566de6ba3a73"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5909), new DateTime(2024, 1, 16, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 1, 26, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("305ef3c8-fc05-46b2-b054-c49ad270be26"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5881), new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5891), new DateTime(2023, 11, 7, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("38b5f216-c008-4e81-9cac-337f8ad7e283"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5937), new DateTime(2024, 7, 14, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5941), new DateTime(2024, 7, 19, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("702dabb3-d6d4-4ec0-a6f1-ae329c81b649"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5927), new DateTime(2024, 8, 13, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5932), new DateTime(2024, 9, 7, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("736b4a73-d1e5-4c87-80b7-8584824b4e57"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5946), new DateTime(2024, 5, 3, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5949), new DateTime(2024, 5, 5, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("7fe8e741-7e57-41ea-ae05-1697b1c18f77"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5919), new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5922), new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5921) });
        }
    }
}
