namespace KonusarakOgren.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data) : base(Data, false)
        {
        }

        public ErrorDataResult(T Data, string message) : base(Data, false, message)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {
        }
    }
}