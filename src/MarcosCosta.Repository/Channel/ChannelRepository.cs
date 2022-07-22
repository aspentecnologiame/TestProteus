using MarcosCosta.Domain.Entities;
using MarcosCosta.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using MarcosCosta.Domain.Interfaces.Repositories;

namespace MarcosCosta.Repository.Channel
{
    public class ChannelRepository : BaseRepository, IChannelRepository
    {
        public ChannelRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> ClearChannel()
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.ExecuteAsync(ChannelRepositoryCommands.ClearChannel) == -1;
        }

        public async Task<ChannelEntity> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.QueryFirstOrDefaultAsync(ChannelRepositoryCommands.Get);
        }

        public async Task<bool> Insert(ChannelEntity channelEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.ExecuteAsync(ChannelRepositoryCommands.Insert, new
                {
                    channelEntity.Id,
                    channelEntity.About,
                    channelEntity.Date,
                    channelEntity.Description,
                    channelEntity.Link,
                    channelEntity.Language,
                    channelEntity.Rights,
                    channelEntity.Title,
                    Created = DateTime.Now
                }) == 1;
        }
    }
}