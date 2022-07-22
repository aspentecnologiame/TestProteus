using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Interfaces.Repositories.Externals
{
    public interface IFeedRDFRepository
    {
        Task<RDF> ImportFeeds();
    }
}
