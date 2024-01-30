using Arcania.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcania.Services
{
    public class UserCharacterService : IUserCharacterService
    {
        private readonly ApplicationDbContext _db;

        public UserCharacterService(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> HasCharacterAsync(string userId)
        {
            // Check if the user with the given userId has a character
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);
            return user != null && user.HasCharacter;
        }
    }
}
