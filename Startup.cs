using DocumentService.Features.StorageService.MongoDbClient;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
        DocumentServiceCosmosDbSettings.Init(_configuration);
    }
}
