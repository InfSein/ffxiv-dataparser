using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Diagnostics;

namespace ffxiv_dataparser.Tool;

/// <summary>
/// 常规工具类
/// <para>用于存放各式会被多次多域调用的函数</para>
/// </summary>
internal static class CommonTool
{
    #region MessageBox Show
    public static void ShowMsg(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static void ShowWarn(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static void ShowError(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static bool ShowConfirm(string content, string title = "", MessageBoxIcon icon = MessageBoxIcon.Question)
    {
        return MessageBox.Show(content, title,
            MessageBoxButtons.YesNo,
            icon,
            MessageBoxDefaultButton.Button2
        ) == DialogResult.Yes;
    }
    #endregion

    #region Process String

    /// <summary>
    /// 清除不合法JSON字符
    /// </summary>
    public static string CleanJsonString(string jsonString)
    {
        var invalidCharsRegex = new Regex("[^\u0009\u000A\u000D\u0020-\u007F\u0080-\uFFFF]");
        var cleanedJsonString = invalidCharsRegex.Replace(jsonString, "");
        return cleanedJsonString;
    }

    #endregion

    #region Other

    /// <summary>
    /// 调用默认浏览器打开给定的URL
    /// </summary>
    public static void OpenUrl(string url)
    {
        dynamic? kstr;
        string s;
        try
        {
            // 从注册表中读取默认浏览器可执行文件路径
            RegistryKey? key2 = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice\");
            if (key != null)
            {
                kstr = key.GetValue("ProgId");
                if (kstr != null)
                {
                    s = kstr.ToString();
                    // "ChromeHTML","MSEdgeHTM" etc.
                    if (Registry.GetValue(@"HKEY_CLASSES_ROOT\" + s + @"\shell\open\command", null, null) is string path)
                    {
                        var split = path.Split('"');
                        path = split.Length >= 2 ? split[1] : "";
                        if (path != "")
                        {
                            Process.Start(path, url);
                            return;
                        }
                    }
                }
            }
            if (key2 != null)
            {
                kstr = key2.GetValue("");
                if (kstr != null)
                {
                    s = kstr.ToString();
                    var lastIndex = s.IndexOf(".exe", StringComparison.Ordinal);
                    if (lastIndex == -1)
                    {
                        lastIndex = s.IndexOf(".EXE", StringComparison.Ordinal);
                    }
                    var path = s.Substring(1, lastIndex + 3);
                    var result1 = Process.Start(path, url);
                    if (result1 == null)
                    {
                        var result2 = Process.Start("explorer.exe", url);
                        if (result2 == null)
                        {
                            Process.Start(url);
                        }
                    }
                }
            }
            else
            {
                var result2 = Process.Start("explorer.exe", url);
                if (result2 == null)
                {
                    Process.Start(url);
                }
            }
        }
        catch (Exception ex)
        {
            ShowError($"调用浏览器失败,因为{ex.Message}。\n链接已经被复制到您的剪贴板，请手动操作。");
            TryCopy(url);
        }
    }

    /// <summary>
    /// 尝试将给定文本复制到剪贴板
    /// </summary>
    /// <returns>是否成功复制</returns>
    public static bool TryCopy(string text)
    {
        try {
            Clipboard.SetText(text);
            return true;
        } catch {
            return false;
        }
    }

    #endregion
}
