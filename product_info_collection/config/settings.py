#coding=utf-8

import os

prj_path=os.getcwd().split('config',1)[0]
#--------mysql配置-----------
ip='127.0.0.1'
username='root'
password='root'
port='3306'
dbname=''
#--------yqh数据爬取地址----------
#分类爬取地址
classification_path='http://www.178hui.com/zdm/list/0-0-77-88-1.html'
img_save_path='D:\img_path'

#--------数据注入地址----------

#--------常用路径配置----------
# 日志路径
log_path = os.path.join(prj_path, 'log')

for i in [log_path,img_save_path]:
    if not os.path.exists(i):
        os.mkdir(i)
