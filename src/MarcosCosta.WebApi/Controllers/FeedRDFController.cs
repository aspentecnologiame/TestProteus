﻿using MarcosCosta.Domain.Interfaces.Services;
using MarcosCosta.WebApi.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarcosCosta.WebApi.Controllers
{
    [Route("api/feed-rdf")]
    [ApiController]
    
    public class FeedRDFController : ControllerBase
    {
        private readonly IFeedRDFService _feedRDFService; 
        public FeedRDFController(IFeedRDFService feedRDFService)
        {
            _feedRDFService = feedRDFService;
        }

        [HttpGet("feeds")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] Guid feedRDFId)
        {
            var respponse = await _feedRDFService.GetFeedRDFById(feedRDFId);
            return await Task.FromResult(Ok(respponse));
        }
    }
}
