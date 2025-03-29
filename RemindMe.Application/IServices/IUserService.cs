﻿using RemindMe.Contracts.Requests;

namespace RemindMe.Application.IServices
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest createUserRequest);
    }
}
