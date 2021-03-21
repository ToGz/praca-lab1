using lab2.Models;
using System.Linq;

namespace lab2
{
    public static class DbInitializer
    {
        public static void Initialize(AppContext context)
        {
            InitializeLions(context);
            InitializeGiraffes(context);
            InitializeDesertFennels(context);
        }

        private static void InitializeGiraffes(AppContext context)
        {
            if (context.Giraffes.Any())
            {
                return;
            }

            var giraffes = new Giraffe[]
                {
                    new Giraffe{Name="Laura",Weight=50,Age=2,NeckLength=45,NumberOfDots=152},
                    new Giraffe{Name="Werther",Weight=200,Age=4,NeckLength=100,NumberOfDots=101},
                    new Giraffe{Name="Ganesh",Weight=30,Age=1,NeckLength=30,NumberOfDots=126},
                    new Giraffe{Name="Mindaugas",Weight=500,Age=14,NeckLength=217,NumberOfDots=186}
                };

            context.Giraffes.AddRange(giraffes);
            context.SaveChanges();
        }

        private static void InitializeLions(AppContext context)
        {
            if (context.Lions.Any())
            {
                return;
            }

            var lions = new Lion[]
                {
                    new Lion{Name="Anastasios",Weight=42,Age=2,Coloration=Coloration.Black,TailLength=50},
                    new Lion{Name="Simba",Weight=37,Age=4,Coloration=Coloration.LightBrown,TailLength=48},
                    new Lion{Name="Mufasa",Weight=58,Age=6,Coloration=Coloration.DarkBrown,TailLength=37}
                };

            context.Lions.AddRange(lions);
            context.SaveChanges();
        }

        private static void InitializeDesertFennels(AppContext context)
        {
            if (context.DesertFennels.Any())
            {
                return;
            }

            var desertFennels = new DesertFennel[]
                {
                    new DesertFennel{Name="Dalit",Weight=15,Age=4,EarLength=26,MaxSpeed=38,FavouriteWord="wheel"},
                    new DesertFennel{Name="Betony",Weight=9,Age=2,EarLength=28,MaxSpeed=35,FavouriteWord="croissant"},
                    new DesertFennel{Name="Cleo",Weight=12,Age=3,EarLength=24,MaxSpeed=42,FavouriteWord="kayak"}
                };

            context.DesertFennels.AddRange(desertFennels);
            context.SaveChanges();
        }
    }
}
