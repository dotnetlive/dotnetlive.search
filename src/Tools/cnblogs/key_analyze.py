import key_request
from bs4 import BeautifulSoup
import json
import re

#解析关键词列表
def analyzeList(key,index):
    html = key_request.getBlogsBySearch(key,index)
    soup = BeautifulSoup(html, 'html.parser')

    all_div = soup.find_all('div', attrs={'class': 'searchItem'}, limit=20)

    blogs = []
    # 循环div获取详细信息
    for item in all_div:
        try:
            blog = analyzeItem(item)
            blogs.append(blog)
        except AttributeError:
            print(item)
            continue
    return blogs

#解析单条
def analyzeItem(item):
    result = {}

    #标题
    h3_title = item.find_all('h3',attrs={'class':'searchItemTitle'},limit=1)
    #标题
    result['title'] = getString(h3_title[0].a.contents)
    #链接
    result['href'] = h3_title[0].a['href']

    span_summary= item.find_all('span',attrs={'class':'searchCon'},limit=1)
    #搜索到的内容
    result['summary'] = getString(span_summary[0].contents)
    #详细数据
    div_details = item.find_all('div',attrs={'class':'searchItemInfo'},limit=1)[0]
    #用户信息
    author_info = div_details.find_all('span',attrs={'class':'searchItemInfo-userName'})[0]
    result['author'] = author_info.a.string
    result['author_url'] = author_info.a['href']

    result['create_time'] = getDetails(div_details,'searchItemInfo-publishDate',0)
    result['goods_num'] = getDetails(div_details, 'searchItemInfo-good', 1)
    result['comment_num'] = getDetails(div_details, 'searchItemInfo-comments', 1)
    result['view_num'] = getDetails(div_details, 'searchItemInfo-views', 1)

    js =  json.dumps(result)
    return js

#获取详情
def getDetails(div_detail,clsname,number):
    d = div_detail.find_all('span',attrs={'class':clsname},limit=1)

    if len(d) > 0:
        if number == 0 and len(d) > 0:
             return d[0].text
        return re.search(r'\d+', d[0].text).group()
    return '0'

def getString(contents):
    l = len(contents)
    for i in range(0,l):
        contents[i] = str(contents[i])
    title = ','.join(contents)
    return dropHtml(title)

def dropHtml(content):
    dr = re.compile(r'<[^>]+>', re.S)
    res = dr.sub('', content)
    return res
