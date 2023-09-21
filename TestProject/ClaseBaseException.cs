namespace TestProject
{
    public abstract class ClaseBaseException
    {
        public ClaseBaseException(string message)
        {
            throw new ExcepcionPropia(message);
        }
    }
}