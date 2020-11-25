using System.Collections.Generic;

namespace Agreement.Helpers
{
    public class NotFoundResult<T> : Result<T>
    {
        private List<string> _errors = new List<string>();
        public NotFoundResult(string error)
        {
            _errors.Add(error);
        }
        public NotFoundResult(List<string> errors)
        {
            _errors.AddRange(errors);
        }
        public override ResultType ResultType => ResultType.NotFound;
        public override List<string> Errors => _errors ?? new List<string> { "The input was not found." };
        public override T Data => default(T);
    }
}
