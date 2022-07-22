using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<bool> ClearItem();
    }
}
