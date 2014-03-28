using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// 获取微云支持的库视图类型结果
    /// </summary>
    public class GetMediaTypeResult : WeiyunBase
    {
        /// <summary>
        /// 库视图支持的类型列表
        /// </summary>
        public LibTypeList Data { get; set; }
    }

    /// <summary>
    /// 库视图支持的类型
    /// </summary>
    public class LibraryType
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }

    /// <summary>
    /// 库视图支持的类型列表
    /// </summary>
    public class LibTypeList
    {
        public List<LibraryType> LibraryTypes { get; set; }
    }
}
