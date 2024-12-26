namespace ClinicaApiCore.DTOs
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        protected Result(T value, string error)
        {
            IsSuccess = value != null;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T Value) => new Result<T>(Value, null);
        public static Result<T> Failure(string Error) => new Result<T>(default, Error);
    }
}
