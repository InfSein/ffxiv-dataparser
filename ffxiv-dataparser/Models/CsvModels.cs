using CsvHelper.Configuration.Attributes;

namespace ffxiv_dataparser.Models;

// https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
internal class CsvModels
{
    public class Item
    {
        [Name("#")]
        public required int Id { get; set; }

        [Name("Name")]
        public required string Name { get; set; }

        [Name("Description")]
        public required string Description { get; set; }

        [Name("Icon")]
        public required int Icon { get; set; }

        [Name("Level{Item}")]
        public required int ItemLevel { get; set; }

        [Name("Rarity")]
        public required int Rarity { get; set; }

        [Name("ItemUICategory")]
        public required int ItemUICategory { get; set; }

        [Name("StackSize")]
        public required long StackSize { get; set; }

        [Name("IsUnique")]
        public required bool IsUnique { get; set; }

        [Name("IsUntradable")]
        public required bool IsUntradable { get; set; }

        [Name("IsIndisposable")]
        public required bool IsIndisposable { get; set; }

        [Name("CanBeHq")]
        public required bool CanBeHq { get; set; }

        [Name("IsCollectable")]
        public required bool IsCollectable { get; set; }

        [Name("AlwaysCollectable")]
        public required bool AlwaysCollectable { get; set; }

        [Name("AetherialReduce")]
        public required int AetherialReduce { get; set; }

        [Name("Level{Equip}")]
        public required int EquipLevel { get; set; }

        [Name("ClassJobCategory")]
        public required int ClassJobCategory { get; set; }

        [Name("ClassJob{Use}")]
        public required int UseClassJob { get; set; }

        [Name("Defense{Phys}")]
        public required int PhysDefense { get; set; }

        [Name("Defense{Mag}")]
        public required int MagDefense { get; set; }

        [Name("BaseParam[0]")]
        public required int BaseParamKey0 { get; set; }

        [Name("BaseParamValue[0]")]
        public required int BaseParamValue0 { get; set; }

        [Name("BaseParam[1]")]
        public required int BaseParamKey1 { get; set; }

        [Name("BaseParamValue[1]")]
        public required int BaseParamValue1 { get; set; }

        [Name("BaseParam[2]")]
        public required int BaseParamKey2 { get; set; }

        [Name("BaseParamValue[2]")]
        public required int BaseParamValue2 { get; set; }

        [Name("BaseParam[3]")]
        public required int BaseParamKey3 { get; set; }

        [Name("BaseParamValue[3]")]
        public required int BaseParamValue3 { get; set; }

        [Name("BaseParam[4]")]
        public required int BaseParamKey4 { get; set; }

        [Name("BaseParamValue[4]")]
        public required int BaseParamValue4 { get; set; }

        [Name("BaseParam[5]")]
        public required int BaseParamKey5 { get; set; }

        [Name("BaseParamValue[5]")]
        public required int BaseParamValue5 { get; set; }

        [Name("BaseParam{Special}[0]")]
        public required int BaseParamSpecialKey0 { get; set; }

        [Name("BaseParamValue{Special}[0]")]
        public required int BaseParamSpecialValue0 { get; set; }

        [Name("BaseParam{Special}[1]")]
        public required int BaseParamSpecialKey1 { get; set; }

        [Name("BaseParamValue{Special}[1]")]
        public required int BaseParamSpecialValue1 { get; set; }

        [Name("BaseParam{Special}[2]")]
        public required int BaseParamSpecialKey2 { get; set; }

        [Name("BaseParamValue{Special}[2]")]
        public required int BaseParamSpecialValue2 { get; set; }

        [Name("BaseParam{Special}[3]")]
        public required int BaseParamSpecialKey3 { get; set; }

        [Name("BaseParamValue{Special}[3]")]
        public required int BaseParamSpecialValue3 { get; set; }

        [Name("BaseParam{Special}[4]")]
        public required int BaseParamSpecialKey4 { get; set; }

        [Name("BaseParamValue{Special}[4]")]
        public required int BaseParamSpecialValue4 { get; set; }

        [Name("BaseParam{Special}[5]")]
        public required int BaseParamSpecialKey5 { get; set; }

        [Name("BaseParamValue{Special}[5]")]
        public required int BaseParamSpecialValue5 { get; set; }
    }
}
