using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using DotNetLive.Search.Engine.Logger;
using Elasticsearch.Net;
using DotNetLive.Search.Engine.Config;
using Microsoft.Extensions.Logging;

namespace DotNetLive.Search.Engine.Client
{
    public partial class DotNetSearch
    {
        private string _defaultIndex;
        private SearchEngineBuilder _builder;
        private ILogger _logger;

        #region 构造函数
        public DotNetSearch()
        {
            _builder = new SearchEngineBuilder();
        }

        public DotNetSearch(ILogger logger) : this()
        {
            _logger = logger;
        }
        #endregion

        #region 设置
        /// <summary>
        /// 设置索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DotNetSearch UseIndex(string index)
        {
            _defaultIndex = index;
            return this;
        }

        /// <summary>
        /// 设置日志
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public DotNetSearch UseLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        #endregion

        #region 增删改查
        /// <summary>
        /// 新增一条文档
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="model">文档实体</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回true false</returns>
        public bool Index<T>(T model, string index = null) where T : class => HandleResponseResult(() =>
        {
            IIndexResponse response = _builder?.Client?.Index(model, x => x.Type(typeof(T).SearchName()).Index(index ?? _defaultIndex));
            return response;
        });

        /// <summary>
        /// 更新一条文档
        /// 由于是普通的简单更新，当id已经存在时，则会更新文档，所以这里直接调用index方法，（复杂方法待研究）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="model">文档实体</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回true false</returns>
        public bool Update<T>(T model, string index = null) where T : class
        {
            return Index(model, index);
        }

        /// <summary>
        /// 删除一条文档
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">主键id</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回true false</returns>
        public bool Delete<T>(long id, string index = null) where T : class => HandleResponseResult(() =>
        {
            //DocumentPath<T>.Id(id)
            IDeleteResponse response = _builder?.Client.Delete<T>(id, x => x.Type(typeof(T).SearchName()).Index(index ?? _defaultIndex));
            return response;
        });

        /// <summary>
        /// 查询一条文档
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档id</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回该文档</returns>
        public T Query<T>(long id, string index = null) where T : class
        {
            IGetResponse<T> response = _builder?.Client.Get<T>(id, x => x.Type(typeof(T).SearchName()).Index(index ?? _defaultIndex));
            var t = response?.Source;
            if (t == null)
            {
                if (_logger != null)
                {
                    _logger.LogInformation(response.ApiCall.DebugInformation);
                }
            }
            return t;
        }
        /// <summary>
        /// 文档查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(int pageIndex, int pageSize, string keyword, string index = null) where T : class
        {
            var from = (pageIndex - 1) * pageSize;
            ISearchResponse<T> response = _builder?.Client.Search<T>(s => s
                     .Type(typeof(T).SearchName())
                     .Index(index ?? _defaultIndex)
                     .From(from)
                     .Size(pageSize)
                     .Query(q => q.QueryString(qs => qs.Fields(new string[]{ "author"}).Query(keyword).DefaultOperator(Operator.Or)))
             //.Query(q => q
             //.MatchPhrase(m => m.Field("content").Query(keyword)))
             //.Query(q=>q.Bool)
             //.Query(q=>q.Match(t=>t.Field("author").Query(keyword)))
             // .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.Or)))
             //.Query(q => q
             //.MatchPhrase(m => m.Field("content").Query(keyword)))
             );
            return response.Documents;
        }
        #endregion

        #region 高级操作
        #endregion

        #region 批量操作

        #region 批量添加或者更新
        /// <summary>
        /// 批量添加或者更新文档
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="documents">将要添加或者更新的文档集合</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回更新的条数</returns>
        public int IndexMany<T>(IEnumerable<T> documents, string index = null) where T : class
        {
            IBulkResponse response = _builder?.Client.IndexMany<T>(documents, index ?? _defaultIndex, typeof(T).SearchName());
            if (response.Errors)
            {
                if (_logger != null)
                {
                    _logger.LogInformation(response.DebugInformation);
                    //_logger.Error(response.ItemsWithErrors)
                }

            }
            return response.Items.Count;

        }
        /// <summary>
        /// 批量添加或者更新文档
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="documents">将要添加或者更新的文档集合</param>
        /// <param name="index">文档所在库</param>
        /// <returns>返回更新的条数</returns>
        public int Bulk<T>(IEnumerable<T> objects, string index = null) where T : class
        {
            BulkDescriptor descriptor = new BulkDescriptor();
            descriptor.Index(index ?? _defaultIndex).Type(typeof(T).SearchName()).IndexMany(objects);
            IBulkResponse response = _builder?.Client.Bulk(descriptor);
            if (response.Errors)
            {
                if (_logger != null)
                {
                    _logger.LogInformation(response.DebugInformation);
                    //_logger.Error(response.ItemsWithErrors)
                }

            }
            return response.Items.Count;
        }
        #endregion 

        #endregion

        #region 请求结果统一处理
        private bool HandleResponseResult(Func<IBodyWithApiCallDetails> handler)
        {
            var response = handler();

            if (response.ApiCall.Success)
            {
                return true;
            }

            if (_logger != null)
            {
                //统一处理日志
                _logger.LogInformation(response.ApiCall.DebugInformation);
            }
            return false;
        }
        #endregion
    }
}
