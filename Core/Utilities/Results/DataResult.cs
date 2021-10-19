using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public DataResult(ResultType resultType, TData data = default) : base(resultType) => Data = data;

        public TData Data { get; private set; }

        public new IDataResult<TData> AddMessage(string message)
        {
            base.AddMessage(message);
            return this;
        }

        public new IDataResult<TData> AddMessage(IEnumerable<string> messages)
        {
            base.AddMessage(messages);
            return this;
        }
    }
}