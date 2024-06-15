﻿using App.Domain;
using Application.DTO;
using Application.UseCases.Queries.Users;
using DataAccess;
using Implementation.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Users
{
    public class EfFindUserQuery : EfUseCase, IFindUserQuery
    {
        public EfFindUserQuery(BookingContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => nameof(EfFindUserQuery);

        public UserDto Execute(int userId)
        {
            User user = Context.Users.Include(x => x.Apartments)
                                     .ThenInclude(x => x.Bookings)
                                     .FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), userId);
            }

            return new UserDto
            {
                Avatar = user.Avatar,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = userId,
            };
        }
    }
}
