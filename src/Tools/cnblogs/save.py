import match
import os
import datetime
import json

def writeToTxt(list_name,file_path):
    try:
        #这里直接write item 即可，不要自己给序列化在写入，会导致json格式不正确的问题
        fp = open(file_path,"w+",encoding='utf-8')
        l = len(list_name)
        i = 0
        fp.write('[')
        for item in list_name:
            fp.write(item)
            if i<l-1:
                fp.write(',\n')
            i += 1
        fp.write(']')
        fp.close()
    except IOError:
        print("fail to open file")

#def getStr(item):
#   return json.dumps(item).replace('\'','\"')+',\n'

def saveBlogs():
    for i in range(1,100):
        print('request for '+str(i)+'...')
        blogs = match.blogParser(i,10)
        #保存到文件
        path = createFile()
        writeToTxt(blogs,path+'/blog_'+ str(i) +'.json')
        print('第'+ str(i) +'页已经完成')
    return 'success'

def createFile():
    date = datetime.datetime.now().strftime('%Y-%m-%d')
    path = '/'+date
    if os.path.exists(path):
        return path
    else:
        os.mkdir(path)
        return path

result = saveBlogs()
print(result)