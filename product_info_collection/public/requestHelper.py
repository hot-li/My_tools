#coding=utf-8
import  requests
from product_info_collection.public.logHelper import *
logger =Log(logger="Request")

class requestsOpration(object):
    headers = {
                       'X-Requested-With': 'XMLHttpRequest',
                       'Connection': 'keep-alive',
                       'content-type':'application/json',
                       'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 MicroMessenger/6.5.2.501 NetType/WIFI WindowsWechat QBCore/3.43.556.400 QQBrowser/9.0.2524.400'
                       }

    def myPostRequest(self,headers,data):

        r = requests.post('https://api.github.com/some/endpoint', data=data, headers=headers)
        print(r.text)
        print(r.cookies['NID'])
        print(tuple(r.cookies))


        #带cookies
        s = requests.Session()
        s.headers.update(headers)
        # s.auth = ('superuser', '123')
        s.get('https://www.kuaipan.cn/account_login.htm')

        _URL = 'http://www.kuaipan.cn/index.php'
        s.post(_URL, params={'ac':'account', 'op':'login'},
               data={'username':'****@foxmail.com', 'userpwd':'********', 'isajax':'yes'})
        r = s.get(_URL, params={'ac':'zone', 'op':'taskdetail'})
        print(r.json())
        s.get(_URL, params={'ac':'common', 'op':'usersign'})
    def myGetRequest(self,url):
        r=requests.get(url,headers=self.headers,verify=False)
        return  r.text
