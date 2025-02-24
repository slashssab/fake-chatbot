namespace FakeChatbot.Resources.Api.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string errorCode) : base(errorCode) { }

        public NotFoundException(string errorCode, Exception innerException) : base(errorCode, innerException) { }
    }
}
