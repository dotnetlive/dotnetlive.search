import os
import datetime
import json

def writeToTxt(list_name,file_path):
    try:
        fp = open(file_path,"w+",encoding='utf-8')
        l = len(list_name)
        i = 0
        #添加左中括号
        fp.write('[')
        for item in list_name:
            #直接将项目write到 json文件中
            fp.write(item)
            #添加每一项之间的逗号
            if i<l-1:
                fp.write(',\n')
            i += 1
        fp.write(']')
        #添加右中括号
        fp.close()
    except IOError:
        print("fail to open file")

def createFile():
    date = datetime.datetime.now().strftime('%Y-%m-%d')
    path = '/'+date
    if os.path.exists(path):
        return path
    else:
        os.mkdir(path)
        return path