// ***********************************************************************************
//  Created by zbw911 
//  创建于：2013年03月14日 13:21
//  
//  修改于：2013年03月14日 13:57
//  文件名：NewArchitecture/Dev.DotNetOpenAuth.AspNetExtend/UrlUtilities.cs
//  
//  如果有更好的建议或意见请邮件至 zbw911#gmail.com
// ***********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.DotNetOpenAuth.AspNetExtend
{
    public static class UrlUtilities
    {
        internal static void AppendQueryArgs(this UriBuilder builder, IEnumerable<KeyValuePair<string, string>> args)
        {
            if (args != null && args.Any())
            {
                StringBuilder stringBuilder = new StringBuilder(50 + args.Count<KeyValuePair<string, string>>()*10);
                if (!string.IsNullOrEmpty(builder.Query))
                {
                    stringBuilder.Append(builder.Query.Substring(1));
                    stringBuilder.Append('&');
                }
                stringBuilder.Append(CreateQueryString(args));
                builder.Query = stringBuilder.ToString();
            }
        }

        /// <summary>
        ///   Concatenates a list of name-value pairs as key=value&amp;key=value,
        ///   taking care to properly encode each key and value for URL
        ///   transmission according to RFC 3986.  No ? is prefixed to the string.
        /// </summary>
        /// <param name="args"> The dictionary of key/values to read from. </param>
        /// <returns> The formulated querystring style string. </returns>
        internal static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> args)
        {
            if (!args.Any<KeyValuePair<string, string>>())
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder(args.Count<KeyValuePair<string, string>>()*10);
            foreach (KeyValuePair<string, string> current in args)
            {
                //stringBuilder.Append((current.Key));
                //stringBuilder.Append('=');
                //stringBuilder.Append((current.Value));
                //stringBuilder.Append('&');

                stringBuilder.Append(UrlUtilities.EscapeUriDataStringRfc3986(current.Key));
                stringBuilder.Append('=');
                stringBuilder.Append(UrlUtilities.EscapeUriDataStringRfc3986(current.Value));
                stringBuilder.Append('&');
            }
            stringBuilder.Length--;
            return stringBuilder.ToString();
        }

        /// <summary>
        ///   Escapes a string according to the URI data string rules given in RFC 3986.
        /// </summary>
        /// <param name="value"> The value to escape. </param>
        /// <returns> The escaped value. </returns>
        /// <remarks>
        ///   The <see cref="M:System.Uri.EscapeDataString(System.String)" /> method is <i>supposed</i> to take on
        ///   RFC 3986 behavior if certain elements are present in a .config file.  Even if this
        ///   actually worked (which in my experiments it <i>doesn't</i>), we can't rely on every
        ///   host actually having this configuration element present.
        /// </remarks>
        internal static string EscapeUriDataStringRfc3986(string value)
        {
            StringBuilder stringBuilder = new StringBuilder(Uri.EscapeDataString(value));
            for (int i = 0; i < UrlUtilities.UriRfc3986CharsToEscape.Length; i++)
            {
                stringBuilder.Replace(UrlUtilities.UriRfc3986CharsToEscape[i],
                                      Uri.HexEscape(UrlUtilities.UriRfc3986CharsToEscape[i][0]));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        ///   The set of characters that are unreserved in RFC 2396 but are NOT unreserved in RFC 3986.
        /// </summary>
        private static readonly string[] UriRfc3986CharsToEscape = new string[]
                                                                       {
                                                                           "!",
                                                                           "*",
                                                                           "'",
                                                                           "(",
                                                                           ")"
                                                                       };
    }
}