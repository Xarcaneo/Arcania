using Arcania.DataAccess.Data;
using Arcania.Models;
using Microsoft.EntityFrameworkCore;

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
                var user = await _db.ApplicationUsers
                                    .Include(u => u.Character) // Make sure to include the Character navigation property
                                    .FirstOrDefaultAsync(u => u.Id == userId);
                return user != null && user.HasCharacter;
            }

            public async Task CreateCharacterForUserAsync(string userId, string selectedRace, string selectedGender)
            {
                var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null && !user.HasCharacter)
                {
                    // Instantiate a new Character object
                    var character = new Character
                    {
                        RaceId = ConvertRaceToRaceId(selectedRace),
                        Gender = selectedGender
                    };

                    // Add the new Character to the database
                    _db.Characters.Add(character);
                    await _db.SaveChangesAsync();

                    // Link the Character with the ApplicationUser
                    user.Character = character;
                    user.HasCharacter = true;

                    await _db.SaveChangesAsync();
                }
            }

            private int ConvertRaceToRaceId(string selectedRace)
            {
                // Implement logic to convert race name to race ID
                // This is a placeholder and needs implementation based on your Race configuration
                return _db.Races.FirstOrDefault(r => r.Name == selectedRace)?.Id ?? 0;
            }
        }
    }

}
