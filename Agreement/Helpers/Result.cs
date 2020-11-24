using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }
        public abstract string Error { get; }
        public abstract T Data { get; }
    }
}
