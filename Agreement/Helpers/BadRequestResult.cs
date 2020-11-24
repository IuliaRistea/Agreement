using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class BadRequestResult<T> :Result<T>
    {
        private string _error;
        public BadRequestResult(string error)
        {
            _error = error;
        }
        public BadRequestResult(List<string> errors)
        {
            _error = string.Join(". ", errors );
        }
        public override ResultType ResultType => ResultType.BadRequest;

        public override string Error =>  _error ?? "Bad request." ;

        public override T Data => default(T);
    }
}
