using CsvHelper.Configuration.Attributes;

namespace ffxiv_dataparser.Models.CsvTypes;

// https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
internal class CsvTypes
{
    public class Item
    {
        [Name("#")]
        public required int Id { get; set; }

        [Name("Name")]
        public required string Name { get; set; }

        [Name("Description")]
        public required string Description { get; set; }
    }
}
