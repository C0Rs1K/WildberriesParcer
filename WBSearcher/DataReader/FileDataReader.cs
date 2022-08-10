namespace WBSearcher.DataReader
{
    public class FileDataReader
    {
        private readonly FileInfo _file;

        public FileDataReader(FileInfo file)
        {
            _file = file;
        }

        public async IAsyncEnumerable<string> ReadAllDataAsync()
        {
            var stream = new StreamReader(_file.FullName);
            while (!stream.EndOfStream)
            {
                yield return (await stream.ReadLineAsync())!;
            }
        }
    }
}
