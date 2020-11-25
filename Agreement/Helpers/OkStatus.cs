using System.Collections.Generic;

namespace Agreement.Helpers
{
    public class OkStatus : Status
    {
        public override ResultType ResultType => ResultType.Ok;

        public override List<string> Errors => new List<string>();
    }
}
