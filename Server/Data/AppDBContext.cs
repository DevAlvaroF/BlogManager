using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
	public class AppDBContext : IdentityDbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Post> Posts { get; set; }

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Call the base version of the method
			base.OnModelCreating(modelBuilder);


			#region Category Seed
			// ======================================
			// Add seed Data for Categories
			// ======================================
			Category[] categoriesToSeed = new Category[3];
			string[] categoryNames = new string[] { "Frameworks", "Web Security", "Game Development" };
			string[] categoryDescriptions = new string[] { "A category with posts on the most recent frameworks", "All about web security and its implementation", "Godot? Unity? There's all of it in this category" };
			for (int i = 1; i < 4; i++)
			{

				categoriesToSeed[i - 1] = new Category()
				{
					CategoryId = i,
					ThumbnailImagePath = $"uploads/cat{i}.png",
					Name = categoryNames[i - 1],
					Description = categoryDescriptions[i - 1],
				};
			}

			// If data does not exist, seed it
			modelBuilder.Entity<Category>().HasData(categoriesToSeed);
			#endregion


			// ======================================
			// Add seed Data for Posts
			// ======================================

			// Declare that the Posts and Categories are correlated
			// One category can have multiple posts
			modelBuilder.Entity<Post>(entity =>
			{
				entity.HasOne(post => post.Category).WithMany(category => category.Posts).HasForeignKey("CategoryId");
			});

			#region Posts Seed
			Post[] postsToSeed = new Post[6];

			for (int i = 1; i < 7; i++)
			{
				string postTitle = string.Empty;
				int categoryId = 0;

				switch (i)
				{
					case 1:
						postTitle = "First post";
						categoryId = 1;
						break;
					case 2:
						postTitle = "Second post";
						categoryId = 2;
						break;
					case 3:
						postTitle = "Third post";
						categoryId = 3;
						break;
					case 4:
						postTitle = "Fourth post";
						categoryId = 1;
						break;
					case 5:
						postTitle = "Fifth post";
						categoryId = 2;
						break;
					case 6:
						postTitle = "Sixth post";
						categoryId = 3;
						break;
					default:
						break;
				}

				postsToSeed[i - 1] = new Post
				{
					PostId = i,
					ThumbnailImagePath = "uploads/placeholder.png",
					Title = postTitle,
					Excerpt = $"This is the excerpt for post {i}. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.",
					Content = $"{{\"ops\":[{{\"insert\":\"Nescio quo modo praetervolavit oratio.\"}},{{\"attributes\":{{\"header\":1}},\"insert\":\"\\n\"}},{{\"insert\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Possumusne ergo in vita summum bonum dicere, cum id ne in cena quidem posse videamur? Aut, Pylades cum sis, dices te esse Orestem, ut moriare pro amico? Aufert enim sensus actionemque tollit omnem. Te ipsum, dignissimum maioribus tuis, voluptasne induxit, ut adolescentulus eriperes P. Nihil enim hoc differt. Duo Reges: constructio interrete. \"}},{{\"attributes\":{{\"link\":\"http://loripsum.net/\"}},\"insert\":\"At, si voluptas esset bonum, desideraret.\"}},{{\"insert\":\" Quicquid porro animo cernimus, id omne oritur a sensibus;\\nUt proverbia non nulla veriora sint quam vestra dogmata.\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Quam illa ardentis amores excitaret sui! Cur tandem?\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant.\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Quid igitur dubitamus in tota eius natura quaerere quid sit effectum?\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Nam si propter voluptatem, quae est ista laus, quae possit e macello peti?\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Deinde prima illa, quae in congressu solemus: Quid tu, inquit, huc?\"}},{{\"attributes\":{{\"list\":\"ordered\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Ne amores quidem sanctos a sapiente alienos esse arbitrantur.\"}},{{\"attributes\":{{\"header\":2}},\"insert\":\"\\n\"}},{{\"attributes\":{{\"link\":\"http://loripsum.net/\"}},\"insert\":\"Pauca mutat vel plura sane;\"}},{{\"insert\":\" Polycratem Samium felicem appellabant. Polemoni et iam ante Aristoteli ea prima visa sunt, quae paulo ante dixi. Ut proverbia non nulla veriora sint quam vestra dogmata. Quamquam in hac divisione rem ipsam prorsus probo, elegantiam desidero. Quamvis enim depravatae non sint, pravae tamen esse possunt. \"}},{{\"attributes\":{{\"italic\":true}},\"insert\":\"Ita credo.\"}},{{\"insert\":\" \"}},{{\"attributes\":{{\"code\":true}},\"insert\":\"Bork\"}},{{\"insert\":\" Quasi ego id curem, quid ille aiat aut neget. Sin autem est in ea, quod quidam volunt, nihil impedit hanc nostram comprehensionem summi boni.\\nRatio ista, quam defendis, praecepta, quae didicisti, quae probas, funditus evertunt amicitiam, quamvis eam Epicurus, ut facit, in caelum efferat laudibus.\"}},{{\"attributes\":{{\"blockquote\":true}},\"insert\":\"\\n\"}},{{\"insert\":\"Nemo enim est, qui aliter dixerit quin omnium naturarum\"}},{{\"attributes\":{{\"code-block\":true}},\"insert\":\"\\n\"}},{{\"insert\":\"simile esset id, ad quod omnia referrentur, quod est ultimum\"}},{{\"attributes\":{{\"code-block\":true}},\"insert\":\"\\n\"}},{{\"insert\":\"rerum appetendarum.\"}},{{\"attributes\":{{\"code-block\":true}},\"insert\":\"\\n\\n\"}},{{\"insert\":\"Nam, ut saepe iam dixi, in infirma aetate inbecillaque mente\"}},{{\"attributes\":{{\"code-block\":true}},\"insert\":\"\\n\"}},{{\"insert\":\"vis naturae quasi per caliginem cernitur;\"}},{{\"attributes\":{{\"code-block\":true}},\"insert\":\"\\n\"}},{{\"insert\":\"Ita credo.\\nNam memini etiam quae nolo, oblivisci non possum quae volo.\\nBork\\nSed tu istuc dixti bene Latine, parum plane.\\nHic ambiguo ludimur.\\nAt quicum ioca seria, ut dicitur, quicum arcana, quicum occulta omnia?\\nBork\\nIta ceterorum sententiis semotis relinquitur non mihi cum Torquato, sed virtuti cum voluptate certatio.\\nRes enim concurrent contrariae.\\nFortasse id optimum, sed ubi illud: Plus semper voluptatis?\\nBork\\nScaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri.\\nSed ea mala virtuti magnitudine obruebantur. Aeque enim contingit omnibus fidibus, ut incontentae sint. \"}},{{\"attributes\":{{\"code\":true}},\"insert\":\"Diodorus, eius auditor, adiungit ad honestatem vacuitatem doloris.\"}},{{\"insert\":\" \"}},{{\"attributes\":{{\"link\":\"http://loripsum.net/\"}},\"insert\":\"Ne discipulum abducam, times.\"}},{{\"insert\":\" \"}},{{\"attributes\":{{\"link\":\"http://loripsum.net/\"}},\"insert\":\"Tecum optime, deinde etiam cum mediocri amico.\"}},{{\"insert\":\" Tu enim ista lenius, hic Stoicorum more nos vexat. Primum in nostrane potestate est, quid meminerimus? Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.\\nQuid ergo aliud intellegetur nisi uti ne quae pars naturae neglegatur?\"}},{{\"attributes\":{{\"list\":\"bullet\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Quis est, qui non oderit libidinosam, protervam adolescentiam?\"}},{{\"attributes\":{{\"list\":\"bullet\"}},\"insert\":\"\\n\"}},{{\"insert\":\"Ut aliquid scire se gaudeant?\"}},{{\"attributes\":{{\"list\":\"bullet\"}},\"insert\":\"\\n\"}},{{\"insert\":\"\\n\"}}]}}",
					PublishDate = DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm"),
					Published = true,
					Author = "AlvaroF",
					CategoryId = categoryId
				};
			}

			modelBuilder.Entity<Post>().HasData(postsToSeed);
			#endregion

			#region Administrator role seed

			const string administratorRoleName = "Administrator";

			IdentityRole administratorRoleToSeed = new()
			{
				Id = Guid.NewGuid().ToString(),
				Name = administratorRoleName,
				NormalizedName = administratorRoleName.ToUpperInvariant()
			};

			modelBuilder.Entity<IdentityRole>().HasData(administratorRoleToSeed);

			#endregion

			#region Administrator user seed

			const string administratorUserEmail = "alvaro@gmail.com";

			var passwordHasher = new PasswordHasher<IdentityUser>();

			IdentityUser administratorUserToSeed = new()
			{
				Id = Guid.NewGuid().ToString(),
				UserName = administratorUserEmail,
				NormalizedUserName = administratorUserEmail.ToUpperInvariant(),
				Email = administratorUserEmail,
				NormalizedEmail = administratorUserEmail.ToUpperInvariant(),
				PasswordHash = string.Empty,
			};

			string hashedPassword = passwordHasher.HashPassword(administratorUserToSeed, "abc1234!");

			administratorUserToSeed.PasswordHash = hashedPassword;

			modelBuilder.Entity<IdentityUser>().HasData(administratorUserToSeed);

			#endregion

			#region Add the administrator user to the administrator role

			IdentityUserRole<string> identityUserRoleToSeed = new()
			{
				RoleId = administratorRoleToSeed.Id,
				UserId = administratorUserToSeed.Id
			};

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoleToSeed);

			#endregion
		}
	}
}
