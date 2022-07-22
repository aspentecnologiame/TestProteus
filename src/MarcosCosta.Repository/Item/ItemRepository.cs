﻿using Dapper;
using MarcosCosta.Domain.Entities;
using MarcosCosta.Domain.Interfaces.Repositories;
using MarcosCosta.Repository.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Repository.Item
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> ClearItem()
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.ExecuteAsync(ItemRepositoryCommands.ClearItem) == -1;
        }

        public async Task<bool> Insert(ItemEntity itemEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
                return await connection.ExecuteAsync(ItemRepositoryCommands.Insert, new
                {
                    Id = Guid.NewGuid(),
                    itemEntity.RDFId,
                    itemEntity.About,
                    itemEntity.Date,
                    itemEntity.Description,
                    itemEntity.Link,
                    itemEntity.Title,
                    Created = DateTime.Now
                }) == 1;
        }
    }
}
