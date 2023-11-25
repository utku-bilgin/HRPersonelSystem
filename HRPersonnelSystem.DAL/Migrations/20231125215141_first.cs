using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRPersonnelSystem.DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") });

            migrationBuilder.UpdateData(
                table: "AdvancePayment",
                keyColumn: "Id",
                keyValue: new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 346, DateTimeKind.Local).AddTicks(5886), new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"),
                column: "ConcurrencyStamp",
                value: "828b63f5-9de5-4dab-8405-e3cfcc47f704");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"),
                column: "ConcurrencyStamp",
                value: "20afc760-7a5f-44ba-8a2a-3bdecfa74d12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"),
                column: "ConcurrencyStamp",
                value: "32df2707-01d7-4945-b413-999b596c5a45");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1985, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "b13e0425-7be9-4f74-96b2-6c735cd8088a", new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEIjp/4250dQj0obljCaMmTW/0Z2xOrrRwmVg+2LcEpouls5NrzKjj1653WohStH8Kg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"),
                columns: new[] { "CompanyDirector_BirthDate", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1978, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cd4a818d-bc89-4972-93dd-f23940da1bc3", new DateTime(2011, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEGSlOv7wzkADLOoesuYv2B+c0eQfmWedh77PCA/PS/mQpbOJtyc5nEkicpwMDn4mHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "CompanyDirector_BirthDate", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1991, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "612486cf-4219-4fe8-89cf-da13ca61f53c", new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEEAe+9Wk9+y1ZOVMVTaNuw8dIJqMse5oMP+09JhRlgrVNpn//Lj/RZK1K29Z89erPw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"),
                columns: new[] { "Employee_BirthDate", "Employee_CompanyId", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1994, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"), "db1e9798-d2ef-4d95-9fc1-955688c1cee9", new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEMQ9iIwjgpye6VmNZwKroFYhoWv5ai++Vw818qeCPsejN961iU4Fmk4XbJR1gxmpXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"),
                columns: new[] { "Employee_BirthDate", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1998, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "8d62c450-75a2-4943-ba12-55d2bf197327", new DateTime(2023, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEElX26pqXeoeuwCnbkWhCy5oMtU9UT38VOY82qWiwwk6dxNYSpZuevXJFD9PHE2T9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"),
                columns: new[] { "Employee_BirthDate", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1997, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "bc3eb02d-9e7c-4772-ae8e-54f3dd159e09", new DateTime(2021, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEOhrbFQeZz9fH6wx4TwzSUnHLGhTamN1pzNQvqaLhXXZ2pKxmrvB38ti2i3BA5PQUA==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2025, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2462), new DateTime(2023, 3, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2461), new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2449), new DateTime(1998, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2467), new DateTime(2023, 10, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2466), new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2463), new DateTime(2018, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("2ffbe4d4-c782-4a19-bd89-0a8624bed3ee"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 346, DateTimeKind.Local).AddTicks(7057), new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("3397bff8-1261-4603-8965-9d596246e4b8"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 346, DateTimeKind.Local).AddTicks(7010), new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("230ae8d2-be96-40bf-8639-566de6ba3a73"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3872), new DateTime(2024, 2, 24, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3874), new DateTime(2024, 3, 5, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("305ef3c8-fc05-46b2-b054-c49ad270be26"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3856), new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3867), new DateTime(2023, 12, 16, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3865) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("38b5f216-c008-4e81-9cac-337f8ad7e283"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3883), new DateTime(2024, 8, 22, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3884), new DateTime(2024, 8, 27, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("702dabb3-d6d4-4ec0-a6f1-ae329c81b649"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3880), new DateTime(2024, 9, 21, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3881), new DateTime(2024, 10, 16, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("736b4a73-d1e5-4c87-80b7-8584824b4e57"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3890), new DateTime(2024, 6, 11, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3891), new DateTime(2024, 6, 13, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("7fe8e741-7e57-41ea-ae05-1697b1c18f77"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3876), new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3878), new DateTime(2023, 11, 26, 0, 51, 40, 354, DateTimeKind.Local).AddTicks(3877) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c") });

            migrationBuilder.UpdateData(
                table: "AdvancePayment",
                keyColumn: "Id",
                keyValue: new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(3040), new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"),
                column: "ConcurrencyStamp",
                value: "a00a25e8-9f1c-45e6-b764-92d915a066b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"),
                column: "ConcurrencyStamp",
                value: "16d3ffcf-3b19-40a0-bfd4-e324d2a6be6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"),
                column: "ConcurrencyStamp",
                value: "96ad3314-c99f-4c24-bb9d-9f7f54157f1f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"),
                columns: new[] { "BirthDate", "ConcurrencyStamp", "DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1985, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "cda878d0-54cc-44c0-9fb7-4570b693121f", new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEBK5eQC9FdJ1D5CAQBdiNVH3w40Jj2ZzPrWD++T9aBL57BeJRbSG+Hc3Eby8g3y3qQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"),
                columns: new[] { "CompanyDirector_BirthDate", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1978, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "5478defd-d923-4719-904a-17a743dfea60", new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEKz+FOyO99mnaZJPZXxV61LjODz9dsHAF8eNH8Eiz1OfDeLluKPnfO40d2RVhj6Ahg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "CompanyDirector_BirthDate", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1991, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "7558e84d-b2e5-4651-9645-fd8df181082d", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEJP02qo1Y3XoPeBhTWuNvTnRqOl3xJk4HBjt1CyTjGh7nU6yhMTItmbx8Ubyt/RkyA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"),
                columns: new[] { "Employee_BirthDate", "Employee_CompanyId", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1994, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "1fd278ea-ce73-476c-aeac-378e4b4927d8", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEAFP1mjyMkTndZce3Teo5PPUDLCqUiLEzmYbyXroZW8i+YSEa4hRTQct/hGUlp2YCw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"),
                columns: new[] { "Employee_BirthDate", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1998, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "e8f62583-4649-421a-b1e2-4ca64b9e9518", new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEKhdH027KUnQuMrpLDDXZo2ekffJmbmD61Iq7BwZNYwEGh/A9iffxuoz3xit2lJxLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"),
                columns: new[] { "Employee_BirthDate", "ConcurrencyStamp", "Employee_DateOfHire", "PasswordHash" },
                values: new object[] { new DateTime(1997, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "4189a7c3-e7b5-494e-9c2d-b26b7f12f361", new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEIpu18BsLQNDSav05/KVD1r1b1gtcZ8pY3V0qCDtHa+s9coyvPyB3D0MjCvTaFzNbA==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2025, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3054), new DateTime(2023, 2, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3049), new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3026), new DateTime(1998, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3044) });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2024, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3107), new DateTime(2023, 9, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3105), new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3096), new DateTime(2018, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("2ffbe4d4-c782-4a19-bd89-0a8624bed3ee"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(4369), new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("3397bff8-1261-4603-8965-9d596246e4b8"),
                columns: new[] { "CreatedDate", "RequestDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(4244), new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("230ae8d2-be96-40bf-8639-566de6ba3a73"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5779), new DateTime(2024, 1, 16, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5784), new DateTime(2024, 1, 26, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5782) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("305ef3c8-fc05-46b2-b054-c49ad270be26"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5720), new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5752), new DateTime(2023, 11, 7, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("38b5f216-c008-4e81-9cac-337f8ad7e283"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5874), new DateTime(2024, 7, 14, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5879), new DateTime(2024, 7, 19, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5877) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("702dabb3-d6d4-4ec0-a6f1-ae329c81b649"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5802), new DateTime(2024, 8, 13, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5806), new DateTime(2024, 9, 7, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("736b4a73-d1e5-4c87-80b7-8584824b4e57"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5886), new DateTime(2024, 5, 3, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5892), new DateTime(2024, 5, 5, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("7fe8e741-7e57-41ea-ae05-1697b1c18f77"),
                columns: new[] { "CreatedDate", "RequestDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5791), new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5795), new DateTime(2023, 10, 18, 20, 28, 8, 805, DateTimeKind.Local).AddTicks(5794) });
        }
    }
}
