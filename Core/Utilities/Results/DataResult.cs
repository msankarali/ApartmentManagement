using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public DataResult(ResultType resultType, TData data) : base(resultType) => Data = data;

        public TData Data { get; private set; }
    }
}