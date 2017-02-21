from bs4 import BeautifulSoup
import request
import re
import json
#解析最外层
def blogParser(index,page):
  start = (index-1) * page + 1
  end = index * page
  cnblogs = request.requestCnblogsByRange(start,end)
  soup = BeautifulSoup(cnblogs, 'html.parser')
  limit = 20 * page
  all_div = soup.find_all('div', attrs={'class': 'post_item_body'}, limit=limit)

  blogs = []
  #循环div获取详细信息
  for item in all_div:
      blog = analyzeBlog(item)
      blogs.append(blog)

  return blogs

#解析每一条数据
def analyzeBlog(item):
    result = {}
    a_title = find_all(item,'a','titlelnk')
    if a_title is not None:
        # 博客标题
        result["title"] = a_title[0].string
        # 博客链接
        result["href"] = a_title[0]['href']
    p_summary = find_all(item,'p','post_item_summary')
    if p_summary is not None:
        # 简介
        result["summary"] = p_summary[0].text
    footers = find_all(item,'div','post_item_foot')
    footer = footers[0]
    # 作者
    result["author"] = footer.a.string
    # 作者url
    result["author_url"] = footer.a['href']
    str = footer.text
    time = re.findall(r"发布于 .+? .+? ", str)
    result["create_time"] = time[0].replace('发布于 ','')

    comment_str = find_all(footer,'span','article_comment')[0].a.string
    result["comment_num"] = re.search(r'\d+', comment_str).group()

    view_str = find_all(footer,'span','article_view')[0].a.string
    result["view_num"] = re.search(r'\d+', view_str).group()

    return json.dumps(result)

def find_all(item,attr,c):
    return item.find_all(attr,attrs={'class':c},limit=1)
