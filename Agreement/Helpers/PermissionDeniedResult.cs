using System.Collections.Generic;

namespace Agreement.Helpers
{
    public class PermissionDeniedResult<T> : Result<T>
    {
        private List<string> _errors = new List<string>();
        public PermissionDeniedResult(string error)
        {
            _errors.Add(error);
        }
        public PermissionDeniedResult(List<string> errors)
        {
            _errors.AddRange(errors);
        }
        public override ResultType ResultType => ResultType.PermissionDenied;
        public override List<string> Errors => _errors ?? new List<string> { "Permission Denied." };
        public override T Data => default(T);
    }
}
