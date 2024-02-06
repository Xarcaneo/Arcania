

namespace Arcania.Models.ViewModels
{
    public class CharacterVM
    {
        public string SelectedRace { get; set; }
        public string SelectedGender { get; set; }
    }

    public class CharacterCreationVM
    {
        public CharacterVM Character { get; set; }
        public IEnumerable<Race> AvailableRaces { get; set; }
    }
}
