using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class InvalidResult<T> : Result<T>
    {
        private List<string> _errors = new List<string>();
        public InvalidResult(string error)
        {
            _errors.Add(error);
        }
        public InvalidResult(List<string> errors)
        {
            _errors.AddRange(errors);
        }
        public override ResultType ResultType => ResultType.Invalid;
        public override List<string> Errors => _errors ?? new List<string> { "The input was invalid." };

        public override T Data => default(T);
    }
}
