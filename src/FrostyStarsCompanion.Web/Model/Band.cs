using System;
using System.Collections.Generic;

namespace FrostyStarsCompanion.Web.Model
{
    public abstract class Band<T>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<T> Members { get; set; }
    }
}