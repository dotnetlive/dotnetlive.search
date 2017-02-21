import match
import util_file

def saveBlogs():
    path = util_file.createFile()
    for i in range(1,2):
        print('request for '+str(i)+'...')
        blogs = match.blogParser(i)
        #保存到文件
        util_file.writeToTxt(blogs,path+'/blog_'+ str(i) +'.json')
        print('第'+ str(i) +'页已经完成')
    return 'success'

result = saveBlogs()
print(result)