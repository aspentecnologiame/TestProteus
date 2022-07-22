using AutoMapper;
using MarcosCosta.Domain.Entities;
using MarcosCosta.Domain.Interfaces.Repositories;
using MarcosCosta.Domain.Interfaces.Repositories.Externals;
using MarcosCosta.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace MarcosCosta.Service
{
    public class FeedRDFService : IFeedRDFService
    {
        private readonly IFeedRDFRepository _feedRDFRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<FeedRDFService> _logger;
        public FeedRDFService(IFeedRDFRepository feedRDFRepository, IChannelRepository channelRepository,
            IItemRepository itemRepository, ILogger<FeedRDFService> logger)
        {
            _feedRDFRepository = feedRDFRepository;
            _channelRepository = channelRepository;
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<bool> ImportFeeds()
        {
            try
            {
                IMapper _mapper;

                _logger.LogInformation("Iniciando o clear repositories!");

                await _itemRepository.ClearItem();
                await _channelRepository.ClearChannel();

                var rdf = await _feedRDFRepository.ImportFeeds();

                _mapper = AutoMapperConfigurations.ChannelMapperConfig;
                var channelEntity = _mapper.Map<channel, ChannelEntity>(rdf.channel);

                _mapper = AutoMapperConfigurations.ItemMapperConfig;
                var itemsEntity = _mapper.Map<IEnumerable<item>, IEnumerable<ItemEntity>>(rdf.item);

                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                _logger.LogWarning($"Error: {ex.Message}\n InnerException: {ex.InnerException}");
                throw new Exception(ex.Message);
            }
        }
    }
}