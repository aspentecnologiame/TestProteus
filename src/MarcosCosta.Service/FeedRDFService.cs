﻿using AutoMapper;
using MarcosCosta.Domain.Entities;
using MarcosCosta.Domain.Interfaces.Repositories;
using MarcosCosta.Domain.Interfaces.Repositories.Externals;
using MarcosCosta.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;

namespace MarcosCosta.Service
{
    public class FeedRDFService : IFeedRDFService
    {
        private readonly IFeedRDFRepository _feedRDFRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<FeedRDFService> _logger;
        private readonly IMemoryCache _memoryCache;
        public FeedRDFService(IFeedRDFRepository feedRDFRepository, IChannelRepository channelRepository,
            IItemRepository itemRepository, ILogger<FeedRDFService> logger, IMemoryCache memoryCache)
        {
            _feedRDFRepository = feedRDFRepository;
            _channelRepository = channelRepository;
            _itemRepository = itemRepository;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<RDFEntity> GetFeeds()
        {
            try
            {
                var channel = await _channelRepository.Get();
                var key = $"rdf-{channel.Id}";

                var rdfEntity = _memoryCache.Get<RDFEntity>(key);

                if (rdfEntity == null)
                {
                    rdfEntity = new RDFEntity
                    {
                        Channel = channel,
                        Items = await _itemRepository.GetByRDFId(channel.Id)
                    };

                    _memoryCache.Set(key, rdfEntity);
                }

                return await Task.FromResult(rdfEntity ?? new RDFEntity());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<bool> ImportFeeds()
        {
            try
            {
                IMapper _mapper;

                _logger.LogInformation("Obtendo os feeds!");

                var rdf = await _feedRDFRepository.ImportFeeds();

                _mapper = AutoMapperConfigurations.ChannelMapperConfig;
                var channelEntity = _mapper.Map<channel, ChannelEntity>(rdf.channel);

                _mapper = AutoMapperConfigurations.ItemMapperConfig;
                var itemsEntity = _mapper.Map<IEnumerable<item>, IEnumerable<ItemEntity>>(rdf.item);

                _logger.LogInformation("Iniciando o clear repositories!");

                await _itemRepository.ClearItem();
                await _channelRepository.ClearChannel();

                _logger.LogInformation("Inserindo feeds na base!");

                await _channelRepository.Insert(channelEntity);
                itemsEntity.ToList().ForEach(i => i.RDFId = channelEntity.Id);
                await _itemRepository.Insert(itemsEntity);

                _logger.LogInformation("Processo de importação de feed concluído com sucesso!");

                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}\n InnerException: {ex.InnerException}");
                throw new Exception(ex.Message);
            }
        }
    }
}