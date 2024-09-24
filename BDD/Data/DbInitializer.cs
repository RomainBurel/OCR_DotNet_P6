using BDD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BDD.Data
{
	public static class DbInitializer
	{
		// Product IDs
		private const int ID_PRODUCT_TRADER = 1;
		private const int ID_PRODUCT_MASTER = 2;
		private const int ID_PRODUCT_TRAINING = 3;
		private const int ID_PRODUCT_ANXIETY = 4;
		// Version IDs
		private const int ID_VERSION_1_0 = 1;
		private const int ID_VERSION_1_1 = 2;
		private const int ID_VERSION_1_2 = 3;
		private const int ID_VERSION_1_3 = 4;
		private const int ID_VERSION_2_0 = 5;
		private const int ID_VERSION_2_1 = 6;
		// OS IDs
		private const int ID_OS_LINUX = 1;
		private const int ID_OS_MACOS = 2;
		private const int ID_OS_WINDOWS = 3;
		private const int ID_OS_ANDROID = 4;
		private const int ID_OS_IOS = 5;
		private const int ID_OS_WINDOWS_MOBILE = 6;
		// ProductVersionOS IDs
		private const int ID_PVO_TRADER_1_0_LINUX = 1;
		private const int ID_PVO_TRADER_1_0_WINDOWS = 2;
		private const int ID_PVO_TRADER_1_1_LINUX = 3;
		private const int ID_PVO_TRADER_1_1_MACOS = 4;
		private const int ID_PVO_TRADER_1_1_WINDOWS = 5;
		private const int ID_PVO_TRADER_1_2_LINUX = 6;
		private const int ID_PVO_TRADER_1_2_MACOS = 7;
		private const int ID_PVO_TRADER_1_2_WINDOWS = 8;
		private const int ID_PVO_TRADER_1_2_ANDROID = 9;
		private const int ID_PVO_TRADER_1_2_IOS = 10;
		private const int ID_PVO_TRADER_1_2_WINDOWS_MOBILE = 11;
		private const int ID_PVO_TRADER_1_3_MACOS = 12;
		private const int ID_PVO_TRADER_1_3_WINDOWS = 13;
		private const int ID_PVO_TRADER_1_3_ANDROID = 14;
		private const int ID_PVO_TRADER_1_3_IOS = 15;
		private const int ID_PVO_MASTER_1_0_MACOS = 16;
		private const int ID_PVO_MASTER_1_0_IOS = 17;
		private const int ID_PVO_MASTER_2_0_MACOS = 18;
		private const int ID_PVO_MASTER_2_0_ANDROID = 19;
		private const int ID_PVO_MASTER_2_0_IOS = 20;
		private const int ID_PVO_MASTER_2_1_MACOS = 21;
		private const int ID_PVO_MASTER_2_1_WINDOWS = 22;
		private const int ID_PVO_MASTER_2_1_ANDROID = 23;
		private const int ID_PVO_MASTER_2_1_IOS = 24;
		private const int ID_PVO_TRAINING_1_0_LINUX = 25;
		private const int ID_PVO_TRAINING_1_0_MACOS = 26;
		private const int ID_PVO_TRAINING_1_1_LINUX = 27;
		private const int ID_PVO_TRAINING_1_1_MACOS = 28;
		private const int ID_PVO_TRAINING_1_1_WINDOWS = 29;
		private const int ID_PVO_TRAINING_1_1_ANDROID = 30;
		private const int ID_PVO_TRAINING_1_1_IOS = 31;
		private const int ID_PVO_TRAINING_1_1_WINDOWS_MOBILE = 32;
		private const int ID_PVO_TRAINING_2_0_MACOS = 33;
		private const int ID_PVO_TRAINING_2_0_WINDOWS = 34;
		private const int ID_PVO_TRAINING_2_0_ANDROID = 35;
		private const int ID_PVO_TRAINING_2_0_IOS = 36;
		private const int ID_PVO_ANXIETY_1_0_MACOS = 37;
		private const int ID_PVO_ANXIETY_1_0_WINDOWS = 38;
		private const int ID_PVO_ANXIETY_1_0_ANDROID = 39;
		private const int ID_PVO_ANXIETY_1_0_IOS = 40;
		private const int ID_PVO_ANXIETY_1_1_MACOS = 41;
		private const int ID_PVO_ANXIETY_1_1_WINDOWS = 42;
		private const int ID_PVO_ANXIETY_1_1_ANDROID = 43;
		private const int ID_PVO_ANXIETY_1_1_IOS = 44;
		// Status IDs
		private const int ID_STATUS_IN_PROGRESS = 1;
		private const int ID_STATUS_SOLVED = 2;

		public static void Initialize(IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();

			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					context.Database.EnsureCreated();

					// Check if there are any Product or Version or OS or ProductVersionOS or Tickets or Status already in the database
					if (context.Products.Any() || context.Versions.Any() || context.OS.Any() || context.ProductVersionOS.Any() || context.Tickets.Any() || context.Status.Any())
					{
						// Database has been seeded
						return;
					}
					else
					{
						context.Products.AddRange(
							new Product { NameProduct = "Trader en herbe" },
							new Product { NameProduct = "Maître des Investissements" },
							new Product { NameProduct = "Planificateur d’Entraînement" },
							new Product { NameProduct = "Planificateur d’Anxiété Sociale" }
						);

						context.Versions.AddRange(
							new Entities.Version { VersionName = "1.0" },
							new Entities.Version { VersionName = "1.1" },
							new Entities.Version { VersionName = "1.2" },
							new Entities.Version { VersionName = "1.3" },
							new Entities.Version { VersionName = "2.0" },
							new Entities.Version { VersionName = "2.1" }
						);

						context.OS.AddRange(
							new OS { OSName = "Linux" },
							new OS { OSName = "MacOS" },
							new OS { OSName = "Windows" },
							new OS { OSName = "Android" },
							new OS { OSName = "iOS" },
							new OS { OSName = "Windows Mobile" }
						);

						context.ProductVersionOS.AddRange(
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_LINUX },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_LINUX },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_LINUX },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_2, IdOS = ID_OS_WINDOWS_MOBILE },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_3, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_3, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_3, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRADER, IdVersion = ID_VERSION_1_3, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_1, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_1, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_1, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_MASTER, IdVersion = ID_VERSION_2_1, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_LINUX },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_LINUX },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_WINDOWS_MOBILE },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_TRAINING, IdVersion = ID_VERSION_2_0, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_0, IdOS = ID_OS_IOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_MACOS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_WINDOWS },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_ANDROID },
							new ProductVersionOS { IdProduct = ID_PRODUCT_ANXIETY, IdVersion = ID_VERSION_1_1, IdOS = ID_OS_IOS }
						);

						context.Status.AddRange(
							new Status { StatusName = "En cours" },
							new Status { StatusName = "Résolu" }
						);

						context.Tickets.AddRange(
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_0_LINUX, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("15/03/2024"), Description = "L'application se bloque lors de l'affichage de graphiques complexes pour des actions très volatiles, empêchant les utilisateurs d'analyser certaines tendances de marché.", DateSolving = DateTime.Parse("20/03/2024"), Solution = "Une optimisation du moteur de rendu des graphiques a été effectuée pour améliorer la gestion des données hautement volatiles. Un patch a été déployé pour résoudre ce problème." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_1_0_MACOS, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("02/04/2024"), Description = "Les utilisateurs signalent des retards importants dans la mise à jour des cours des actions en temps réel, ce qui peut conduire à des décisions d'investissement basées sur des informations obsolètes." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_1_0_LINUX, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("10/05/2024"), Description = "Le calcul des calories brûlées pendant les séances de cardio semble inexact, surestimant systématiquement la dépense énergétique pour certains types d'exercices.", DateSolving = DateTime.Parse("15/05/2024"), Solution = "Les algorithmes de calcul des calories ont été révisés et calibrés avec des données plus précises pour chaque type d'exercice. Une mise à jour a été déployée pour corriger ces estimations." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_0_ANDROID, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("20/03/2024"), Description = "L'application se ferme inopinément lors de la création d'un nouveau plan d'exposition progressive, causant une frustration chez les utilisateurs qui perdent leurs progrès.", DateSolving = DateTime.Parse("12/04/2024"), Solution = "Un bug dans la gestion de la mémoire lors de la création de nouveaux plans a été identifié et corrigé. Une mise à jour de l'application a été publiée sur le Google Play Store." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_1_MACOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("12/04/2024"), Description = "Les notifications pour les alertes de prix ne fonctionnent pas correctement sur MacOS, empêchant les utilisateurs de réagir rapidement aux mouvements du marché.", DateSolving = DateTime.Parse("10/05/2024"), Solution = "Un problème de compatibilité avec le système de notification de MacOS a été résolu. Une mise à jour spécifique à MacOS a été déployée pour corriger ce dysfonctionnement." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_2_0_IOS, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("05/05/2024"), Description = "Le module de simulation de portefeuille produit des résultats erronés lorsqu'il inclut des produits dérivés complexes, conduisant à des estimations de risque incorrectes." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_1_1_WINDOWS_MOBILE, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("25/03/2024"), Description = "L'intégration avec certains bracelets connectés populaires ne fonctionne pas correctement sur Windows Mobile, empêchant la synchronisation automatique des données d'entraînement.", DateSolving = DateTime.Parse("27/03/2024"), Solution = "Les pilotes pour les appareils connectés ont été mis à jour et optimisés pour Windows Mobile. Une nouvelle version de l'application a été publiée avec une meilleure compatibilité." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_1_IOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("15/04/2024"), Description = "Les utilisateurs rapportent que l'exercice de respiration guidée se désynchronise parfois avec l'audio, rendant l'exercice moins efficace et potentiellement stressant.", DateSolving = DateTime.Parse("20/04/2024"), Solution = "Un problème de synchronisation audio a été identifié et corrigé. La nouvelle version de l'application assure une parfaite synchronisation entre les instructions visuelles et audio." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_2_ANDROID, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("20/05/2024"), Description = "L'outil d'analyse technique ne parvient pas à charger correctement les données historiques pour certaines crypto-monnaies, limitant les capacités d'analyse des utilisateurs." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_2_1_WINDOWS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("01/04/2024"), Description = "Le module de génération de rapports fiscaux produit des documents incomplets pour les investissements internationaux, posant des problèmes potentiels pour les déclarations d'impÃ´ts des utilisateurs.", DateSolving = DateTime.Parse("15/04/2024"), Solution = "Les règles fiscales pour les investissements internationaux ont été mises à jour et le module de rapport a été amélioré pour prendre en compte toutes les spécificités. Une mise à jour majeure a été déployée." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_2_0_IOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("18/04/2024"), Description = "Les utilisateurs signalent des incohérences dans le suivi GPS des parcours de course à pied, avec des distances parfois sous-estimées, affectant la précision des statistiques d'entraînement.", DateSolving = DateTime.Parse("26/04/2024"), Solution = "L'algorithme de traitement des données GPS a été optimisé pour améliorer la précision du suivi. Une mise à jour de l'application a été publiée sur l'App Store." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_0_WINDOWS, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("15/05/2024"), Description = "Le journal de bord des progrès ne sauvegarde pas correctement les entrées longues, causant une perte de données importante pour les utilisateurs qui écrivent des réflexions détaillées." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_3_MACOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("10/03/2024"), Description = "L'outil de backtesting pour les stratégies de trading automatisées produit des résultats incohérents lors de l'utilisation de données de marché à haute fréquence.", DateSolving = DateTime.Parse("12/03/2024"), Solution = "Le moteur de backtesting a été repensé pour gérer efficacement les données à haute fréquence. Une mise à jour majeure a été déployée avec des performances améliorées." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_1_0_IOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("05/04/2024"), Description = "Les utilisateurs rapportent des problèmes de connexion intermittents à leurs comptes de courtage liés, empêchant parfois l'exécution d'ordres en temps réel.", DateSolving = DateTime.Parse("18/04/2024"), Solution = "Un problème d'authentification avec certains services de courtage a été identifié et résolu. La sécurité de la connexion a été renforcée tout en améliorant la stabilité." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_1_0_MACOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("01/05/2024"), Description = "Le calculateur de macronutriments ne prend pas correctement en compte les objectifs de prise de masse musculaire, fournissant des recommandations nutritionnelles inadaptées.", DateSolving = DateTime.Parse("16/05/2024"), Solution = "Les algorithmes de calcul des besoins en macronutriments ont été ajustés pour mieux s'adapter aux différents objectifs, y compris la prise de masse. Une mise à jour a été publiée." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_1_ANDROID, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("08/04/2024"), Description = "L'application cesse de fonctionner lors de l'utilisation de la fonction de réalité augmentée pour les exercices d'exposition sur certains modèles de smartphones Android." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_0_WINDOWS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("12/05/2024"), Description = "Les alertes sonores pour les mouvements de marché significatifs ne fonctionnent pas lorsque l'application est en arrière-plan sur Windows, faisant manquer des opportunités importantes aux utilisateurs.", DateSolving = DateTime.Parse("10/06/2024"), Solution = "Un correctif a été appliqué pour permettre à l'application de déclencher des alertes sonores même en arrière-plan. Une mise à jour a été publiée pour Windows." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_2_0_ANDROID, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("30/03/2024"), Description = "Le module de diversification de portefeuille ne prend pas correctement en compte les corrélations entre certains secteurs d'activité, conduisant à des recommandations de diversification sous-optimales.", DateSolving = DateTime.Parse("16/04/2024"), Solution = "Les modèles de corrélation entre secteurs ont été mis à jour avec des données plus récentes et précises. Le module de diversification a été amélioré pour fournir des recommandations plus pertinentes." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_1_1_IOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("22/04/2024"), Description = "Les utilisateurs signalent que la fonction de partage des résultats sur les réseaux sociaux ne fonctionne pas correctement, empêchant le partage des accomplissements sportifs.", DateSolving = DateTime.Parse("30/04/2024"), Solution = "Les problèmes d'intégration avec les API des réseaux sociaux ont été résolus. Une mise à jour de l'application a été publiée sur l'App Store avec des fonctionnalités de partage améliorées." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_0_MACOS, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("08/05/2024"), Description = "Le module de méditation guidée présente des problèmes de lecture audio sur certains Mac, interrompant les sessions de relaxation des utilisateurs." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_1_LINUX, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("03/04/2024"), Description = "L'outil de comparaison de performances entre différents actifs financiers produit des graphiques incorrects lorsqu'il s'agit de comparer des actifs avec des devises différentes.", DateSolving = DateTime.Parse("17/04/2024"), Solution = "Le module de conversion de devises a été amélioré pour assurer une comparaison précise des actifs dans différentes monnaies. Une mise à jour a été déployée pour Linux." },
							new Ticket { IdProductVersionOS = ID_PVO_MASTER_2_1_MACOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("18/05/2024"), Description = "Les utilisateurs rapportent des lenteurs importantes lors de l'analyse de portefeuilles contenant un grand nombre d'actifs, rendant l'application presque inutilisable pour les investisseurs professionnels.", DateSolving = DateTime.Parse("01/07/2024"), Solution = "Une optimisation majeure des performances a été réalisée, notamment dans le traitement des données pour les grands portefeuilles. Une mise à jour significative a été publiée pour MacOS." },
							new Ticket { IdProductVersionOS = ID_PVO_TRAINING_2_0_ANDROID, IdStatus = ID_STATUS_IN_PROGRESS, DateCreation = DateTime.Parse("10/04/2024"), Description = "La fonction de création de programmes d'entraînement personnalisés génère parfois des plans incohérents, mélangeant des exercices incompatibles ou ignorant les temps de récupération nécessaires." },
							new Ticket { IdProductVersionOS = ID_PVO_ANXIETY_1_1_WINDOWS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("02/05/2024"), Description = "Le système de suivi des progrès à long terme ne parvient pas à générer des graphiques précis pour les utilisateurs ayant plus de six mois d'historique, faussant la perception de leur évolution.", DateSolving = DateTime.Parse("10/05/2024"), Solution = "Le module de génération de graphiques a été revu pour gérer efficacement les données sur de longues périodes. Une mise à jour a été déployée avec des visualisations améliorées des progrès à long terme." },
							new Ticket { IdProductVersionOS = ID_PVO_TRADER_1_2_IOS, IdStatus = ID_STATUS_SOLVED, DateCreation = DateTime.Parse("18/03/2024"), Description = "L'intégration avec certaines plateformes de trading populaires échoue lors de l'exécution d'ordres complexes, comme les ordres conditionnels ou les stratégies d'options.", DateSolving = DateTime.Parse("30/03/2024"), Solution = "Les protocoles d'intégration avec les plateformes de trading ont été mis à jour pour prendre en charge tous les types d'ordres complexes. Une nouvelle version de l'application a été publiée sur l'App Store." }
						);
                    }

                    context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					transaction.Rollback();
				}
			}
		}
	}
}
