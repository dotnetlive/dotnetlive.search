import urllib
import urllib.request

def getHtml(url):
    response_result = urllib.request.urlopen(url).read()
    html = response_result.decode('utf-8')
    return html
#根据搜索条件和索引获取数据
def getBlogsBySearch(key,index):
    url = 'http://zzk.cnblogs.com/s/blogpost?Keywords='+key+'&pageindex='+str(index)

    html = getHtml(url)
    return html

html = getBlogsBySearch('java',49)
print(html)