﻿using Microsoft.AspNetCore.Http;
using System;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class OwnerResquest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}