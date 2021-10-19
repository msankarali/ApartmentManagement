using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public ResultType ResultType { get; }

        public List<string> Messages { get; private set; }

        public int Code { get; set; }

        public Result(ResultType resultType)
        {
            ResultType = resultType;
        }

        public IResult AddMessage(string message)
        {
            Messages ??= new List<string>();
            Messages.Add(message);
            return this;
        }
        public IResult AddMessage(IEnumerable<string> messages)
        {
            Messages ??= new List<string>();
            Messages.AddRange(messages);
            return this;
        }
    }
}