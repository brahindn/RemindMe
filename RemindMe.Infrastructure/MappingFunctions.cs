using Mapster;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure
{
    public static class MappingFunctions
    {
        public static User MapUserDTOToUser(CreateUserRequest userDTO)
        {
            var user = userDTO.Adapt<User>();

            return user;
        }
    }
}
