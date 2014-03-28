// ***********************************************************************************
//  Created by zbw911 
//  创建于：2013年03月14日 13:21
//  
//  修改于：2013年03月14日 13:57
//  文件名：NewArchitecture/Dev.DotNetOpenAuth.AspNetExtend/DictionaryExtensions.cs
//  
//  如果有更好的建议或意见请邮件至 zbw911#gmail.com
// ***********************************************************************************

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Dev.DotNetOpenAuth.AspNetExtend
{
    /// <summary>
    ///   The dictionary extensions.
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        ///   Adds the value from an XDocument with the specified element name if it's not empty.
        /// </summary>
        /// <param name="dictionary"> The dictionary. </param>
        /// <param name="document"> The document. </param>
        /// <param name="elementName"> Name of the element. </param>
        public static void AddDataIfNotEmpty(this Dictionary<string, string> dictionary, XDocument document,
                                             string elementName)
        {
            XElement xElement = document.Root.Element(elementName);
            if (xElement != null)
            {
                dictionary.AddItemIfNotEmpty(elementName, xElement.Value);
            }
        }

        /// <summary>
        ///   Adds a key/value pair to the specified dictionary if the value is not null or empty.
        /// </summary>
        /// <param name="dictionary"> The dictionary. </param>
        /// <param name="key"> The key. </param>
        /// <param name="value"> The value. </param>
        public static void AddItemIfNotEmpty(this IDictionary<string, string> dictionary, string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!string.IsNullOrEmpty(value))
            {
                dictionary[key] = value;
            }
        }
    }
}