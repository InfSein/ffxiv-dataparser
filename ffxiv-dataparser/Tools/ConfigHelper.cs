using ffxiv_dataparser.Tool;
using System.Text.Json;

namespace ffxiv_dataparser.Tools;

/// <summary>
/// 常规设置项的储存与控制类
/// </summary>
internal class ConfigHelper
{
    /** 
     * 使用自动序列化/反序列化的Dictionary<string, string>来存储和读取各式设置项目。
     * 要添加设置项目,在`Properties`分区添加一个属性，get/set分别调用`Basic`内封装的方法。
     * 请注意，各个设置项之间的Key不应重复。
     */

    #region Basic

    private static readonly string configPath = Environment.CurrentDirectory + @"\config\common.json";
    private static Dictionary<string, string> Content
    {
        get
        {
            var s = LocalFile.Read(configPath);
            if (s.Length <= 1) s = "{}";
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(s);
            dict ??= [];
            return dict;
        }
        set
        {
            var s = JsonSerializer.Serialize(value);
            LocalFile.Write(configPath, s);
        }
    }

    private static string GetString(string key)
    {
        var c = Content;
        if (c.TryGetValue(key, out string? value))
            return value;
        return string.Empty;
    }
    private static void SetString(string key, string value)
    {
        var c = Content;
        if (!c.TryAdd(key, value))
            c[key] = value;
        Content = c;
    }

    private static bool GetBool(string key)
    {
        var c = Content;
        if (c.TryGetValue(key, out string? value))
            return bool.Parse(value);
        return false;
    }
    private static void SetBool(string key, bool value)
    {
        var c = Content;
        var valueS = value.ToString();
        if (!c.TryAdd(key, valueS))
            c[key] = valueS;
        Content = c;
    }

    private static int GetInt(string key)
    {
        var c = Content;
        if (c.TryGetValue(key, out string? value))
            return int.Parse(value);
        return 0;
    }
    private static void SetInt(string key, int value)
    {
        var c = Content;
        var valueS = value.ToString();
        if (!c.TryAdd(key, valueS))
            c[key] = valueS;
        Content = c;
    }

    #endregion

    #region Properties

    #region Sample
    /*
    public static int MainformReplacer_RuleCbx_LastSelectIndex
    {
        get { return GetInt("MainformReplacer_RuleCbx_LastSelectIndex"); }
        set { SetInt("MainformReplacer_RuleCbx_LastSelectIndex", value); }
    }
    public static int MainformReplacer_SubRuleCbx_LastSelectIndex
    {
        get { return GetInt("MainformReplacer_SubRuleCbx_LastSelectIndex"); }
        set { SetInt("MainformReplacer_SubRuleCbx_LastSelectIndex", value); }
    }
    */
    #endregion

    #endregion
}
