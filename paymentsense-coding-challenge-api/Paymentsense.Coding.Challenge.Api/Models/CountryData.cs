﻿using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class CountryData
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public List<string> TimeZones { get; set; }
        public string Capital { get; set; }
        public List<string> Borders { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }

    }
}