using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacterApi.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public string Game { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;

    }
}
