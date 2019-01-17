#coding=utf-8
import os
import  requests
import shutil
from product_info_collection.public.logHelper import *
from product_info_collection.config import settings

logger =Log(logger="file")
class file_helper():
    def save_img(self,img_url,file_dir):
        #图片地址
        img_name =img_url.split('/')[-1]
        save_path=file_dir+'/'+img_name
        try:
            img = requests.get(img_url)
            f = open(save_path,'ab')
            #存储图片，多媒体文件需要参数b（二进制文件）
            f.write(img.content)
            #多媒体存储content
        except Exception as e:
            logger.error("保存图片异常：%s"%e)
        finally:
            f.close()
    def save_file(self,file_path,content):
        try:
            ff=open(file_path,'w')
            ff.write(content)
        except Exception as e:
            logger.error("文件写入异常：%s"%e)
        finally:
            ff.close()

    #获取文件名
    def file_name(self,file_dir):
        for root, dirs, files in os.walk(file_dir):
            return files
    #删除文件夹
    def del_folder(self,folder_dir):
        #删除该文件夹
        try:
            shutil.rmtree(folder_dir)
            logger.info(u"删除文件夹成功：%s！"%folder_dir)
        except Exception as e:
            logger.error(u"删除文件夹异常:%s" % e)
    #递归删除文件夹
    def del_dir_tree(self,folder_dir):
        ''' 递归子目录,　子文件'''
        if os.path.isfile(folder_dir):
            try:
                os.remove(folder_dir)
                logger.info(u"删除文件成功：%s！"%folder_dir)
            except Exception as e:
                #pass
                logger.info(u"删除文件失败：%s！"%folder_dir)
        elif os.path.isdir(folder_dir):
            try:
                for item in os.listdir(folder_dir):
                    #itempath = str(os.path.join(folder_dir, item)).encode('utf-8')
                    itempath = os.path.join(folder_dir, item)
                    if os.path.isdir(itempath):
                        shutil.rmtree(itempath)
                        logger.info(u"删除文件夹成功：%s！"%itempath)
                    elif os.path.isfile(itempath):
                        os.remove(itempath)
                        logger.info(u"删除文件成功：%s！"%itempath)
            except Exception as e:
                logger.info(u"删除文件夹失败：%s！"%folder_dir)
    #获取文件夹下所有的文件名
    def get_filename(self,folder_dir):
        '''获取文件夹下的所有文件名'''
        filename=[]
        for root, dirs, files in os.walk(folder_dir):
            #print(root) #当前目录路径
            #print(dirs) #当前路径下所有子目录
            #print(files) #当前路径下所有非目录子文件
            filename.append(files)
        return filename

    #判断文件夹是否为空
    def is_empty(self,folder_dir):
        if not os.listdir(folder_dir):
            return True
        else:
            return False