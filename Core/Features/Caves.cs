﻿using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Features
{
    public class Caves : IFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private List<IClimate> ClimateRestrictions { get; set; }

        // TODO: constructor that generates a name
    }
}
