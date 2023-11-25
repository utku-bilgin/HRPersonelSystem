using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRPersonnelSystem.DAL.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdvancePayment",
                keyColumn: "Id",
                keyValue: new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(3040));

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
                values: new object[,]
                {
                    { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") },
                    { new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cda878d0-54cc-44c0-9fb7-4570b693121f", "AQAAAAEAACcQAAAAEBK5eQC9FdJ1D5CAQBdiNVH3w40Jj2ZzPrWD++T9aBL57BeJRbSG+Hc3Eby8g3y3qQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5478defd-d923-4719-904a-17a743dfea60", "AQAAAAEAACcQAAAAEKz+FOyO99mnaZJPZXxV61LjODz9dsHAF8eNH8Eiz1OfDeLluKPnfO40d2RVhj6Ahg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7558e84d-b2e5-4651-9645-fd8df181082d", "AQAAAAEAACcQAAAAEJP02qo1Y3XoPeBhTWuNvTnRqOl3xJk4HBjt1CyTjGh7nU6yhMTItmbx8Ubyt/RkyA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fd278ea-ce73-476c-aeac-378e4b4927d8", "AQAAAAEAACcQAAAAEAFP1mjyMkTndZce3Teo5PPUDLCqUiLEzmYbyXroZW8i+YSEa4hRTQct/hGUlp2YCw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8f62583-4649-421a-b1e2-4ca64b9e9518", "AQAAAAEAACcQAAAAEKhdH027KUnQuMrpLDDXZo2ekffJmbmD61Iq7BwZNYwEGh/A9iffxuoz3xit2lJxLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4189a7c3-e7b5-494e-9c2d-b26b7f12f361", "AQAAAAEAACcQAAAAEIpu18BsLQNDSav05/KVD1r1b1gtcZ8pY3V0qCDtHa+s9coyvPyB3D0MjCvTaFzNbA==" });

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Expenditure",
                keyColumn: "Id",
                keyValue: new Guid("3397bff8-1261-4603-8965-9d596246e4b8"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 8, 772, DateTimeKind.Local).AddTicks(4244));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"), new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3") });

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
                keyValue: new Guid("a7a6ea39-8204-4afe-9253-b44124605f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "153269f9-55e9-416e-9f82-fad80589e659", "AQAAAAEAACcQAAAAEAaN3ECUav35i22ocQfgAI5ADotiWCoXGrQzXeUt804QJGgVS4K/4hlxOcYEb+hdyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "590c8ffa-cb4f-4d60-b781-f2965867583d", "AQAAAAEAACcQAAAAEEm+rnqOjy2gPdeLQCqk8ao9yfzZ0LaoCCNa5pCaw1DrgixXSNojimqS9ZyRHAToOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0575fc0a-fb5c-42c3-ae76-8cd847642ef3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1897c0dd-8784-4fb1-9948-72dce652857a", "AQAAAAEAACcQAAAAEL78jAQOWmk6iUw/Y+Ig1mFVos3wAWE3m0Iv2qyrkT14tt1kR1Cp9TDrLlTKp2EcHQ==" });

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

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2025, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(558), new DateTime(2023, 2, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(554), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(527), new DateTime(1998, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("4f7f3b0e-0f1b-4c25-9fe8-79dfed7c3602"),
                columns: new[] { "ContractEndDate", "ContractStartDate", "CreatedDate", "YearOfEstablishment" },
                values: new object[] { new DateTime(2024, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(575), new DateTime(2023, 9, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(573), new DateTime(2023, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(565), new DateTime(2018, 10, 18, 20, 14, 33, 416, DateTimeKind.Local).AddTicks(571) });

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
        }
    }
}
