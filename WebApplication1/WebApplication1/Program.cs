using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

var store = new List<Book> 
{
    new("Название1",1230,"Автор1"),
    new("Название2",1000,"Автор2"),
    new("Название3",900,"Автор3"),
    new("Название4",1500,"Автор4"),
    new("Название5",2300,"Автор5")
};

app.MapGet("/bookstore/books/all", () =>  {

    return Results.Ok(store);
});
app.MapGet("/bookstore/books/search/name/{name}", (string name) =>
{
    var a = new List<Book>();
    foreach (var item in store) 
    {
        if(item.Name == name) 
        {
            a.Add(item);
        }
    }
    if (a.Count == 0)
        return Results.NotFound(new { message = $"книжки с названием {name} нету дружище" });
    return Results.Ok(a);
});
app.MapGet("/bookstore/books/search/price/{price}", (int price) =>
{
    var a = new List<Book>();
    foreach (var item in store)
    {
        if (item.Price == price)
        {
            a.Add(item);
        }
    }
    if (a.Count == 0)
        return Results.NotFound(new { message = $"книжки с ценой {price} нету дружище" });
    return Results.Ok(a);
});
app.MapGet("/bookstore/books/search/author/{author}", (string author) =>
{
    var a = new List<Book>();
    foreach (var item in store)
    {
        if (item.Author == author)
        {
            a.Add(item);
        }
    }
    if (a.Count == 0)
        return Results.NotFound(new { message = $"книжки с автором {author} нету дружище" });
    return Results.Ok(a);
});
app.MapPost("/bookstore/books/add", (Book newBook) =>
{
    if (newBook.Name == null || newBook.Author == null || newBook.Price <= 0)
        return Results.BadRequest(new { message = "бляяя чувак накосячил ты по страшному? json'то твой корявый" });
    store.Add(newBook);
    return Results.Created($"/bookstore/books/search/name/{newBook.Name}", newBook);
});
app.Run();

