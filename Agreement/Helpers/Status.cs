using System.Collections.Generic;

namespace Agreement.Helpers
{
    public abstract class Status
    {
        public abstract ResultType ResultType { get; }
        public abstract List<string> Errors { get; }
    }
}
