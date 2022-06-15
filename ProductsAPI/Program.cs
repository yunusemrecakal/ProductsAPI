using ProductsAPI.Data;
using ProductsAPI.BLL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabaseSettings"));
builder.Services.Configure<ProductsInBasketDatabaseSettings>(builder.Configuration.GetSection("ProductsInBasketDatabaseSettings"));
builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<ProductsInBasketService>();
//builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//builder.Services.AddDistributedRedisCache(options =>
//{
//    options.Configuration = "RedisConStr";
//    options.InstanceName = "master";
//});
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "RedisConStr";
//});

var app = builder.Build();

app.MapGet("/", () => "Products API!!");

app.MapGet("/api/products", async (ProductsService productService) => await productService.GetAsync());

app.MapGet("/api/products/{id}", async (ProductsService productService, int id) =>
{
    var product = await productService.GetAsync(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.MapPut("/api/products/{id}", async (ProductsService productService, int id, Product updatedProd) =>
{
    var prod = await productService.GetAsync(id);
    if (prod is null) return Results.NotFound();

    updatedProd.Id = prod.Id;
    await productService.UpdateAsync(id, updatedProd);

    return Results.Ok();
}
);

app.MapPost("/api/products", async (ProductsService productService, Product product) =>
{
    await productService.CreateAsync(product);
    return Results.Ok();
});

app.MapDelete("/api/products/{id}", async (ProductsService productService, int id) =>
{
    await productService.RemoveAsync(id);
    return Results.Ok();
});

app.MapGet("/api/productsinbasket", async (ProductsInBasketService productsInBasketService) => await productsInBasketService.GetAsync());

app.MapGet("/api/productsinbasket/{id}", async (ProductsInBasketService productsInBasketService, string id) =>
{
    var product = await productsInBasketService.GetAsync(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.MapPut("/api/productsinbasket/{id}", async (ProductsInBasketService productsInBasketService, string id, ProductInBasket updatedProd) =>
{
    var prod = await productsInBasketService.GetAsync(id);
    if (prod is null) return Results.NotFound();

    updatedProd.Id = prod.Id;
    await productsInBasketService.UpdateAsync(id, updatedProd);

    return Results.Ok();
}
);

app.MapPost("/api/productsinbasket", async (ProductsInBasketService productsInBasketService, ProductInBasket product) =>
{
    await productsInBasketService.CreateAsync(product);
    return Results.Ok();
});

app.MapDelete("/api/productsinbasket/{id}", async (ProductsInBasketService productsInBasketService, string id) =>
{
    await productsInBasketService.RemoveAsync(id);
    return Results.Ok();
});

//app.MapGet("/api/Basket/{username}", async (IBasketRepository repository, string username) => await repository.GetBasket(username));

//app.MapPut("/api/products/{id}", async (BasketRepository repository, string username, ShoppingCartItem updatedShoppingCartItem) =>
//{
//    var prod = await repository.GetBasket(username);
//    if (prod is null) return Results.NotFound();

//    updatedShoppingCartItem.Id = prod.id;
//    await productService.UpdateAsync(id, updatedProd);

//    return Results.Ok();
//}
//);

//app.MapPost("/api/products", async (ProductsService productService, Product product) =>
//{
//    await productService.CreateAsync(product);
//    return Results.Ok();
//});

//app.MapDelete("/api/products/{id}", async (ProductsService productService, int id) =>
//{
//    await productService.RemoveAsync(id);
//    return Results.Ok();
//});

app.Run();
