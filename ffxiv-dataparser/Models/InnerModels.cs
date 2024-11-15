using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffxiv_dataparser.Models;

#pragma warning disable IDE1006 // 命名样式

internal class InnerModels
{
    /// <summary>
    /// 调用内部函数的结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CR<T>
    {
        /// <summary>
        /// 标志是否成功。此值不为"OK"时代表调用未成功
        /// </summary>
        public string result { get; set; } = "OK";

        /// <summary>
        /// 调用成功时，代表额外提醒；调用未成功时，代表错误提示
        /// </summary>
        public string msg { get; set; } = "";

        /// <summary>
        /// 数据，类型在初始化CR时传入。不传入时默认为string
        /// </summary>
        public T? data { get; set; }

        public CR(string result, string msg) {
            this.result = result;
            this.msg = msg;
        }
        public CR(T data) {
            this.data = data;
        }
    }
    public class CR : CR<string>
    {
        public CR() : base("")
        {
        }
    }
}

#pragma warning restore IDE1006 // 命名样式
