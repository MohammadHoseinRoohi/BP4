using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice02.Entities.Base
{
    public abstract class Thing
    {
        public int Id { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
    }
}