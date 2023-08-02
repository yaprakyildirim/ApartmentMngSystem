﻿using ApartmentMngSystem.Core.Application.Dto;
using MediatR;

namespace ApartmentMngSystem.Core.Application.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}