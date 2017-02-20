import match
import os
import datetime

def writeToTxt(list_name,file_path):
    try:
        fp = open(file_path,"w+",encoding='utf-8')
        for item in list_name:
            fp.write(getStr(item))
        fp.close()
    except IOError:
        print("fail to open file")

def getStr(item):
    return str(item).replace('\'','\"')+'\n'

def saveBlogs():
    for i in range(1,100):
        print('request for '+str(i)+'...')
        blogs = match.blogParser(i,10)
        #保存到文件
        path = createFile()
        writeToTxt(blogs,path+'/blog_'+ str(i) +'.txt')
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