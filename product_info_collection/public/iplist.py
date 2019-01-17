import requests
import re
import time
from lxml import etree
from bs4 import BeautifulSoup
from product_info_collection.public.fileHelper import *


class XiciProxy:
    def __init__(self,url,headers,url_baidu):
        self.url = url
        self.headers = headers
        self.req = requests.session()
        self.url_baidu = url_baidu
        self.list_proxy = []

    def get_proxy_ip(self):
        html = self.req.get(url = self.url,headers=self.headers).content.decode('utf-8')
        xptah_html = etree.HTML(html)
        resopnse = xptah_html.xpath('//table[@id="ip_list"]/tr')
        resopnse.remove(resopnse[0])

        for i in resopnse:
            ip_info = i.xpath('td[2]/text()')[0]
            port_info = i.xpath('td[3]/text()')[0]
            # print(ip_info,port_info)
            self.available_proxy(ip_info,port_info)

    def available_proxy(self,ip_info,port_info):
        # list_proxy = []
        self.proxies = {
            'https':'{}:{}'.format(ip_info,port_info),
            'http':'{}:{}'.format(ip_info,port_info)
        }
        # print(self.proxies)
        try:
            start=time.clock()
            html = requests.get(url=self.url_baidu,headers=self.headers,timeout = 5,proxies = self.proxies).status_code
            end=time.clock()
            tisme=round((end-start),2)
        except Exception:
            print('无效代理IP:%s:%s'%(ip_info,port_info))
        else:
            if  html == 200:
                print('代理成功:%s:%s,耗时:%s'%(ip_info,port_info ,tisme ))
                # print('可用代理IP:{},端口是:{}'.format(ip_info,port_info))
                self.list_proxy.append(ip_info+ ':' +port_info)
            else:
                print('超时错误.....')
        # return list_proxy

    def proxy_ip_lsit(self):
        return self.list_proxy


headers = {
    'User-Agent':'Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36'
}
url = ['http://www.xicidaili.com/nn/1','http://www.xicidaili.com/nn/2','http://www.xicidaili.com/nn/3']
url_baidu = 'https://www.baidu.com'
file_helper=file_helper()
times=time.strftime("%Y-%m-%d %H-%H-%S")
file_path='D:/iplist/'+times+".txt"
for i in url:
    xiciproxy = XiciProxy(i,headers,url_baidu)
    xiciproxy.get_proxy_ip()
    proxy_ip_lsit = xiciproxy.proxy_ip_lsit()
    # print(proxy_ip_lsit)
    for i in proxy_ip_lsit:
        print('可用代理有:{}'.format(i))

