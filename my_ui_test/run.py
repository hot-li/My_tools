import os
import time
import unittest
import HTMLTestRunner
from config import globalparam
from public.common.sendEmail import *

# 用例路径
case_path = os.path.join(globalparam.prj_path, "testsuits")
# 获取时间
now = time.strftime("%Y-%m-%d-%H_%M_%S", time.localtime(time.time()))
# 报告存放路径
report_path = globalparam.report_path+'/'+now+"_Result.html"

def all_case():
    discover = unittest.defaultTestLoader.discover(case_path, pattern="test*.py",top_level_dir=None)
    #print(discover)
    return discover

if __name__ == "__main__":
    # html报告文件路径
    fp = open(report_path, "wb")
    runner = HTMLTestRunner.HTMLTestRunner(stream=fp,title=u'自动化测试报告,测试结果如下：',description=u'用例执行情况：')
    # 调用add_case函数返回值
    runner.run(all_case())
    fp.close()
    '''
    #发送邮件
    mail=SendMail()
    mail.send()
    '''
