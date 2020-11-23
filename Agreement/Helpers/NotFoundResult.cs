using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class NotFoundResult<T> : Result<T>
    {
        private string _error;
        public NotFoundResult(string error)
        {
            _error = error;
        }
        public override ResultType ResultType => ResultType.NotFound;

        public override List<string> Errors => new List<string> { _error ?? "The input was not found." };

        public override T Data => default(T);
    }
}
