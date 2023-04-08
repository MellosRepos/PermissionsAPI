
using Nest;
using Core.Entities;

namespace Core.Services
{
    public class PermissionElasticsearchService
    {
        public static async Task CreatePermissionIndexAsync(IElasticClient elasticClient)
        {
            var createIndexResponse = await elasticClient.Indices.CreateAsync("permissions", c => c
                .Map<Permissions>(m => m
                    .AutoMap()
                )
            );
        }
    }
}