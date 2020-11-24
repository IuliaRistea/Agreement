using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class BadRequestResult<T> : Result<T>
    {
        private List<string> _errors = new List<string>();
        public BadRequestResult(string error)
        {
            _errors.Add(error);
        }
        public BadRequestResult(List<string> errors)
        {
            _errors.AddRange(errors);
        }
        public override ResultType ResultType => ResultType.BadRequest;
        public override List<string> Errors => _errors ?? new List<string> { "Bad request." };

        public override T Data => default(T);
    }
}
