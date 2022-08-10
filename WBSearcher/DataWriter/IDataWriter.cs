namespace WBSearcher.DataWriter
{
    public interface IDataWriter<T>
    {
        Task WriteAsync(List<T> collection);
    }
}
    