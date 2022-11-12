namespace ModeratingProject.Repository
{
    public class Result<T>
    {
        public readonly T Value;
        public readonly string Error;

        public Result(T value)
        {
            Value = value;
            Error = String.Empty;
        }
        public Result(string error)
        {
            Error = error;
        }

        public bool HasValue => String.IsNullOrEmpty(Error);

        public static implicit operator bool(Result<T> result)
        {
            return result.HasValue;
        }

    }
}