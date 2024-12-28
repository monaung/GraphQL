using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyGraphQLNet.GraphQL;
public class Query {
    public List<Book> Books(ClaimsPrincipal claims, string nameContains ="")
    {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);

        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, 
        new JsonSerializerOptions{ PropertyNameCaseInsensitive = true, Converters = {new JsonStringEnumConverter()}});
        
        return books.Where(b=> b.Name.IndexOf(nameContains)>=0).ToList();
    }
}

public class BookType: ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field("publishDate").ResolveWith<Resolvers>(e=> e.GetFormattedDate(default!));
    }
}