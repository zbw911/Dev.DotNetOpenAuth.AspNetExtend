namespace Dev.DotNetOpenAuth.AspNetExtend.Client.SinaModel
{
    public class User
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string screen_name { get; set; }

        /// <summary>
        /// 友好显示名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户所在地区ID
        /// </summary>
        public int province { get; set; }

        /// <summary>
        /// 用户所在城市ID
        /// </summary>
        public int city { get; set; }

        /// <summary>
        /// 用户所在地
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 用户博客地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string profile_image_url { get; set; }

        /// <summary>
        /// 用户的个性化域名
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        /// 性别，m：男、f：女、n：未知
        /// </summary>
        public string gender { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        public int followers_count { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int friends_count { get; set; }

        /// <summary>
        /// 微博数
        /// </summary>
        public int statuses_count { get; set; }

        /// <summary>
        /// 收藏数
        /// </summary>
        public int favourites_count { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// 当前登录用户是否已关注该用户
        /// </summary>
        public bool following { get; set; }

        /// <summary>
        /// 是否允许所有人给我发私信
        /// </summary>
        public bool allow_all_act_msg { get; set; }

        /// <summary>
        /// 是否允许带有地理信息
        /// </summary>
        public bool geo_enabled { get; set; }

        /// <summary>
        /// 是否是微博认证用户，即带V用户
        /// </summary>
        public bool verified { get; set; }

        /// <summary>
        /// 是否允许所有人对我的微博进行评论
        /// </summary>
        public bool allow_all_comment { get; set; }

        /// <summary>
        /// 用户大头像地址
        /// </summary>
        public string avatar_large { get; set; }

        /// <summary>
        /// 认证原因
        /// </summary>
        public string verified_reason { get; set; }

        /// <summary>
        /// 该用户是否关注当前登录用户
        /// </summary>
        public bool follow_me { get; set; }

        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        public int online_status { get; set; }

        /// <summary>
        /// 用户的互粉数
        /// </summary>
        public int bi_followers_count { get; set; }

        /// <summary>
        /// 用户的最近一条微博信息字段
        /// </summary>
        public Status status { get; set; }
    }
}