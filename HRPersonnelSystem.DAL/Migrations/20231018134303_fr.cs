using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRPersonnelSystem.DAL.Migrations
{
    public partial class fr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    YearOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfTermination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_TCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_Gender = table.Column<int>(type: "int", nullable: true),
                    CompanyDirector_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyDirector_BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyDirector_DateOfTermination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyDirector_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDirector_Salary = table.Column<double>(type: "float", nullable: true),
                    CompanyDirector_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CompanyDirector_ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Employee_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_TCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Gender = table.Column<int>(type: "int", nullable: true),
                    Employee_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee_BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee_DateOfTermination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Salary = table.Column<double>(type: "float", nullable: true),
                    Employee_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Employee_ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_Employee_CompanyId",
                        column: x => x.Employee_CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvancePayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvancePaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyUnit = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    DateOfReply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Explain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvancePayment_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenditure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenditureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfReply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditure_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfDay = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfReply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"), "78251fcb-3a01-4e55-b0aa-1f6652dab181", "Admin", "ADMIN" },
                    { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), "953ab15f-0739-430f-b922-71d47965a256", "CompanyDirector", "COMPANYDIRECTOR" },
                    { new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"), "7aab2df0-9fa9-404c-8dd3-7ccf4f745298", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyName", "ConcurrencyStamp", "DateOfHire", "DateOfTermination", "Department", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "Job", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondLastName", "SecurityStamp", "TCNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86"), 0, "Okul yolu sok. Zincertepe Apt. Bostancı / İstanbul", new DateTime(1985, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolmabahçe", "BilgeAdam", "dc8b64d5-3b50-4cf0-8ab9-161e34dba91d", new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software", "Admin", "erden.timur@bilgeadam.com", true, "Erden", 1, "ErdenTimur.jpeg", true, "Admin", "Timur", false, null, null, "ERDEN.TIMUR@BILGEADAM.COM", "ERDEN.TIMUR@BILGEADAM.COM", "AQAAAAEAACcQAAAAEDn6OIY52YoN+mUTpt13jXqACQRRnHqeTS7xHBoSxv56wMqZM0ZhYLzXqh/4Hss44A==", null, true, 45000.0, null, "1", "12345678900", false, "erden.timur@bilgeadam.com" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "CompanyName", "CompanyTitle", "ContractEndDate", "ContractStartDate", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "ImagePath", "IsActive", "IsDeleted", "MersisNumber", "ModifiedBy", "ModifiedDate", "NumberOfEmployees", "Phone", "TaxNumber", "TaxOffice", "YearOfEstablishment" },
                values: new object[] { new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "Küçükyali merkez mh. oniki sk. No : 14 Ayazağa Plaza. Sarıyer / Istanbul", "BilgeAdam Teknoloji", "LTD.ŞTI.", new DateTime(2025, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3036), new DateTime(2023, 2, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3033), "Admin", new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3011), null, null, "info@bilgeadam.com", "indir.png", true, false, "0470000911900015", null, null, 88, "0212 473 88 88", "4700009119", "Aksaray V.D", new DateTime(1998, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(3031) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2a56646d-1ce3-452c-9aee-f64cef46892a"), new Guid("d6aab0eb-0052-48bd-a830-37a8e5e67f86") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyDirector_Address", "CompanyDirector_BirthDate", "CompanyDirector_BirthPlace", "CompanyId", "ConcurrencyStamp", "CompanyDirector_DateOfHire", "CompanyDirector_DateOfTermination", "CompanyDirector_Department", "Discriminator", "Email", "EmailConfirmed", "CompanyDirector_FirstName", "CompanyDirector_Gender", "CompanyDirector_ImagePath", "CompanyDirector_IsActive", "CompanyDirector_Job", "CompanyDirector_LastName", "LockoutEnabled", "LockoutEnd", "CompanyDirector_MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "CompanyDirector_Salary", "CompanyDirector_SecondLastName", "SecurityStamp", "CompanyDirector_TCNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead"), 0, "Süründere Mah. Orkun Sok. No:55 Kızılay/Ankara", new DateTime(1991, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara", new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "b83c2747-f59b-4811-917a-178d174fa5f8", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilişim Teknojileri", "CompanyDirector", "gizem.altin@bilgeadamboost.com", true, "Gizem", 0, "Gamze.jpg", true, "Ekip Lideri", "Altın", false, null, null, "GIZEM.ALTIN@BILGEADAMBOOST.COM", "GIZEM.ALTIN@BILGEADAMBOOST.COM", "AQAAAAEAACcQAAAAECjwxUYo3zZk5xkLB+IzmtdaCwjl+Rf7rr28qFFssowRY+hSl1AhFO+OJOpFBHUr0w==", "0522222222", true, 47000.0, null, "1", "12345678911", false, "gizem.altin@bilgeadamboost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Employee_Address", "Employee_BirthDate", "Employee_BirthPlace", "Employee_CompanyId", "ConcurrencyStamp", "Employee_DateOfHire", "Employee_DateOfTermination", "Employee_Department", "Discriminator", "Email", "EmailConfirmed", "Employee_FirstName", "Employee_Gender", "Employee_ImagePath", "Employee_IsActive", "Employee_Job", "Employee_LastName", "LockoutEnabled", "LockoutEnd", "Employee_MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Employee_Salary", "Employee_SecondLastName", "SecurityStamp", "Employee_TCNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 0, " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​", new DateTime(1998, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bakırköy", new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "8fbe172f-f005-4688-b29b-c1f423696851", new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software", "Employee", "burak.pekmez@bilgeadamboost.com", true, "Burak", 1, "Burak.jpg", true, "Developer", "Pekmez", false, null, null, "BURAK.PEKMEZ@BILGEADAMBOOST.COM", "BURAK.PEKMEZ@BILGEADAMBOOST.COM", "AQAAAAEAACcQAAAAEDeR4uXwJ1Xdg5upZntp1MG7egardw5b1m5bsLdcp+6GL+iYe3CfmP02sdXWHQinIA==", "055555555", true, 23000.0, null, "1", "12345678910", false, "burak.pekmez@bilgeadamboost.com" },
                    { new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f"), 0, " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​", new DateTime(1997, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuzla", new Guid("0c026bc4-e4d4-44fd-b210-02e7a6a172c9"), "a614f822-f19d-42e3-beef-0bfef414c67e", new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software", "Employee", "hande.pekmez@bilgeadamboost.com", true, "Hande", 0, "Hande.jpg", true, "Developer", "Pekmez", false, null, null, "HANDE.PEKMEZ@BILGEADAMBOOST.COM", "HANDE.PEKMEZ@BILGEADAMBOOST.COM", "AQAAAAEAACcQAAAAEO5HxusDSaTVmHFDRXTukrhgmQYvMBpiqd7QymHCWreNWpJ+hiQZm2wNo4xoDXjwIg==", "05001905222", true, 32000.0, null, "1", "92345678910", false, "hande.pekmez@bilgeadamboost.com" }
                });

            migrationBuilder.InsertData(
                table: "AdvancePayment",
                columns: new[] { "Id", "AdvancePaymentType", "Amount", "ApprovalStatus", "CreatedBy", "CreatedDate", "CurrencyUnit", "DateOfReply", "DeletedBy", "DeletedDate", "EmployeeId", "Explain", "ImagePath", "IsDeleted", "ModifiedBy", "ModifiedDate", "RequestDate" },
                values: new object[] { new Guid("f8bd10ce-80d7-4211-9893-a943cb333338"), "Bireysel", 5000m, 2, null, new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(6798), 2, null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), "", null, false, null, null, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"), new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631") },
                    { new Guid("cba7d3c3-51e2-4694-9003-4177b2c43808"), new Guid("b7acc710-c1b9-4ae4-9a6b-efda8160cf4f") },
                    { new Guid("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"), new Guid("fb944ae2-e89b-4f8e-b17b-b7fe1ece2ead") }
                });

            migrationBuilder.InsertData(
                table: "Expenditure",
                columns: new[] { "Id", "Amount", "ApprovalStatus", "CreatedBy", "CreatedDate", "CurrencyUnit", "DateOfReply", "DeletedBy", "DeletedDate", "EmployeeId", "ExpenditureType", "ImagePath", "IsDeleted", "ModifiedBy", "ModifiedDate", "RequestDate" },
                values: new object[,]
                {
                    { new Guid("2ffbe4d4-c782-4a19-bd89-0a8624bed3ee"), 500m, "Reddedildi", null, new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(7883), "TL", null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), "Konaklama", null, false, null, null, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3397bff8-1261-4603-8965-9d596246e4b8"), 800m, "Bekleyen", null, new DateTime(2023, 10, 18, 16, 43, 2, 232, DateTimeKind.Local).AddTicks(7822), "TL", null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), "Seyahat", null, false, null, null, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "ApprovalStatus", "CountOfDay", "CreatedBy", "CreatedDate", "DateOfReply", "DeletedBy", "DeletedDate", "EmployeeId", "Gender", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "PermissionType", "RequestDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("230ae8d2-be96-40bf-8639-566de6ba3a73"), "Bekleyen", 5, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5909), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Babalık", new DateTime(2024, 1, 16, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 1, 26, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5912) },
                    { new Guid("305ef3c8-fc05-46b2-b054-c49ad270be26"), "Bekleyen", 21, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5881), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Askerlik", new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5891), new DateTime(2023, 11, 7, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5888) },
                    { new Guid("38b5f216-c008-4e81-9cac-337f8ad7e283"), "Reddedildi", 5, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5937), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Yıllık", new DateTime(2024, 7, 14, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5941), new DateTime(2024, 7, 19, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5939) },
                    { new Guid("702dabb3-d6d4-4ec0-a6f1-ae329c81b649"), "Onaylandı", 3, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5927), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Evlilik", new DateTime(2024, 8, 13, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5932), new DateTime(2024, 9, 7, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5931) },
                    { new Guid("736b4a73-d1e5-4c87-80b7-8584824b4e57"), "Reddedildi", 10, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5946), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Refakat", new DateTime(2024, 5, 3, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5949), new DateTime(2024, 5, 5, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5948) },
                    { new Guid("7fe8e741-7e57-41ea-ae05-1697b1c18f77"), "Onaylandı", 3, null, new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5919), null, null, null, new Guid("7db5918a-64b7-4d74-8d16-bb52fa969631"), 1, true, false, null, null, "Hastalık", new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5922), new DateTime(2023, 10, 18, 16, 43, 2, 241, DateTimeKind.Local).AddTicks(5921) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayment_EmployeeId",
                table: "AdvancePayment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Employee_CompanyId",
                table: "AspNetUsers",
                column: "Employee_CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditure_EmployeeId",
                table: "Expenditure",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_EmployeeId",
                table: "Permission",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvancePayment");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expenditure");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
