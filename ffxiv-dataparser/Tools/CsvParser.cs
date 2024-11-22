using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using static ffxiv_dataparser.Models.InnerModels;

namespace ffxiv_dataparser.Tools;

internal class CsvParser
{
    /// <summary>
    /// 读取给定的拆包CSV文件。自动会跳过第一行(数据index)和第三行(数据类型)
    /// </summary>
    /// <typeparam name="CsvModel">指定每一行的类型</typeparam>
    /// <param name="filePath">文件位置</param>
    public static CR<List<CsvModel>> ReadCsv<CsvModel>(string filePath)
    {
        var csvconfig = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var reader = GetCsvReader(filePath);
        using var csv = new CsvReader(reader, csvconfig);

        var records = csv.GetRecords<CsvModel>();
        if (records is null)
            return new("Error", "未读取到记录");
        else
            return new(records.ToList());
    }
    private static TextReader GetCsvReader(string filePath)
    {
        var sb = new StringBuilder();
        using var reader = new StreamReader(filePath);
        int lineNumber = 0;
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            lineNumber++;
            if (lineNumber == 1 || lineNumber == 3)
                continue;
            sb.AppendLine(line);
        }
        return new StringReader(sb.ToString());
    }
}
