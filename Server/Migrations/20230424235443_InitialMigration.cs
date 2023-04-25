using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    PublishDate = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Published = table.Column<bool>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86bbe37e-1169-4612-a647-13f968705bb4", "a5c75da5-e0cd-4ed7-9e2f-05273c3b0eeb", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e571ea99-37e4-40be-8cc9-71409fd83a65", 0, "c078391f-440a-4d2b-9995-c8b1ec915688", "alvaro@gmail.com", false, false, null, "ALVARO@GMAIL.COM", "ALVARO@GMAIL.COM", "AQAAAAEAACcQAAAAEHYVi8XXqyvhuJLXl7NgHlotzcoKOQZ9YnOwYxt7kGZX2A0e9bGCs1aTufb7ut9kLg==", null, false, "6ee4bc4c-70dd-4e22-bf36-d31e43ee9ae9", false, "alvaro@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ThumbnailImagePath" },
                values: new object[] { 1, "A category with posts on the most recent frameworks", "Frameworks", "uploads/cat1.png" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ThumbnailImagePath" },
                values: new object[] { 2, "All about web security and its implementation", "Web Security", "uploads/cat2.png" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ThumbnailImagePath" },
                values: new object[] { 3, "Godot? Unity? There's all of it in this category", "Game Development", "uploads/cat3.png" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "86bbe37e-1169-4612-a647-13f968705bb4", "e571ea99-37e4-40be-8cc9-71409fd83a65" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 1, "AlvaroF", 1, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 1. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "First post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 2, "AlvaroF", 2, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 2. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "Second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 3, "AlvaroF", 3, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 3. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "Third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 4, "AlvaroF", 1, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 4. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "Fourth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 5, "AlvaroF", 2, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 5. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "Fifth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 6, "AlvaroF", 3, "{\"ops\":[{\"insert\":\"Nescio quo modo praetervolavit oratio.\"},{\"attributes\":{\"header\":1},\"insert\":\"\\n\"},{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"At, si voluptas esset bonum, desideraret.\"},{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"},{\"attributes\":{\"header\":2},\"insert\":\"\\n\"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Pauca mutat vel plura sane;\"},{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"},{\"attributes\":{\"italic\":true},\"insert\":\"Ita credo.\"},{\"insert\":\" \"},{\"attributes\":{\"code\":true},\"insert\":\"Bork\"},{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"},{\"attributes\":{\"blockquote\":true},\"insert\":\"\\n\"},{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"rerum appetendarum.\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\\n\"},{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"vis naturae quasi per caliginem cernitur;\"},{\"attributes\":{\"code-block\":true},\"insert\":\"\\n\"},{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"},{\"attributes\":{\"code\":true},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Ne discipulum abducam, times.\"},{\"insert\":\" \"},{\"attributes\":{\"link\":\"http://loripsum.net/\"},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"},{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"Ut aliquid scire se gaudeant?\"},{\"attributes\":{\"list\":\"bullet\"},\"insert\":\"\\n\"},{\"insert\":\"\\n\"}]}", "This is the excerpt for post 6. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "24/04/2023 11:54", true, "uploads/placeholder.png", "Sixth post" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
