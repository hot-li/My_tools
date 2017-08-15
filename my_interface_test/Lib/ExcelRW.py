#xrld表格数据读写模块
#!/usr/bin/python
#coding=utf8

import logging
import os,sys
try:
    import xlrd
    from xlutils3.copy import copy
except:
    os.system('pip install -U xlrd')#需要安装pip
    import xlrd
try:
    from xlutils3.copy import copy
except:
    os.system('pip install -U xlutils3')#需要安装pip
    from xlutils3.copy import copy
#读取表格
def ReadExcel(CaseFilePath,nrows):
    testCaseFile = os.path.join(os.getcwd(),CaseFilePath)#os.getcwd获取当前目录
    if not os.path.exists(testCaseFile):
        logging.error('测试用例文件不存在！！！')
        sys.exit()
    testCase = xlrd.open_workbook(testCaseFile)
    table = testCase.sheet_by_index(0)#通过索引顺序获取
    #print (table.nrows)
    #nrows行数，ncols列数
    #获取整行和整列的值，table.row_values(i)，table.col_values(i)
    #ExcelData={"num":'',"api_purpose":'',"api_host":'',"request_url":'',"request_method":'',"request_data":'',"encryption":'',"check_point":'',"active":''}
    #for i in range(1,table.nrows):
    #if table.cell(i,10).value.replace('\n','').replace('\r','') != 'Yes':#判断一行11列的值是不是都有，如果没有，就不循环到这条
        #continue
    num = str(int(table.cell(nrows,0).value)).replace('\n','').replace('\r','')#获取num的值，第二行第一列，下面依次往下推
    api_purpose = table.cell(nrows,1).value.replace('\n','').replace('\r','')#replace(a,b)  a被替换的内容，b替换后的内容
    api_host = table.cell(nrows,2).value.replace('\n','').replace('\r','')#
    request_url = table.cell(nrows,3).value.replace('\n','').replace('\r','')
    request_method = table.cell(nrows,4).value.replace('\n','').replace('\r','')
    request_data = table.cell(nrows,5).value.replace('\n','').replace('\r','')
    encryption = table.cell(nrows,6).value.replace('\n','').replace('\r','')#加密方法
    check_point = table.cell(nrows,7).value.replace('\n','').replace('\r','')
    active=table.cell(nrows,8).value.replace('\n','').replace('\r','')
    return num,api_purpose,api_host,request_url,request_method,request_data,encryption,check_point,active

#写表格
def WriteExcel(CaseFilePath,value,i,j):
    testCaseFile = os.path.join(os.getcwd(),CaseFilePath)#os.getcwd获取当前目录
    if not os.path.exists(testCaseFile):
        logging.error('需要写入的Excel文件不存在！！！')
        sys.exit()
    TestCase = xlrd.open_workbook(testCaseFile)#打开Excel文件读取数据
    table = TestCase.sheet_by_index(0)#通过索引顺序获取
    wb=copy(TestCase)
    Sheet=wb.get_sheet(0)
    try:
        Sheet.write(i,j,value)
        wb.save(testCaseFile)
        print("写入数据成功")
    except:
        print("写入数据失败")

#获取用例个数
def get_ncase(testCaseFile):
    try:
        testCase = xlrd.open_workbook(testCaseFile)
        table = testCase.sheet_by_index(0)  # 通过索引顺序获取
        rows_num = table.nrows-1
        return rows_num
    except:
        print('获取Case个数失败')

#a=get_ncase(r'E:\测试源码和工具\PythonDemo\my_interface_test\TestCase\TestCase.xlsx')
#print (a)
#s1=ReadExcel(r'D:\测试相关工具\PythonDemo\my_interface_test\TestCase\TestCase.xlsx')
