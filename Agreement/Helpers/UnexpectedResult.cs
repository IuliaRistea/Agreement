using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class UnexpectedResult<T> : Result<T>
    {
        public override ResultType ResultType => ResultType.Unexpected;

        public override string Error => "There was an unexpected problem";

        public override T Data => default(T);
    }
}
