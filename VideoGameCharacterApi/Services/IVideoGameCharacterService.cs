using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterDto>> GetAllCharactersAsync();

        Task<CharacterDto?> GetCharacterByIdAsync(int id);

        Task<Character> AddCharacterAsync(CharacterDto character);

        Task<bool> UpdateCharacterAsync(int id, CharacterDto character);

        Task<bool> DeleteCharacterAsync(int id);
    }
}
