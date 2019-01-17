#coding=utf-8

import logging
import os.path
import time
from product_info_collection.config import settings

log_path=settings.log_path

class Log(object):

    def __init__(self, logger):
        '''
            指定保存日志的文件路径，日志级别，以及调用文件
            将日志存入到指定的文件中
        '''

        # 创建一个logger
        self.logger = logging.getLogger(logger)
        self.logger.setLevel(logging.DEBUG)

        # 创建一个handler，用于写入日志文件
        log_name = os.path.join(log_path, '{0}.log'.format(time.strftime('%Y-%m-%d')))
        #log_name = log_path + rq + '.log'
        fh = logging.FileHandler(log_name)
        fh.setLevel(logging.INFO)

        # 再创建一个handler，用于输出到控制台
        ch = logging.StreamHandler()
        ch.setLevel(logging.INFO)

        # 定义handler的输出格式
        formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
        fh.setFormatter(formatter)
        ch.setFormatter(formatter)

        # 给logger添加handler
        self.logger.addHandler(fh)
        self.logger.addHandler(ch)

    def __printconsole(self,level,message):
        if level == 'info':
            self.logger.info(message)
            return self.logger
        elif level == 'debug':
            self.logger.debug(message)
            return self.logger
        elif level == 'warning':
            self.logger.warning(message)
            return self.logger
        elif level == 'error':
            self.logger.error(message)
            return self.logger

    def debug(self,message):
        self.__printconsole('debug', message)

    def info(self,message):
        self.__printconsole('info', message)

    def warning(self,message):
        self.__printconsole('warning', message)

    def error(self,message):
        self.__printconsole('error', message)
    #def getlog(self):
        #return self.logger
