using System.Linq;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRunner
    {
        public static bool CheckAny(ResultType resultType, params IResult[] results)
            => results.Any(result => result.ResultType == resultType);

        public static bool CheckDifferent(ResultType resultType, params IResult[] results)
            => results.Any(result => result.ResultType != resultType);
    }
}