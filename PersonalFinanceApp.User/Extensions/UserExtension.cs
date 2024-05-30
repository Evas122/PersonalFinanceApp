using PersonalFinanceApp.User.CrossCutting.Dtos;

namespace PersonalFinanceApp.User.Extensions
{
    public static class UserExtension
    {
        public static UserDto ToDto(this PersonalFinanceApp.User.Storage.Entities.User entity)
        {

            return new UserDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
            };
        }
    }
}
