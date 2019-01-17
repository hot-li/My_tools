#coding=utf-8
import  json
from lxml import etree
from product_info_collection.public.logHelper import *
logger =Log(logger="Data Extraction")


class myDataExtraction(object):
    def getXpathData(self,wb_data,xpath_path):
        html = etree.HTML(wb_data)
        html_data=html.xpath(xpath_path)#此时返回的是各个标签对象
        return html_data