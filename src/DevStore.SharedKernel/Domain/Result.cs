namespace DevStore.SharedKernel.Domain
{
    public class Result
    {
        public Error Error { get; private set; }
        public bool IsSuccessful { get; private set; } = true;

        protected Result(Error? error = null)
        {
            if (error is not null)
            {
                IsSuccessful = false;
                Error = error;
            }
        }

        public static Result Success() => new();
        public static Result Failure(Error error) => new(error);
        public static Result<TValue> Success<TValue>(TValue value) => new(value);
        public static Result<TValue> Failure<TValue>(Error error) => new(default, error);
        protected static Result<TValue> CreateImplicitResult<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

        public static implicit operator Result(Error error) => Failure(error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, Error error = null)
            : base(error) =>
            _value = value;

        public TValue Value => IsSuccessful
            ? _value!
            : throw new InvalidOperationException("O valor de um resultado com erro não pode ser acessado.");

        public static implicit operator Result<TValue>(TValue? value) => CreateImplicitResult(value);
        public static implicit operator Result<TValue>(Error error) => Failure<TValue>(error);
    }
}
