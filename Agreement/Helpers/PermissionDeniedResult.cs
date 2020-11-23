using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class PermissionDeniedResult<T> : Result<T>
    {
        private string _error;
        public PermissionDeniedResult(string error)
        {
            _error = error;
        }
        public override ResultType ResultType => ResultType.PermissionDenied;

        public override List<string> Errors => new List<string> { _error ?? "Permission Denied." };

        public override T Data => default(T);
    }
}
