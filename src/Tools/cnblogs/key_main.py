import key_analyze
import util_file

def saveBlogs(key,index):
    path = util_file.createFile()
    blogs = key_analyze.analyzeList(key,index)
    #保存到文件
    util_file.writeToTxt(blogs,path+'/blog_key_'+ key + '_'+ str(index) + '.json')
    return 'success'


def saveBlogsWithKeys():
    #keys = ['net','java','javascript','python']
    keys = ['DB','SqlServer','HBase','MVC','core']
    for i in range(1,51):
        for k in keys:
            print('searching with key :'+k)
            saveBlogs(k,i)
            print('success in page :'+ str(i))



saveBlogsWithKeys()