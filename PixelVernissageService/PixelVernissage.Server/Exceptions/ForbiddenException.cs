namespace PVS.Server.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException() { }
        public ForbiddenException(string message) : base(message) { }
    }
}
