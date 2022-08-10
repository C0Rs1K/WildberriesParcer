using OfficeOpenXml;

namespace WBSearcher.DataWriter
{
    public class ExcelDataWriter<T> : IDataWriter<T>
    {
        private readonly ExcelPackage _package;
        private readonly string _workSheetName;
        private readonly string _cell; 

        public ExcelDataWriter(ExcelPackage package, string workSheetName = "Result", string cellToWrite = "A1")
        {
            _package = package;
            _workSheetName = workSheetName;
            _cell = cellToWrite;
        }

        public async Task WriteAsync(List<T> collection)
        {
            var worksheets = _package.Workbook.Worksheets;
            var worksheet = worksheets.Any(x => x.Name == _workSheetName) ?
                worksheets.First(x => x.Name == _workSheetName) 
                : worksheets.Add(_workSheetName);

            var range = worksheet.Cells[_cell].LoadFromCollection(collection, true);
            range.AutoFitColumns();

            await _package.SaveAsync();
        }
    }
}
