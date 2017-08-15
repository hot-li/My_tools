#!/usr/bin/python
#coding=utf8

import os
import time
from Lib.ExcelRW import *
from Lib.ExcelReport import *
from Lib.Interface import interfaceTest
from Lib.AssertResult import assert_result
from Lib.SendEmail import *
from Lib.LogWrite import *

def runTest():
    time = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())
    #获取系统进程路径
    DirPath = (os.getcwd())+'\TestCase'
    # TestCase路径下轮询
    for filename in os.listdir(DirPath):
        SNo = 0  # 断点成功用例数
        FNo = 0  # 断点失败用例数
        FailedNo = 0  # 执行用例失败数

        print("%s----用例执行开始，%s"%(filename,time))
        TestCasepath=DirPath+'\\'+filename
        TestCaseNUM = get_ncase(TestCasepath) # 获取用例总数
        report_name=filename.replace('.xlsx','')
        re_name(report_name)
        for i in range(1, TestCaseNUM+1):
            num, api_purpose, api_host, request_url, request_method, request_data, encryption, check_point, active= ReadExcel(TestCasepath, i)# 表格读取
            status, requesthtml= interfaceTest(api_host,request_url, request_method,eval(request_data),active)#eval将request_data从str转换为dict
            try:
                interfaceStatus, interfaceHtml, boolresult, breakpoint = assert_result(num, api_purpose, status,requesthtml, check_point)  # 断点
            except:
                print ("断言异常！")

            # 接口请求数据组装
            Detaildata = {"t_id": num, "t_name": api_purpose, "t_method": request_method,
                          "t_url":  api_host + request_url, "t_param": request_data, "t_hope": '',
                          "t_actual": requesthtml, "t_result": breakpoint,"t_check_point": check_point}

            # 按报告行数逐步生成测试报告详细数据
            writeReportDetail(Detaildata,i+2)
            if boolresult==True:
                SNo += 1#断言成功+1
            elif boolresult==False:
                FNo += 1#断言失败+1
            else:
                FailedNo += 1

        # 测试报告基本数据写入
        writeReportInit({"test_name": "巨鲸互娱彩票项目", "test_version": "v1.1.0000", "test_pl": "Python", "test_net": "wifi"},{"test_sum": TestCaseNUM, "test_success":SNo, "test_failed": FNo+FailedNo, "test_date": time})
        print("%s----用例执行结束，%s" % (filename, time))
    '''
    ret = mail("接口测试完成，请在附件中查看测试结果", '164845216@qq.com') #邮件发送
    if ret:
        Infolog("邮件发送成功")
    else:
        Errlog("邮件发送失败")
    '''





