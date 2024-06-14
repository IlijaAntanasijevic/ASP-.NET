﻿using Application.DTO;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateApartmentTypeValidator : AbstractValidator<NamedDto>
    {
        private BookingContext _context;
        public CreateApartmentTypeValidator(BookingContext context)
        {
            _context = context;
            RuleFor(x => x.Name).NotNull()
                                .WithMessage("Category name is required.")
                                .MinimumLength(3)
                                .WithMessage("Min number of characters is 3.")
                                .Must(name => !_context.ApartmentTypes.Any(x => x.Name == name))
                                .WithMessage("Apartmen name is in use.");
        }
    }
}