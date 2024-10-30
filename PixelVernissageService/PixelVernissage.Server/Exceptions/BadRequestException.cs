namespace PVS.Server.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }
    }
}
