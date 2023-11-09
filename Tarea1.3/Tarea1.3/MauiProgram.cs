using Microsoft.Extensions.Logging;

namespace Tarea1._3
{ 
    public static class MauiProgram
    {
        static Controlador.Metodos db;
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();

        }

        public static Controlador.Metodos Instancia
        {
            get
            {
                if (db == null)
                {
                    string dbname = "PersonasDB.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfull = Path.Combine(dbpath, dbname);
                    db = new Controlador.Metodos(dbfull);
                }

                return db;
            }
        }
    }
}