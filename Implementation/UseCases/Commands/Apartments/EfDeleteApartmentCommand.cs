﻿using App.Domain;
using Application;
using Application.DTO.Apartments;
using Application.Exceptions;
using Application.UseCases.Commands.Apartments;
using DataAccess;
using Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Apartments
{
    public class EfDeleteApartmentCommand : EfDeleteCommand<Apartment>, IDeleteApartmentCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteApartmentCommand(BookingContext context, IApplicationActor actor) 
            : base(context)
        {
            _actor = actor;
        }

        public override int Id => 17;

        public override string Name => nameof(EfDeleteApartmentCommand);

        public override void Execute(int id)
        {
            var apartment = Context.Apartments.FirstOrDefault(x => x.Id == id);

            if(apartment.UserId != _actor.Id)
            {
                throw new ConflictException("Apartment can not be deleted");
            }

            base.Execute(id);
        }


    }
}
