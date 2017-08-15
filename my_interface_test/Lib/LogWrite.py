#log模块
#!/usr/bin/python
#coding=utf8
import os
import logging
import datetime

log_path=(os.getcwd().split('Lib',1))[0]
#log_path=os.getcwd()
log_path=log_path+'\\log\\'
#print (log_path)
if not os.path.exists(log_path):
    os.mkdir(log_path)
format='%(asctime)s - %(levelname)s - %(message)s'
curDate = datetime.date.today() - datetime.timedelta(days=0)
LogFileName = log_path + r'Info_%s.log' % curDate

#logger的handler只需要Add一次
testHandler = logging.StreamHandler()
formatter = logging.Formatter('%(asctime)s - %(levelname)s - %(message)s')  # '%(asctime)s- %(name)s - %(levelname)s - %(message)s表示输出函数的名字
testHandler.setFormatter(formatter)


def Infolog(InfoContent):

    formatter = logging.Formatter(format)
    # 创建logger
    infoLogger = logging.getLogger()
    infoLogger.setLevel(logging.INFO)
    infoHandler = logging.FileHandler(LogFileName, 'a')  # 写入日志文件
    #info级别
    infoHandler.setLevel(logging.INFO)  # 定义日志级别
    infoHandler.setFormatter(formatter)  # 定义输出格式
    # 创建一个handler用于输出到控制台
    #testHandler = logging.StreamHandler()
    #formatter = logging.Formatter( '%(asctime)s - %(levelname)s - %(message)s')  # '%(asctime)s- %(name)s - %(levelname)s - %(message)s表示输出函数的名字
    #testHandler.setFormatter(formatter)
    infoLogger.addHandler(testHandler)
    infoLogger.addHandler(infoHandler)
    infoLogger.info(InfoContent)
    #移除infoHandler，避免多次重复写入
    infoLogger.removeHandler(infoHandler)
def Errlog(ErrContent):
    #errorLogName = log_path + r'Error_%s.log' % curDate
    formatter = logging.Formatter(format)
    # 创建logger
    errorLogger = logging.getLogger()
    errorLogger.setLevel(logging.ERROR)
    errorHandler = logging.FileHandler(LogFileName, 'a')#写入日志文件
    # error级别
    errorHandler.setLevel(logging.ERROR)
    errorHandler.setFormatter(formatter)
    errorLogger.addHandler(testHandler)
    errorLogger.addHandler(errorHandler)
    errorLogger.error(ErrContent)
    #移除errorHandler，避免多次重复写入
    errorLogger.removeHandler(errorHandler)
def Warninglog(WarContent):
    #warningLogName = log_path + r'warning_%s.log' % curDate
    formatter = logging.Formatter(format)
    # 创建logger
    warningLogger = logging.getLogger()
    warningLogger.setLevel(logging.WARNING)
    warningHandler = logging.FileHandler(LogFileName, 'a')#写入日志文件
    # warning级别
    warningHandler.setFormatter(formatter)
    warningHandler.setLevel(logging.WARNING)
    warningLogger.addHandler(testHandler)
    # 给logger添加handler
    warningLogger.addHandler(warningHandler)
    warningLogger.warning(WarContent)
    #移除errorHandler，避免多次重复写入
    warningLogger.removeHandler(warningHandler)

