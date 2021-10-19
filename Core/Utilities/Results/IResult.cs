using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        ResultType ResultType { get; }
        List<string> Messages { get; }
        IResult AddMessage(string message);
        IResult AddMessage(IEnumerable<string> messages);
        int Code { get; set; }
    }
}