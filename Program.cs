using Bookcase.Database;
using Bookcase.Repository;
using Bookcase.Services;
using Bookcase.Screens;

var db = new Database("gym.db");
db.Initialize();

var repo = new MiembroRepository(db);
var service = new MiembroService(repo);
var screen = new MainScreen(service);

screen.Show();
