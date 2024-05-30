using PersonalFinanceApp.User.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.User.Storage.Entities;
namespace PersonalFinanceApp.User.Extensions
{
    public static class UserDtoExtension
    {

        public static Entities.User ToEntity(this UserDto dto)
        {

            return new Entities.User
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
            };
        }
    }
}
