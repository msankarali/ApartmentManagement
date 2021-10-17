namespace Core.Utilities.Results
{
    public static class ResultTypeExtensions
    {
        public static ResultType[] Params(this ResultType resultType, params ResultType[] resultTypes)
        {
            return resultTypes;
        }
    }
}