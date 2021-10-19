using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<out TData> : IResult
    {
        TData Data { get; }
        new IDataResult<TData> AddMessage(string message);
        new IDataResult<TData> AddMessage(IEnumerable<string> message);
    }
}