﻿using Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Apartments
{
    public class ApartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxGuests { get; set; }
        public decimal PricePerNight { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public UserDto User { get; set; }
        public string ApartmentType { get; set; }
    }
}