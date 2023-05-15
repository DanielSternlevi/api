WebApplication app = WebApplication.Create();

app.Urls.Add("https://localhost:3000");
app.Urls.Add("https://*:3000");

List<superhero> heroes = new();

heroes.Add(new() { Name = "Teknikelev", Futurenetworth = 3000000, Friends = 2 });
heroes.Add(new() { Name = "Estetelev", Futurenetworth = 1000, Friends = 40 });
heroes.Add(new() { Name = "Itelev", Futurenetworth = 2000, Friends = 10 });

superhero superman = new superhero();
superman.Name = "AverageNtiElev";
superman.Futurenetworth = 23;
superman.Friends = 0;

app.MapGet("/", Answer);

app.MapGet("/superhero/", () =>
{
    return heroes;
});

app.MapGet("/superhero/{num}", (int num) =>
{
    if (num >= 0 && num < heroes.Count)
    {
        return Results.Ok(heroes[num]);
    }

    return Results.NotFound();
});

app.MapPost("superhero/", (superhero hero) =>
{
    Console.WriteLine("Creeper aw man!!!" + hero.Name);

    heroes.Add(hero);
});


app.Run();

static string Answer()
{
    return "Hatarbarn";
}