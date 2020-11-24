using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public abstract class Status
    {
        public abstract ResultType ResultType { get; }
        public abstract List<string> Errors { get; }
    }
}
