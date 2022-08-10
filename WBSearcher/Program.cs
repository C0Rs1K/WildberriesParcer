using OfficeOpenXml;
using WBSearcher.DataReader;
using WBSearcher.DataWriter;
using WBSearcher.Models;

var reader = new FileDataReader(new FileInfo("Keys.txt"));

var requests = reader.ReadAllDataAsync();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
using var package = new ExcelPackage(new FileInfo("result.xlsx"));

await foreach (var request in requests)
{
    var parcer = new WBParcer(new ExcelDataWriter<Card>(package, request), request);
    await parcer.SaveCardsAsync();
}
