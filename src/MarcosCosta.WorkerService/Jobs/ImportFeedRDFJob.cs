using MarcosCosta.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.WorkerService.Jobs
{
    public class ImportFeedRDFJob
    {
        private readonly IFeedRDFService _feedRDFService;

        public ImportFeedRDFJob(IFeedRDFService feedRDFService)
        {
            _feedRDFService = feedRDFService;
        }
        public async Task<bool> ImportFeeds()
        {
            return await _feedRDFService.ImportFeeds();
        }
    }
}
