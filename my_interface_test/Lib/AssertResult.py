# 结果判断
#!/usr/bin/python
#coding=utf8
import os,sys
import re
import json
from Lib.LogWrite import *

def assert_result(interfaceNum, interfaceApiPurpose,interfaceStatus,interfaceHtml,interfaceCheckPoint):
    #print(interfaceNum, interfaceApiPurpose, interfaceStatus, interfaceHtml, interfaceCheckPoint)
    successNum=0
    failedNum=0
    interfaceApiPurpose=str(interfaceApiPurpose)
    interfaceHtml=str(interfaceHtml)
    interfaceCheckPoint=str(interfaceCheckPoint)

    if interfaceStatus == 200:
        # 断点
        try:
            if re.search(interfaceCheckPoint, interfaceHtml):
                Infolog('用例第' + str(interfaceNum) + '条' + ' - ' + str(interfaceApiPurpose) + ' - ' + ' 断点验证成功！ ' + '[ ' + str(interfaceStatus) + ' ], ' + str(interfaceHtml)+'\n')
                successNum += 1  # 成功的用例个数
                return interfaceStatus, json.loads(interfaceHtml),True,'断点验证成功'
            else:
                Infolog('用例第' + str(interfaceNum) + '条' + ' - ' + str(interfaceApiPurpose) + ' - ' + ' 断点验证失败！' + '[ ' + str(interfaceStatus) + ' ], ' + str(interfaceHtml)+'\n' )
                failedNum += 1  # 失败的用例个数
                return interfaceStatus, json.loads(interfaceHtml),False,'断点验证失败'
        except:
            Errlog('用例第' + str(interfaceNum) + '条' + ' - ' + str(interfaceApiPurpose) + ' - ' + ' 失败！！！'  + '[ ' + str(interfaceStatus) + ' ], ' + str(interfaceHtml)+'\n')
    else:
        Errlog('用例第' + str(interfaceNum) + '条' + ' - ' + str(interfaceApiPurpose) + ' - ' + ' 失败！！！ ' + '[ ' + str(interfaceStatus) + ' ], ' + str(interfaceHtml)+'\n')
        failedNum += 1  # 失败的用例个数
        return interfaceStatus, interfaceHtml,'Failed',"失败"