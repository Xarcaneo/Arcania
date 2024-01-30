using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcania.Services
{
    public interface IUserCharacterService
    {
        Task<bool> HasCharacterAsync(string userId);
    }
}
