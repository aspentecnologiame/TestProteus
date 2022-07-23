using Dapper;
using MarcosCosta.Domain.Entities;
using MarcosCosta.Domain.Interfaces.Repositories;
using MarcosCosta.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Repository.Item
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<bool> ClearItem()
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.ExecuteAsync(ItemRepositoryCommands.ClearItem) == -1;
        }

        public async Task<IEnumerable<ItemEntity>> GetByRDFId(Guid RDFId)
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.QueryAsync<ItemEntity>(ItemRepositoryCommands.GetByRDFId, new { RDFId = RDFId });
        }

        public async Task<bool> Insert(IEnumerable<ItemEntity> itemsEntity)
        {

            ParallelOptions parallelOptions = new() { MaxDegreeOfParallelism = 10 };

            await Parallel.ForEachAsync(itemsEntity, parallelOptions, async (itemEntity, token) =>
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.ExecuteAsync(ItemRepositoryCommands.Insert, new
                    {
                        Id = Guid.NewGuid(),
                        itemEntity.RDFId,
                        itemEntity.About,
                        itemEntity.Date,
                        itemEntity.Description,
                        itemEntity.Link,
                        itemEntity.Title,
                        Created = DateTime.Now
                    });
                }
            });

            return await Task.FromResult(true);
        }
    }
}
