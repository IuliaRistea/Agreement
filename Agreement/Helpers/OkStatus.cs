using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class OkStatus : Status
    {
        public override ResultType ResultType => ResultType.Ok;

        public override List<string> Errors => new List<string>();
    }
}
