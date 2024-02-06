using Arcania.DataAccess.Data;
using Arcania.DataAccess.Repository.IRepository;
using Arcania.Models;
using Microsoft.EntityFrameworkCore;

namespace Arcania.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }

        public async Task CreateCharacterForUserAsync(string userId, string selectedRace, string selectedGender)
        {
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null && !user.HasCharacter)
            {
                // Look up the race by its name to get the ID
                var race = await _db.Races.FirstOrDefaultAsync(r => r.Name == selectedRace);
                if (race == null)
                {
                    // Handle the case where the race does not exist
                    // This might involve throwing an exception or handling the error in some other way
                    throw new ArgumentException("Selected race does not exist.");
                }

                var character = new Character
                {
                    RaceId = race.Id, // Use the found race's ID
                    Gender = selectedGender
                };

                // Link the new Character to the ApplicationUser
                user.Character = character;
                user.HasCharacter = true;

                await _db.SaveChangesAsync();
            }
        }
    }
}
