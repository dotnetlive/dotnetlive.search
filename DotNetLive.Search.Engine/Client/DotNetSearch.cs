using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using DotNetLive.Search.Engine.Logger;
using Elasticsearch.Net;
using DotNetLive.Search.Engine.Config;

namespace DotNetLive.Search.Engine.Client
{
    public class DotNetSearch
    {
        private string _defaultIndex;
        private SearchEngineBuilder _builder;
        private ISearchLogger _logger;

        #region 构造函数
        public DotNetSearch()
        {
            _builder = new SearchEngineBuilder();
        }

        public DotNetSearch(ISearchLogger logger) : this()
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
        public DotNetSearch UseLogger(ISearchLogger logger)
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
                    _logger.Error(response.ApiCall.DebugInformation);
                }
            }
            return t;
        }
        #endregion

        #region 高级操作
        #endregion

        #region 批量操作
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
                _logger.Error(response.ApiCall.DebugInformation);
            }
            return false;
        }
        #endregion
    }
}
