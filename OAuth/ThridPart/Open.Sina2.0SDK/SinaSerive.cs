/*API文档更新时间: 2012-03-19*/
/*作者:http://weibo.com/u/1716169737*/
/*备注:地理信息 API未完成*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace Open.Sina2SDK
{
    public class SinaSerive:OAuthBase,ISerive
    {
        ILog logger = LogManager.GetLogger(typeof(SinaSerive));
        #region 构造函数
        public SinaSerive(string app_key, string app_secret, string redirect_uri)
            : base(app_key, app_secret, redirect_uri)
        { }

        public SinaSerive()
            : base()
        { }
        #endregion

        #region 微博
        #region 读取接口
        #region 获取最新的公共微博
        /// <summary>
        /// 获取最新的公共微博
        /// </summary>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Statuses Statuses_Public_Timeline(int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Statuses>("statuses/public_timeline.json", dictionary);
        }
        #endregion

        #region 获取当前登录用户及其所关注用户的最新微博
        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="feature">过滤类型ID,默认为All。</param>
        /// <returns></returns>
        public Statuses Statuses_Friends_Timeline(long? since_id, long? max_id, int? page, int? count, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(feature??Feature.All)}
            };
            return HttpGet<Statuses>("statuses/friends_timeline.json", dictionary);
        }
        #endregion

        #region 获取当前登录用户及其所关注用户的最新微博
        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="feature">过滤类型ID，默认为All。</param>
        /// <returns></returns>
        public Statuses Statuses_Home_Timeline(long? since_id, long? max_id, int? page, int? count, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(feature??Feature.All)}
            };
            return HttpGet<Statuses>("statuses/home_timeline.json", dictionary); 
        }
        #endregion        

        #region 获取当前登录用户及其所关注用户的最新微博的ID
        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博的ID
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="feature">过滤类型ID，默认为All。</param>
        /// <returns></returns>
        public string Statuses_Friends_Timeline_Ids(long? since_id, long? max_id, int? page, int? count, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(feature??Feature.All)}
            };
            return HttpGet("statuses/friends_timeline/ids.json", dictionary);
        }
        #endregion

        #region 获取某个用户最新发表的微博列表
        /// <summary>
        /// 获取某个用户最新发表的微博列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="trim_user">返回值中user信息开关，0：返回完整的user信息、1：user字段仅返回user_id，默认为0。</param>
        /// <param name="feature">过滤类型ID，默认为All。</param>
        /// <returns></returns>
        public Statuses Statuses_User_Timeline(long uid, long? since_id, long? max_id, int? page, int? count, int? trim_user, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid},
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"trim_user",trim_user??0},
                {"feature",(int)(feature??Feature.All)}
            };
            return HttpGet<Statuses>("statuses/user_timeline.json", dictionary); 
        }
        #endregion

        #region 获取用户发布的微博的ID
        /// <summary>
        /// 获取用户发布的微博的ID
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="trim_user">返回值中user信息开关，0：返回完整的user信息、1：user字段仅返回user_id，默认为0。</param>
        /// <param name="feature">过滤类型ID，默认为All。</param>
        /// <returns></returns>
        public string Statuses_User_Timeline_Ids(int uid, long? since_id, long? max_id, int? page, int? count, int? trim_user, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid},
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"trim_user",trim_user??0},
                {"feature",(int)(feature??Feature.All)}
            };
            return HttpGet("statuses/user_timeline/ids.json", dictionary); 
        }
        #endregion

        #region 获取指定微博的转发微博列表
        /// <summary>
        /// 获取指定微博的转发微博列表
        /// </summary>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，默认为All。</param>
        /// <returns></returns>
        public Reposts Statuses_Repost_Timeline(long id, long? since_id, long? max_id, int? page, int? count,FilterByAuthor? filter_by_author)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id},
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(filter_by_author??FilterByAuthor.All)}
            };
            return HttpGet<Reposts>("statuses/repost_timeline.json", dictionary); 
        }
        #endregion

        #region 获取指定微博的转发微博的ID
        /// <summary>
        /// 获取指定微博的转发微博的ID
        /// </summary>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，默认为All。</param>
        /// <returns></returns>
        public string Statuses_Repost_Timeline_Ids(long id, long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id},
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(filter_by_author??FilterByAuthor.All)}
            };
            return HttpGet("statuses/repost_timeline/ids.json", dictionary);
        }
        #endregion

        #region 获取当前用户最新转发的微博列表
        /// <summary>
        /// 获取当前用户最新转发的微博列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Reposts Statuses_Repost_By_Me(long? since_id, long? max_id, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Reposts>("statuses/repost_by_me.json", dictionary); 
        }
        #endregion

        #region 获取@当前用户的最新微博
        /// <summary>
        /// 获取最新的提到登录用户的微博列表，即@我的微博
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。</param>
        /// <param name="filter_by_type">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
        /// <returns></returns>
        public Statuses Statuses_Mentions(long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author, FilterBySource? filter_by_source, FilterByType? filter_by_type)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_author",(int)(filter_by_author??FilterByAuthor.All)},
                {"filter_by_source",(int)(filter_by_source??FilterBySource.All)},
                {"filter_by_type",(int)(filter_by_type??FilterByType.All)}
            };
            return HttpGet<Statuses>("statuses/mentions.json", dictionary);
        }
        #endregion

        #region 获取@当前用户的最新微博的ID
        /// <summary>
        /// 获取@当前用户的最新微博的ID
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。</param>
        /// <param name="filter_by_type">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
        /// <returns></returns>
        public string Statuses_Mentions_Ids(long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author, FilterBySource? filter_by_source, FilterByType? filter_by_type)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_author",(int)(filter_by_author??FilterByAuthor.All)},
                {"filter_by_source",(int)(filter_by_source??FilterBySource.All)},
                {"filter_by_type",(int)(filter_by_type??FilterByType.All)}
            };
            return HttpGet("statuses/mentions/ids.json", dictionary);
        }
        #endregion

        #region 获取双向关注用户的最新微博
        /// <summary>
        /// 获取双向关注用户的最新微博
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <returns></returns>
        public Statuses Statuses_Bilateral_Timeline(long? since_id, long? max_id, int? page, int? count, Feature? feature)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"feature",(int)(feature??Feature.All)},
            };
            return HttpGet<Statuses>("statuses/bilateral_timeline.json", dictionary);
        }
        #endregion

        #region 根据ID获取单条微博信息
        /// <summary>
        /// 根据微博ID获取单条微博内容
        /// </summary>
        /// <param name="id">需要获取的微博ID。</param>
        /// <returns></returns>
        public Status Statuses_Show(long id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id}
            };
            return HttpGet<Status>("statuses/show.json", dictionary);
        }
        #endregion

        #region 通过id获取mid
        /// <summary>
        /// 通过微博（评论、私信）ID获取其MID
        /// </summary>
        /// <param name="id">需要查询的微博（评论、私信）ID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="is_batch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public string Statuses_Querymid(string id, int? type, int? is_batch)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id},
                {"type",type??1},
                {"is_batch",is_batch??0}
            };
            return HttpGet("statuses/querymid.json", dictionary);
        }
        #endregion

        #region 通过mid获取id
        /// <summary>
        /// 通过微博（评论、私信）MID获取其ID
        /// </summary>
        /// <param name="mid">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="is_batch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <param name="inbox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。</param>
        /// <param name="isBase62">MID是否是base62编码，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public string Statuses_Queryid(string mid, int? type, int? is_batch, int? inbox, int? isBase62)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"mid",mid},
                {"type",type??1},
                {"is_batch",is_batch??0},
                {"inbox",inbox??0},
                {"isBase62",isBase62??0}
            };
            return HttpGet("statuses/queryid.json", dictionary);
        }
        #endregion

        #region 按天返回热门转发榜
        /// <summary>
        /// 按天返回热门微博转发榜的微博列表
        /// </summary>
        /// <param name="count">返回的记录条数，最大不超过50，默认为20。</param>
        /// <returns></returns>
        public IList<Status> Statuses_Hot_Repost_Daily(int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"count",count??20}
            };
            return HttpGet<IList<Status>>("statuses/hot/repost_daily.json", dictionary);
        }
        #endregion

        #region 按周返回热门转发榜
        /// <summary>
        /// 按周返回热门微博转发榜的微博列表
        /// </summary>
        /// <param name="count">返回的记录条数，最大不超过50，默认为20。</param>
        /// <returns></returns>
        public IList<Status> Statuses_Hot_Repost_Weekly(int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"count",count??20}
            };
            return HttpGet<IList<Status>>("statuses/hot/repost_weekly.json", dictionary);
        }
        #endregion

        #region 按天返回热门评论榜
        /// <summary>
        /// 按天返回热门微博评论榜的微博列表
        /// </summary>
        /// <param name="count">返回的记录条数，最大不超过50，默认为20。</param>
        /// <returns></returns>
        public IList<Status> Statuses_Hot_Comments_Daily(int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"count",count??20}
            };
            return HttpGet<IList<Status>>("statuses/hot/comments_daily.json", dictionary);
        }
        #endregion

        #region 按周返回热门评论榜
        /// <summary>
        /// 按周返回热门微博评论榜的微博列表
        /// </summary>
        /// <param name="count">返回的记录条数，最大不超过50，默认为20。</param>
        /// <returns></returns>
        public IList<Status> Statuses_Hot_Comments_Weekly(int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"count",count??20}
            };
            return HttpGet<IList<Status>>("statuses/hot/comments_weekly.json", dictionary);
        }
        #endregion

        #region 批量获取指定微博的转发数评论数
        /// <summary>
        /// 批量获取指定微博的转发数评论数
        /// </summary>
        /// <param name="ids">需要获取数据的微博ID，多个之间用逗号分隔，最多不超过100个。</param>
        /// <returns></returns>
        public string Statuses_Count(string ids)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"ids",ids}
            };
            return HttpGet("statuses/count.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 转发一条微博信息
        /// <summary>
        /// 转发一条微博
        /// </summary>
        /// <param name="id">要转发的微博ID。</param>
        /// <param name="status">添加的转发文本，必须做URLencode，内容不超过140个汉字，不填则默认为“转发微博”。</param>
        /// <param name="is_comment">是否在转发的同时发表评论，0：否、1：评论给当前微博、2：评论给原微博、3：都评论，默认为0 。</param>
        /// <returns></returns>
        public Status Statuses_Repost(long id, string status, int? is_comment)
        {
            status = status.Length > 140 ? status.Substring(0, 140) : status;
            var dictionary = new Dictionary<object, object>
            {              
                {"id",id},
                {"status",Uri.EscapeDataString(status)},
                {"is_comment",is_comment??0}
            };
            return HttpPost<Status>("statuses/repost.json", dictionary);
        }
        #endregion

        #region 删除微博信息
        /// <summary>
        /// 根据微博ID删除指定微博
        /// </summary>
        /// <param name="id">需要删除的微博ID。</param>
        /// <returns></returns>
        public Status Statuses_Destroy(long id)
        {
            var dictionary = new Dictionary<object, object>
            {              
                {"id",id}
            };
            return HttpPost<Status>("statuses/destroy.json", dictionary);
        }
        #endregion

        #region 发布一条微博信息
        /// <summary>
        /// 发布一条微博信息
        /// </summary>
        /// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <returns></returns>
        public Status Statuses_Update(string status)
        {
            status = status.Length > 140 ? status.Substring(0, 140) : status;
            var dictionary = new Dictionary<object, object>
            {                
                {"status",Uri.EscapeDataString(status)}
            };
            return HttpPost<Status>("statuses/update.json", dictionary);
        }
        #endregion

        #region 上传图片并发布一条微博
        /// <summary>
        /// 上传图片并发布一条新微博
        /// </summary>
        /// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="pic">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
        /// <returns></returns>
        public Status Statuses_Upload(string status, byte[] pic)
        {
            status = status.Length > 140 ? status.Substring(0, 140) : status;
            var dictionary = new Dictionary<object, object>
            {                
                {"status",Uri.EscapeDataString(status)},
            };
            return HttpPost<Status>("statuses/upload.json", dictionary, pic);

        }
        #endregion

        #region 发布一条微博同时指定上传的图片或图片url(高级接口)
        /// <summary>
        /// 指定一个图片URL地址抓取后上传并同时发布一条新微博
        /// </summary>
        /// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="url">图片的URL地址，必须以http开头。</param>
        /// <returns></returns>
        public Status Statuses_Upload_Url_Text(string status, string url)
        {
            status = status.Length > 140 ? status.Substring(0, 140) : status;
            var dictionary = new Dictionary<object, object>
            {                
                {"status",Uri.EscapeDataString(status)},
                {"url",url}
            };
            return HttpPost<Status>("statuses/upload_url_text.json", dictionary);
        }
        #endregion

        #region 获取官方表情
        /// <summary>
        /// 获取微博官方表情的详细信息
        /// </summary>
        /// <param name="type">表情类别，face：普通表情、ani：魔法表情、cartoon：动漫表情，默认为face。</param>
        /// <param name="language">语言类别，cnname：简体、twname：繁体，默认为cnname。</param>
        /// <returns></returns>
        public IList<Emotions> Emotions(EmotionsType? type, EmotionsLanguage? language)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"type",type??EmotionsType.face},
                {"language",language??EmotionsLanguage.cnname}
            };
            return HttpGet<IList<Emotions>>("emotions.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 评论
        #region 读取接口
        #region 获取某条微博的评论列表
        /// <summary>
        /// 根据微博ID返回某条微博的评论列表
        /// </summary>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <returns></returns>
        public Comments Comments_Show(long id, long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"id",id},
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_author",(int)(filter_by_author??FilterByAuthor.All)}
            };
            return HttpGet<Comments>("comments/show.json", dictionary);
        }
        #endregion

        #region 我发出的评论列表
        /// <summary>
        /// 获取当前登录用户所发出的评论列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <returns></returns>
        public Comments Comments_Show(long? since_id, long? max_id, int? page, int? count, FilterBySource? filter_by_source)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_source",(int)(filter_by_source??FilterBySource.All)}
            };
            return HttpGet<Comments>("comments/by_me.json", dictionary);
        }
        #endregion

        #region 我收到的评论列表
        /// <summary>
        /// 获取当前登录用户所接收到的评论列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public Comments Comments_To_Me(long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author, FilterBySource? filter_by_source)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_author",(int)(filter_by_author??FilterByAuthor.All)},
                {"filter_by_source",(int)(filter_by_source??FilterBySource.All)}
            };
            return HttpGet<Comments>("comments/to_me.json", dictionary);
        }
        #endregion

        #region 获取用户发送及收到的评论列表
        /// <summary>
        /// 获取当前登录用户的最新评论包括接收到的与发出的
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Comments Comments_Timeline(long? since_id, long? max_id, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Comments>("comments/timeline.json", dictionary);
        }
        #endregion

        #region 获取@到我的评论
        /// <summary>
        /// 获取最新的提到当前登录用户的评论，即@我的评论
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public Comments Comments_Mentions(long? since_id, long? max_id, int? page, int? count, FilterByAuthor? filter_by_author, FilterBySource? filter_by_source)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"since_id",since_id??0},
                {"max_id",max_id??0},
                {"page",page??1},
                {"count",count??50},
                {"filter_by_author",(int)(filter_by_author??FilterByAuthor.All)},
                {"filter_by_source",(int)(filter_by_source??FilterBySource.All)}
            };
            return HttpGet<Comments>("comments/mentions.json", dictionary);
        }
        #endregion

        #region 批量获取评论内容
        /// <summary>
        /// 根据评论ID批量返回评论信息
        /// </summary>
        /// <param name="cids">需要查询的批量评论ID，用半角逗号分隔，最大50。</param>
        /// <returns></returns>
        public IList<Comment> Comments_Show_Batch(string cids)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"cids",cids}
            };
            return HttpGet<IList<Comment>>("comments/show_batch.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 评论一条微博
        /// <summary>
        /// 对一条微博进行评论
        /// </summary>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="comment">评论内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="comment_ori">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public Comment Comments_Create(long id, string comment, int? comment_ori)
        {
            comment = comment.Length > 140 ? comment.Substring(0, 140) : comment;
            var dictionary = new Dictionary<object, object>
            {                
                {"id",id},
                {"comment",Uri.EscapeDataString(comment)},
                {"comment_ori",comment_ori??0}
            };
            return HttpPost<Comment>("comments/create.json", dictionary);
        }
        #endregion

        #region 删除一条评论
        /// <summary>
        /// 删除一条评论
        /// </summary>
        /// <param name="cid">要删除的评论ID，只能删除登录用户自己发布的评论。</param>
        /// <returns></returns>
        public Comment Comments_Destroy(long cid)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"cid",cid}
            };
            return HttpPost<Comment>("comments/destroy.json", dictionary);
        }
        #endregion

        #region 批量删除评论
        /// <summary>
        /// 根据评论ID批量删除评论
        /// </summary>
        /// <param name="ids">需要删除的评论ID，用半角逗号隔开，最多20个。</param>
        /// <returns></returns>
        public IList<Comment> Comments_Destroy_Batch(string ids)
        {            
            var dictionary = new Dictionary<object, object>
            {                
                {"ids",ids}
            };
            return HttpPost<IList<Comment>>("comments/destroy_batch.json", dictionary);
        }
        #endregion

        #region 回复一条微博
        /// <summary>
        /// 回复一条评论
        /// </summary>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="cid">需要回复的评论ID。</param>
        /// <param name="comment">回复评论内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="without_mention">回复中是否自动加入“回复@用户名”，0：是、1：否，默认为0。</param>
        /// <param name="comment_ori">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public Comment Comments_Reply(long id, long cid, string comment, int? without_mention, int? comment_ori)
        {
            comment = comment.Length > 140 ? comment.Substring(0, 140) : comment;
            var dictionary = new Dictionary<object, object>
            {                
                {"id",id},
                {"cid",cid},
                {"comment",Uri.EscapeDataString(comment)},
                {"without_mention",without_mention??0},
                {"comment_ori",comment_ori??0}
            };
            return HttpPost<Comment>("comments/reply.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 用户
        #region 读取接口
        #region 获取当前登录用户信息
        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public User Users_Show()
        {
            if (base.Token.uid == 0)
            {
                base.Token.uid = this.Account_Get_Uid();
            }
            return this.Users_Show(base.Token.uid);
        }
        #endregion

        #region 获取用户信息
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="uid">需要查询的用户ID。</param>
        /// <returns></returns>
        public User Users_Show(long uid)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid}
            };
            return HttpGet<User>("users/show.json", dictionary);
        }
        #endregion

        #region 通过个性域名获取用户信息
        /// <summary>
        /// 通过个性化域名获取用户资料以及用户最新的一条微博
        /// </summary>
        /// <param name="domain">需要查询的个性化域名。</param>
        /// <returns></returns>
        public User Users_Domain_Show(string domain)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"domain",domain}
            };
            return HttpGet<User>("users/domain_show.json", dictionary);
        }
        #endregion

        #region 批量获取用户的粉丝数、关注数、微博数
        /// <summary>
        /// 批量获取用户的粉丝数、关注数、微博数
        /// </summary>
        /// <param name="uids">需要获取数据的用户UID，多个之间用逗号分隔，最多不超过100个。</param>
        /// <returns></returns>
        public string Users_Counts(string uids)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uids",uids}
            };
            return HttpGet("users/counts.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 关系
        #region 关注读取接口
        #region 获取用户的关注列表
        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public Users Friendships_Friends(long uid, int? count, int? cursor)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50},
                {"cursor",cursor??0}
            };
            return HttpGet<Users>("friendships/friends.json", dictionary);
        }
        #endregion

        #region 获取共同关注人列表
        /// <summary>
        /// 获取两个用户之间的共同关注人列表
        /// </summary>
        /// <param name="uid">需要获取共同关注关系的用户UID。</param>
        /// <param name="suid">需要获取共同关注关系的用户UID，默认为当前登录用户。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Users Friendships_Friends_In_Common(long uid, long? suid, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"suid",suid},                
                {"cursor",page??1},
                {"count",count??50}
            };
            return HttpGet<Users>("friendships/friends/in_common.json", dictionary);
        }
        #endregion

        #region 获取双向关注列表
        /// <summary>
        /// 获取用户的双向关注列表，即互粉列表
        /// </summary>
        /// <param name="uid">需要获取共同关注关系的用户UID。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
        /// <returns></returns>
        public Users Friendships_Friends_Bilateral(long uid, int? page, int? count, int? sort)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},             
                {"cursor",page??1},
                {"count",count??50},
                {"sort",sort??0}
            };
            return HttpGet<Users>("friendships/friends/bilateral.json", dictionary);
        }
        #endregion

        #region 获取双向关注UID列表
        /// <summary>
        /// 获取用户双向关注的用户ID列表，即互粉UID列表
        /// </summary>
        /// <param name="uid">需要获取共同关注关系的用户UID。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
        /// <returns></returns>
        public string Friendships_Friends_Bilateral_Ids(long uid, int? page, int? count, int? sort)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},             
                {"cursor",page??1},
                {"count",count??50},
                {"sort",sort??0}
            };
            return HttpGet("friendships/friends/bilateral/ids.json", dictionary);
        }
        #endregion

        #region 获取用户关注对象UID列表
        /// <summary>
        /// 获取用户关注的用户UID列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public string Friendships_Friends_Ids(long uid, int? count, int? cursor)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50},
                {"cursor",cursor??0}
            };
            return HttpGet("friendships/friends/ids.json", dictionary);
        }
        #endregion
        #endregion

        #region 粉丝读取接口
        #region 获取用户粉丝列表
        /// <summary>
        /// 获取用户的粉丝列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public Users Friendships_Followers(long uid, int? count, int? cursor)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50},
                {"cursor",cursor??0}
            };
            return HttpGet<Users>("friendships/followers.json", dictionary);
        }
        #endregion

        #region 获取用户粉丝UID列表
        /// <summary>
        /// 获取用户粉丝UID列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public string Friendships_Followers_Ids(long uid, int? count, int? cursor)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50},
                {"cursor",cursor??0}
            };
            return HttpGet("friendships/friends/ids.json", dictionary);
        }
        #endregion

        #region 获取用户优质粉丝列表
        /// <summary>
        /// 获取用户的活跃粉丝列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <returns></returns>
        public IList<User> Friendships_Followers_Active(long uid, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50}
            };
            return HttpGet<IList<User>>("friendships/followers/active.json", dictionary);
        }
        #endregion
        #endregion

        #region 关系链读取接口
        #region 获取我的关注人中关注了指定用户的人
        /// <summary>
        /// 获取当前登录用户的关注人中又关注了指定用户的用户列表
        /// </summary>
        /// <param name="uid">指定的关注目标用户UID。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Users Friendships_Friends_Chain_Followers(long uid, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"count",count??50},
                {"page",page??1}
            };
            return HttpGet<Users>("friendships/friends_chain/followers.json", dictionary);
        }
        #endregion
        #endregion

        #region 关系状态读取接口
        #region 获取两个用户关系的详细情况
        /// <summary>
        /// 获取两个用户之间的详细关注关系情况
        /// </summary>
        /// <param name="source_id">源用户的UID。</param>
        /// <param name="target_id">目标用户的UID。</param>
        /// <returns></returns>
        public RelationShip Friendships_Show(long source_id, long target_id)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"source_id",source_id},
                {"target_id",target_id}
            };
            return HttpGet<RelationShip>("friendships/show.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 关注某用户
        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="uid">需要关注的用户ID。</param>
        /// <returns></returns>
        public User Friendships_Create(long uid)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid}
            };
            return HttpPost<User>("friendships/create.json", dictionary);
        }
        #endregion

        #region 取消关注某用户
        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="uid">需要关注的用户ID。</param>
        /// <returns></returns>
        public User Friendships_Destroy(long uid)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid}
            };
            return HttpPost<User>("friendships/destroy.json", dictionary);
        }
        #endregion

        #region 更新关注人备注(高级接口)
        /// <summary>
        /// 更新当前登录用户所关注的某个好友的备注信息
        /// </summary>
        /// <param name="uid">需要修改备注信息的用户UID。</param>
        /// <param name="remark">备注信息，需要URLencode。</param>
        /// <returns></returns>
        public User Friendships_Remark_Update(long uid, string remark)
        {
            var dictionary = new Dictionary<object, object>
            {                
                {"uid",uid},
                {"remark",Uri.EscapeDataString(remark)}
            };
            return HttpPost<User>("friendships/remark/update.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 账户
        #region 读取接口
        #region 获取隐私设置信息
        /// <summary>
        /// 获取当前登录用户的隐私设置
        /// </summary>
        /// <returns></returns>
        public string Account_Get_Privacy()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet("account/get_privacy.json", dictionary);
        }
        #endregion

        #region 获取所有学校列表
        /// <summary>
        /// 获取所有的学校列表
        /// </summary>
        /// <param name="province">省份范围，省份ID。</param>
        /// <param name="city">城市范围，城市ID。</param>
        /// <param name="area">区域范围，区ID。</param>
        /// <param name="type">学校类型，1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为1。</param>
        /// <param name="keyword">学校名称关键字。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Account_Profile_School_List(int? province, int? city, int? area, int? type, string keyword, int? count)
        {
            var dictionary = new Dictionary<object, object> 
            {
                {"province",province},
                {"city",city},
                {"area",area},
                {"type",type??1},
                {"keyword",keyword},
                {"count",count??10}
            };
            return HttpGet("account/profile/school_list.json", dictionary);
        }
        #endregion

        #region 获取当前用户API访问频率限制
        /// <summary>
        /// 获取当前登录用户的API访问频率限制情况
        /// </summary>
        /// <returns></returns>
        public string Account_Rate_Limit_Status()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet("account/rate_limit_status.json", dictionary); 
        }
        #endregion

        #region OAuth授权之后获取用户UID
        /// <summary>
        /// OAuth授权之后，获取授权用户的UID
        /// </summary>
        /// <returns></returns>
        public long Account_Get_Uid()
        {
            var dictionary = new Dictionary<object, object>();
            var json = HttpGet("account/get_uid.json", dictionary);
            return long.Parse(Regex.Match(json, "{\"uid\":(.*?)}", RegexOptions.Compiled | RegexOptions.IgnoreCase).Groups[1].Value);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public User Account_End_Session()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet<User>("account/end_session.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 收藏
        #region 读取接口
        #region 获取当前登录用户的收藏列表
        /// <summary>
        /// 获取当前登录用户的收藏列表
        /// </summary>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public Favorites Favorites(int? page,int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Favorites>("favorites.json", dictionary);
        }
        #endregion

        #region 获取当前用户的收藏列表的ID
        /// <summary>
        /// 获取当前用户的收藏列表的ID
        /// </summary>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public string Favorites_Ids(int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet("favorites/ids.json", dictionary);
        }
        #endregion

        #region 获取单条收藏信息
        /// <summary>
        /// 根据收藏ID获取指定的收藏信息
        /// </summary>
        /// <param name="id">需要查询的收藏ID。</param>
        /// <returns></returns>
        public Favorite Favorites_Show(long id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id}
            };
            return HttpGet<Favorite>("favorites/show.json", dictionary);
        }
        #endregion

        #region 获取当前用户某个标签下的收藏列表
        /// <summary>
        /// 根据标签获取当前登录用户该标签下的收藏列表
        /// </summary>
        /// <param name="tid">需要查询的标签ID。</param>
        /// <param name="page">单页返回的记录条数，默认为50。</param>
        /// <param name="count">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public Favorites Favorites_By_Tags(long tid, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"tid",tid},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Favorites>("favorites/by_tags.json", dictionary);
        }
        #endregion

        #region 当前登录用户的收藏标签列表
        /// <summary>
        /// 获取当前登录用户的收藏标签列表
        /// </summary>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <returns></returns>
        public string Favorites_Tags(int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet("favorites/tags.json", dictionary);
        }
        #endregion

        #region 获取当前用户某个标签下的收藏列表的ID
        /// <summary>
        /// 根据标签获取当前登录用户该标签下的收藏列表
        /// </summary>
        /// <param name="tid">需要查询的标签ID。</param>
        /// <param name="page">单页返回的记录条数，默认为50。</param>
        /// <param name="count">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public string Favorites_By_Tags_Ids(long tid, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"tid",tid},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet("favorites/by_tags/ids.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 添加收藏
        /// <summary>
        /// 添加一条微博到收藏里
        /// </summary>
        /// <param name="id">要收藏的微博ID。</param>
        /// <returns></returns>
        public Favorite Favorites_Create(long id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id}
            };
            return HttpPost<Favorite>("favorites/create.json", dictionary);
        }
        #endregion

        #region 删除收藏
        /// <summary>
        /// 取消收藏一条微博
        /// </summary>
        /// <param name="id">要取消收藏的微博ID。</param>
        /// <returns></returns>
        public Favorite Favorites_Destroy(long id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id}
            };
            return HttpPost<Favorite>("favorites/destroy.json", dictionary);
        }
        #endregion

        #region 批量删除收藏
        /// <summary>
        /// 根据收藏ID批量取消收藏
        /// </summary>
        /// <param name="ids">要取消收藏的收藏ID，用半角逗号分隔，最多不超过10个。</param>
        /// <returns></returns>
        public string Favorites_Destroy_Batch(string ids)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"ids",ids}
            };
            return HttpPost("favorites/destroy_batch.json", dictionary);
        }
        #endregion

        #region 更新收藏标签
        /// <summary>
        /// 更新一条收藏的收藏标签(参数tags为空即为删除标签)
        /// </summary>
        /// <param name="id">需要更新的收藏ID。</param>
        /// <param name="tags">需要更新的标签内容，必须做URLencode，用半角逗号分隔，最多不超过2条。</param>
        /// <returns></returns>
        public Favorite Favorites_Tags_Update(long id, string tags)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",id},
                {"tags",Uri.EscapeDataString(tags)}
            };
            return HttpPost<Favorite>("favorites/tags/update.json", dictionary);
        }
        #endregion

        #region 更新当前用户所有收藏下的指定标签
        /// <summary>
        /// 更新当前登录用户所有收藏下的指定标签
        /// </summary>
        /// <param name="tid">需要更新的标签ID。</param>
        /// <param name="tag">需要更新的标签内容，必须做URLencode。</param>
        /// <returns></returns>
        public string Favorites_Tags_Update_Batch(long tid, string tag)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",tid},
                {"tags",Uri.EscapeDataString(tag)}
            };
            return HttpPost("favorites/tags/update_batch.json", dictionary);
        }
        #endregion

        #region 删除当前用户所有收藏下的指定标签
        /// <summary>
        /// 删除当前登录用户所有收藏下的指定标签
        /// </summary>
        /// <param name="tid">需要删除的标签ID。</param>
        /// <returns></returns>
        public string Favorites_Tags_Destroy_Batch(long tid)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"id",tid}
            };
            return HttpPost("favorites/tags/destroy_batch.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 话题
        #region 读取接口
        #region 获取某人话题
        /// <summary>
        /// 获取某人的话题列表
        /// </summary>
        /// <param name="uid">需要获取话题的用户的UID。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Trends(long uid,int? page,int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid},
                {"page",page??1},
                {"count",count??10}
            };
            return HttpGet("trends.json", dictionary);
        }
        #endregion

        #region 是否关注某话题
        /// <summary>
        /// 判断当前用户是否关注某话题
        /// </summary>
        /// <param name="trend_name">话题关键字，必须做URLencode。</param>
        /// <returns></returns>
        public string Trends_Is_Follow(string trend_name)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"trend_name",Uri.EscapeDataString(trend_name)},
            };
            return HttpGet("trends/is_follow.json", dictionary);
        }
        #endregion

        #region 返回最近一小时内的热门话题
        /// <summary>
        /// 返回最近一小时内的热门话题
        /// </summary>
        /// <returns></returns>
        public string Trends_Hourly()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet("trends/hourly.json", dictionary);
        }
        #endregion

        #region 返回最近一天内的热门话题
        /// <summary>
        /// 返回最近一天内的热门话题
        /// </summary>
        /// <returns></returns>
        public string Trends_Daily()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet("trends/daily.json", dictionary);
        }
        #endregion

        #region 返回最近一周内的热门话题
        /// <summary>
        /// 返回最近一周内的热门话题
        /// </summary>
        /// <returns></returns>
        public string Trends_Weekly()
        {
            var dictionary = new Dictionary<object, object>();
            return HttpGet("trends/weekly.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 关注某话题
        /// <summary>
        /// 关注某话题
        /// </summary>
        /// <param name="trend_name">要关注的话题关键词。</param>
        /// <returns></returns>
        public string Trends_Follow(string trend_name)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"trend_name",trend_name}
            };
            return HttpPost("trends/follow.json", dictionary);
        }
        #endregion

        #region 取消关注的某一个话题
        /// <summary>
        /// 取消对某话题的关注
        /// </summary>
        /// <param name="trend_id">要取消关注的话题ID。</param>
        /// <returns></returns>
        public string Trends_Destroy(long trend_id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"trend_id",trend_id}
            };
            return HttpPost("trends/destroy.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 标签
        #region 读取接口
        #region 返回指定用户的标签列表
        /// <summary>
        /// 返回指定用户的标签列表
        /// </summary>
        /// <param name="uid">要获取的标签列表所属的用户ID。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <returns></returns>
        public string Tags(long uid, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid},
                {"page",page??1},
                {"count",count??20}
            };
            return HttpGet("tags.json", dictionary);
        }
        #endregion

        #region 批量获取用户标签
        /// <summary>
        /// 批量获取用户的标签列表
        /// </summary>
        /// <param name="uids">要获取标签的用户ID。最大20，逗号分隔。</param>
        /// <returns></returns>
        public string Tags_Tags_Batch(string uids)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uids",uids}
            };
            return HttpGet("tags/tags_batch.json", dictionary);
        }
        #endregion

        #region 返回系统推荐的标签列表
        /// <summary>
        /// 获取系统推荐的标签列表
        /// </summary>
        /// <param name="count">返回记录数，默认10，最大10。</param>
        /// <returns></returns>
        public string Tags_Suggestions(int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"count",count??10}
            };
            return HttpGet("tags/suggestions.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 添加用户标签
        /// <summary>
        /// 为当前登录用户添加新的用户标签
        /// </summary>
        /// <param name="tags">要创建的一组标签，用半角逗号隔开，每个标签的长度不可超过7个汉字，14个半角字符。</param>
        /// <returns></returns>
        public string Tags_Create(string tags)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"tags",tags}
            };
            return HttpPost("tags/create.json", dictionary);
        }
        #endregion

        #region 删除用户标签
        /// <summary>
        /// 删除一个用户标签
        /// </summary>
        /// <param name="tag_id">要删除的标签ID。</param>
        /// <returns></returns>
        public string Tags_Destroy(long tag_id)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"tag_id",tag_id}
            };
            return HttpPost("tags/destroy.json", dictionary);
        }
        #endregion

        #region 批量删除用户标签
        /// <summary>
        /// 批量删除一组标签
        /// </summary>
        /// <param name="ids">要删除的一组标签ID，以半角逗号隔开，一次最多提交10个ID。</param>
        /// <returns></returns>
        public string Tags_Destroy_Batch(string ids)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"ids",ids}
            };
            return HttpPost("tags/destroy_batch.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 注册
        #region 读取接口
        /// <summary>
        /// 验证昵称是否可用，并给予建议昵称
        /// </summary>
        /// <param name="nickname">需要验证的昵称。4-20个字符，支持中英文、数字、"_"或减号。必须做URLEncode，采用UTF-8编码。</param>
        /// <returns></returns>
        public string Register_Verify_Nickname(string nickname)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"nickname",Uri.EscapeDataString(nickname)}
            };
            return HttpGet("register/verify_nickname.json", dictionary);
        }
        #endregion
        #endregion

        #region 搜索
        #region 搜索联想接口
        #region 搜用户搜索建议
        /// <summary>
        /// 搜索用户时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Search_Suggestions_Users(string q, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10}
            };
            return HttpGet("search/suggestions/users.json", dictionary);
        }
        #endregion

        #region 搜微博搜索建议
        /// <summary>
        /// 搜索微博时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Search_Suggestions_Statuses(string q, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10}
            };
            return HttpGet("search/suggestions/statuses.json", dictionary);
        }
        #endregion

        #region 搜学校搜索建议
        /// <summary>
        /// 搜索学校时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <param name="type">学校类型，0：全部、1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为0。</param>
        /// <returns></returns>
        public string Search_Suggestions_Schools(string q, int? count, int? type)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10},
                {"type",type??0}
            };
            return HttpGet("search/suggestions/schools.json", dictionary);
        }
        #endregion

        #region 搜公司搜索建议
        /// <summary>
        /// 搜索公司时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Search_Suggestions_Companies(string q, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10},
            };
            return HttpGet("search/suggestions/companies.json", dictionary);
        }
        #endregion

        #region 搜应用搜索建议
        /// <summary>
        /// 搜索应用时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Search_Suggestions_Apps(string q, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10},
            };
            return HttpGet("search/suggestions/apps.json", dictionary);
        }
        #endregion

        #region @联想搜索
        /// <summary>
        /// 搜索应用时的联想搜索建议
        /// </summary>
        /// <param name="q">搜索的关键字，必须做URLencoding。</param>
        /// <param name="count">返回的记录条数，默认为10，粉丝最多1000，关注最多2000。</param>
        /// <param name="type">联想类型，0：关注、1：粉丝。</param>
        /// <param name="range">联想范围，0：只联想关注人、1：只联想关注人的备注、2：全部，默认为2。</param>
        /// <returns></returns>
        public string Search_Suggestions_At_users(string q, int? count, int type, int? range)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"count",count??10},
                {"type",type},
                {"range",range??2}
            };
            return HttpGet("search/suggestions/at_users.json", dictionary);
        }
        #endregion
        #endregion

        #region 搜索某一话题下的微博(高级接口)
        /// <summary>
        /// 搜索某一话题下的微博(高级接口)关键词只能为两#间的话题，即只能搜索某话题下的微博,只返回最新200条结果
        /// </summary>
        /// <param name="q">搜索的话题关键字</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为10，最大为50。</param>
        public string Search_Topics(string q, int? page,int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"q",Uri.EscapeDataString(q)},
                {"page",page??1},
                {"count",count??10}
            };
            return HttpGet("search/topics.json", dictionary);
        }
        #endregion
        #endregion

        #region 推荐
        #region 读取接口
        #region 获取系统推荐用户
        /// <summary>
        /// 返回系统推荐的热门用户列表
        /// </summary>
        /// <param name="category">推荐分类，返回某一类别的推荐用户，默认为default；如果不在以下分类中，返回空列表。default：人气关注、ent：影视名星、music：音乐、fashion：时尚、literature：文学、business：商界、sports：体育、health：健康、auto：汽车、house：房产、trip：旅行、stock：炒股、food：美食、fate：命理、art：艺术、tech：科技、cartoon：动漫、games：游戏。</param>
        /// <returns></returns>
        public Users Suggestions_Users_Hot(string category)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"category",category??"default"}
            };
            var json = HttpGet("suggestions/users/hot.json", dictionary);
            return ("{\"users\":" + json + "}").ToEntity<Users>();
        }
        #endregion

        #region 获取用户可能感兴趣的人
        /// <summary>
        /// 获取用户可能感兴趣的人
        /// </summary>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public string Suggestions_Users_May_Interested(int? page,int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??10}
            };
            return HttpGet("suggestions/users/may_interested.json", dictionary);
        }
        #endregion

        #region 根据微博内容推荐用户
        /// <summary>
        /// 根据一段微博正文推荐相关微博用户
        /// </summary>
        /// <param name="content">微博正文内容</param>
        /// <param name="num">返回结果数目,UTF-8编码 </param>
        /// <returns></returns>
        public string Suggestions_Users_By_Status(string content, int? num)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"content",Uri.EscapeDataString(content)},
                {"num",num??10}
            };
            return HttpGet("suggestions/users/by_status.json", dictionary);
        }
        #endregion

        #region 获取微博精选推荐
        /// <summary>
        /// 获取微博精选推荐
        /// </summary>
        /// <param name="type">微博精选分类，1：娱乐、2：搞笑、3：美女、4：视频、5：星座、6：各种萌、7：时尚、8：名车、9：美食、10：音乐。</param>
        /// <param name="is_pic">是否返回图片精选微博，0：全部、1：图片微博。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <returns></returns>
        public Statuses Suggestions_Statuses_Hot(int type, int? is_pic, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"type",type},
                {"is_pic",is_pic??0},
                {"page",page??1},
                {"count",count??20},
            };
            return HttpGet<Statuses>("suggestions/statuses/hot.json", dictionary);
        }
        #endregion

        #region 主Feed微博按兴趣推荐排序
        /// <summary>
        /// 当前登录用户的friends_timeline微博按兴趣推荐排序
        /// </summary>
        /// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。</param>
        /// <param name="page">单页返回的记录条数，默认为50。</param>
        /// <param name="count">返回结果的页码，默认为1。</param>
        /// <returns></returns>        
        public Statuses Suggestions_Statuses_Reorder(int section, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"section",section},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet<Statuses>("suggestions/statuses/reorder.json", dictionary);
        }
        #endregion

        #region 主Feed微博按兴趣推荐排序的微博ID
        /// <summary>
        /// 当前登录用户的friends_timeline微博按兴趣推荐排序的微博ID
        /// </summary>
        /// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。</param>
        /// <param name="page">单页返回的记录条数，默认为50。</param>
        /// <param name="count">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public string Suggestions_Statuses_Reorder_Ids(int section, int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"section",section},
                {"page",page??1},
                {"count",count??50}
            };
            return HttpGet("suggestions/statuses/reorder/ids.json", dictionary);
        }
        #endregion

        #region 热门收藏
        /// <summary>
        /// 返回系统推荐的热门收藏
        /// </summary>
        /// <param name="page">返回页码，默认1。</param>
        /// <param name="count">每页返回结果数，默认20。</param>
        /// <returns></returns>
        public string Suggestions_Favorites_Hot(int? page, int? count)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"page",page??1},
                {"count",count??20}
            };
            return HttpGet("suggestions/favorites/hot.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 不感兴趣的人
        /// <summary>
        /// 把某人标识为不感兴趣的人
        /// </summary>
        /// <param name="uid">不感兴趣的用户的UID。</param>
        /// <returns></returns>
        public User Suggestions_Users_Not_interested(Int64 uid)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid}
            };
            return HttpPost<User>("suggestions/users/not_interested.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 提醒
        #region 读取接口
        #region 获取某个用户的各种消息未读数
        /// <summary>
        /// 获取某个用户的各种消息未读数
        /// </summary>
        /// <param name="uid">需要获取消息未读数的用户UID，必须是当前登录用户。</param>
        /// <param name="callback">JSONP回调函数，用于前端调用返回JS格式的信息。</param>
        /// <returns></returns>
        public string Remind_Unread_Count(Int64 uid, string callback)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"uid",uid},
                {"callback",callback}
            };
            return HttpGet("remind/unread_count.json", dictionary);
        }
        #endregion
        #endregion

        #region 写入接口
        #region 对当前登录用户某一种消息未读数进行清零(高级接口)
        /// <summary>
        /// 对当前登录用户某一种消息未读数进行清零(高级接口)
        /// </summary>
        /// <param name="type">需要清零未读数的消息项，status：新微博数、follower：新粉丝数、cmt：新评论数、dm：新私信数、mention_status：新提及我的微博数、mention_cmt：新提及我的评论数，一次只能操作一项。</param>
        /// <returns></returns>
        public string Remind_Set_Count(string type)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"type",type}
            };
            return HttpPost("remind/set_count.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 公共服务
        #region 读取接口
        #region 获取地址名称
        /// <summary>
        /// 通过地址编码获取地址名称
        /// </summary>
        /// <param name="codes">需要查询的地址编码，多个之间用逗号分隔。</param>
        /// <returns></returns>
        public string Common_Code_To_Location(string codes)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"codes",codes}
            };
            return HttpGet("common/code_to_location.json", dictionary);
        }
        #endregion

        #region 获取城市列表
        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="province">省份的省份代码。</param>
        /// <param name="capital">非必选：城市的首字母，a-z，可为空代表返回全部，默认为全部。</param>
        /// <param name="language">非必选：返回的语言版本，zh-cn：简体中文、zh-tw：繁体中文、english：英文，默认为zh-cn。</param>
        /// <returns></returns>
        public string Common_Get_City(string province, string capital, string language)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"province",province},
                {"capital",capital},
                {"language",language},
            };
            return HttpGet("common/get_city.json", dictionary);
        }
        #endregion

        #region 获取省份列表
        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <param name="country">国家的国家代码。</param>
        /// <param name="capital">非必须：省份的首字母，a-z，可为空代表返回全部，默认为全部。</param>
        /// <param name="language">非必须：返回的语言版本，zh-cn：简体中文、zh-tw：繁体中文、english：英文，默认为zh-cn。</param>
        /// <returns></returns>
        public string Common_Get_Province(string country, string capital, string language)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"country",country},
                {"capital",capital},
                {"language",language},
            };
            return HttpGet("common/get_province.json", dictionary);
        }
        #endregion

        #region 获取国家列表
        /// <summary>
        /// 获取国家列表
        /// </summary>
        /// <param name="capital">国家的首字母，a-z，可为空代表返回全部，默认为全部。</param>
        /// <param name="language">返回的语言版本，zh-cn：简体中文、zh-tw：繁体中文、english：英文，默认为zh-cn。</param>
        /// <returns></returns>
        public string Common_Get_Country(string capital, string language)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"capital",capital},
                {"language",language},
            };
            return HttpGet("common/get_country.json", dictionary);
        }
        #endregion

        #region 获取时区配置表
        /// <summary>
        /// 获取时区配置表
        /// </summary>
        /// <param name="language">返回的语言版本，zh-cn：简体中文、zh-tw：繁体中文、english：英文，默认为zh-cn。</param>
        /// <returns></returns>
        public string Common_Get_Timezone(string language)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"language",language}
            };
            return HttpGet("common/get_timezone.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region 地理信息
        #region 基础位置读取接口
        #region 生成一张静态的地图图片
        public string Location_Base_Get_Map_Image(string city)
        {
            var dictionary = new Dictionary<object, object>
            {
                {"city",city}
            };
            return HttpGet("location/base/get_map_image.json", dictionary);
        }
        #endregion
        #endregion
        #endregion

        #region Must
        #region Post
        public T HttpPost<T>(string partUrl, IDictionary<object, object> dictionary) where T : class
        {
            return HttpPost<T>(partUrl, dictionary, null);
        }

        public T HttpPost<T>(string partUrl, IDictionary<object, object> dictionary,byte[] file) where T : class
        {
            dictionary.Add("access_token", base.Token.access_token);
            
            var url = base.baseUrl.ToFormat(partUrl);            
            var query = dictionary.ToQueryString();
            logger.Error(url);
            logger.Error(query);
            var json = string.Empty;
            if (file != null)
            {
                json = base.HttpMethod.HttpPost(url, dictionary, file);
            }
            else
            {
                json = base.HttpMethod.HttpPost(url, query);
            }
            
            return json.ToEntity<T>();
        }

        public string HttpPost(string partUrl, IDictionary<object, object> dictionary)
        {
            dictionary.Add("access_token", base.Token.access_token);

            var url = base.baseUrl.ToFormat(partUrl);
            var query = dictionary.ToQueryString();
            logger.Error(url);
            logger.Error(query);
            return base.HttpMethod.HttpPost(url, query);
        }
        #endregion

        #region Get
        public T HttpGet<T>(string partUrl, IDictionary<object, object> dictionary) where T : class
        {
            dictionary.Add("access_token", base.Token.access_token);

            var url = base.baseUrl.ToFormat(partUrl);
            var query = dictionary.ToQueryString();
            logger.Error(url + "?" + query);
            var json = base.HttpMethod.HttpGet(url + "?" + query);
            return json.ToEntity<T>("json");
        }

        public string HttpGet(string partUrl, IDictionary<object, object> dictionary)
        {
            dictionary.Add("access_token", base.Token.access_token);

            var url = base.baseUrl.ToFormat(partUrl);
            var query = dictionary.ToQueryString();
            logger.Error(url + "?" + query);
            return base.HttpMethod.HttpGet(url + "?" + query);
        }
        #endregion
        #endregion
    }
}
