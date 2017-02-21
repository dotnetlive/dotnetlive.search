import urllib.parse
import urllib.request
# params  CategoryId=808 CategoryType=SiteHome ItemListActionName=PostList PageIndex=3 ParentCategoryId=0 TotalPostCount=4000
def getHtml(url,values):
    user_agent='Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.82 Safari/537.36'
    headers = {'User-Agent':user_agent}
    data = urllib.parse.urlencode(values)
    response_result = urllib.request.urlopen(url+'?'+data).read()
    html = response_result.decode('utf-8')
    return html

#首页
def requestCnblogsHome(index):
    return requestCnblogs(index,808,'SiteHome');
#精华
def requestCnblogsPicked(index):
    return requestCnblogs(index,-2,'Picked')
#候选
def requestCnblogsPrepare(index):
    return requestCnblogs(index,108697,'HomeCandidate')
#发送总请求
def requestCnblogs(index,category,categorytype):
    url = 'http://www.cnblogs.com/mvc/AggSite/PostList.aspx'
    value = {
        'CategoryId': category,
        'CategoryType': categorytype,
        'ItemListActionName': 'PostList',
        'PageIndex': index,
        'ParentCategoryId': 0,
        'TotalPostCount': 4000
    }
    result = getHtml(url, value)
    return result
def requestCnblogsByRange(index):
    blogs = ''
    blogs+=requestCnblogsHome(index)
    if index<100:
        blogs += requestCnblogsPicked(index)
    blogs += requestCnblogsPrepare(index)
    return blogs

