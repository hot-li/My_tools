# 接口测试模块
#!/usr/bin/python
#coding=utf8
import os
import  re
import json
import  socket
import logging
import urllib.parse
import urllib.request

socket.setdefaulttimeout(2)#接口请求超时时间

#print (s[1])
def interfaceTest(api_host,request_url,request_method,request_data,active):
    url = api_host + request_url
    #requests.get(timeout=5)
    if active=='yes' or active=='YES':
        headers = {
                   'X-Requested-With': 'XMLHttpRequest',
                   'Connection': 'keep-alive',
                   'content-type':'application/json',
                   'Referer': api_host,
                   'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 MicroMessenger/6.5.2.501 NetType/WIFI WindowsWechat QBCore/3.43.556.400 QQBrowser/9.0.2524.400'
                   }
        #get请求
        if request_method=='GET' or request_method=='get' :
            data = urllib.parse.urlencode(request_data)
            # print(url_values)
            url =url+'&'#连接字符串的符号需要示情况而定
            full_url = url + data
            #print(full_url)
            try:
                response = urllib.request.urlopen(full_url)
                html = response.read().decode('UTF-8')
                status = response.status
                #写参数入列表
                return status, str(html)
            except :
                #print('接口请求失败！')
                return 400, '接口请求失败！'

        #post请求
        elif request_method=='POST' or request_method== 'post':
            #data = urllib.parse.urlencode(request_data).encode('utf-8')
            data=json.dumps(request_data).encode('utf-8')
            #print (url)
            try:
                req = urllib.request.Request(url, data,headers)
                response = urllib.request.urlopen(req)
                #接口响应
                html = response.read().decode('UTF-8')
                #接口请求状态
                status = response.status
                return status, str(html)
            except:
                #print('接口请求失败！')
                return 400, '接口请求失败！'
        else:
            return 400, "接口请求失败！请检查API_HOST是否正确,当前API_HOST:"+request_method





