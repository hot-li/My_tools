#coding=utf-8

import os
import pymysql
from product_info_collection.config import settings
from product_info_collection.public.logHelper import *

logger =Log(logger="Mysql")


class MYSQL:
    # 初始化函数，初始化连接列表
    def __init__(self):
        #配置文件读取mysql配置
        self.host   = settings.ip
        self.user   = settings.username
        self.pwd    = settings.password
        self.dbname = settings.dbname
		
		
    # 获取数据库游标对象cursor
    # 游标对象：用于执行查询和获取结果
    def getCursor(self):
        try:
            self.db = pymysql.connect(self.host,self.user,self.pwd,self.dbname)
            # 创建游标对象
            cur = self.db.cursor()
            return cur
        except Exception as e:
            print ("Could not connect to MySQL server!")

    # 查询操作
    def queryOperation(self,sql):
        # 建立连接获取游标对象
        cur = self.getCursor()
        try:
            cur.execute(sql)
            # 获取数据的行数
            row = cur.rowcount
            # 获取查询数据
            # fetch*
            # all 所有数据,one 取结果的一行，many(size),去size行
            dataList = cur.fetchall()
            # 返回查询的数据
            return dataList,row
        except Exception as e:
            logger.error("sql执行错误：%s"%e)
        finally:
            # 关闭游标对象
            cur.close()
            # 关闭连接
            self.db.close()

    # 增删改操作
    def addInsetIdeletOperation(self,sql):
        # 建立连接获取游标对象
        cur = self.getCursor()
        try:
            cur.execute(sql)
            self.db.commit()
        except Exception as e:
            #回滚
            self.db.rollback()
            logger.error("sql执行错误：%s"%e)
        finally:
            # 关闭游标对象和db连接
            cur.close()
            self.db.close()


