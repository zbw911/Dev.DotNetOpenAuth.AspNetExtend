using System;

namespace Dev.DotNetOpenAuth.AspNetExtend.Client.SinaModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Status
    {
        /// <summary>
        /// 字符串型的微博ID
        /// </summary>
        public string idstr { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// 微博ID
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 微博信息内容
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 微博来源
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// 是否已收藏
        /// </summary>
        public bool favorited { get; set; }

        /// <summary>
        /// 是否被截断
        /// </summary>
        public bool truncated { get; set; }

        /// <summary>
        /// 回复ID
        /// </summary>
        public string in_reply_to_status_id { get; set; }

        /// <summary>
        /// 回复人UID
        /// </summary>
        public string in_reply_to_user_id { get; set; }

        /// <summary>
        /// 回复人昵称
        /// </summary>
        public string in_reply_to_screen_name { get; set; }

        /// <summary>
        /// 微博MID
        /// </summary>
        public long mid { get; set; }

        /// <summary>
        /// 中等尺寸图片地址
        /// </summary>
        public string bmiddle_pic { get; set; }

        /// <summary>
        /// 原始图片地址
        /// </summary>
        public string original_pic { get; set; }

        /// <summary>
        /// 缩略图片地址
        /// </summary>
        public string thumbnail_pic { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        public int reposts_count { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public int comments_count { get; set; }

        /// <summary>
        /// 微博附加注释信息
        /// </summary>
        public Array annotations { get; set; }

        /// <summary>
        /// 微博作者的用户信息字段
        /// </summary>
        public User user { get; set; }
    }
}