namespace DevStore.SharedKernel.Domain
{
    public record Error(string Message)
    {
        public static readonly Error NullValue = new("O valor especificado é nulo.");
        public static readonly Error NotFound = new("Recurso não encontrado.");
    };
}