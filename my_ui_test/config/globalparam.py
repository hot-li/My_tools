#coding=utf-8

import os
#获取路径
prj_path=os.getcwd().split('config',1)[0]
# 浏览器
browser = 'Chrome'
# URL
URL='http://www.baidu.com'
# 日志路径
log_path = os.path.join(prj_path, 'log')
# 截图文件路径
img_path = os.path.join(prj_path,  'image')
# 测试报告路径
report_path = os.path.join(prj_path, 'report')
# 测试数据路径
data_path = os.path.join(prj_path, 'data')
# 驱动路径
driver_path= os.path.join(prj_path,  'tools')

for i in [log_path,img_path,report_path]:
    if not os.path.exists(i):
        os.mkdir(i)


