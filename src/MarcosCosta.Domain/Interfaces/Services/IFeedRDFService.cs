using MarcosCosta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Interfaces.Services
{
    public interface IFeedRDFService
    {
        Task<bool> ImportFeeds();
        Task<RDFEntity> GetFeeds();
    }
}
