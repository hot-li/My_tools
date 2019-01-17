import os
from lxml import etree
from product_info_collection.public.requestHelper import *
from product_info_collection.config import settings
from bs4 import BeautifulSoup

class gdDataGetOpration(object):
    #获取详细分类
    def get_classification(self,url):
        r=requestsOpration()
        html=r.myGetRequest(url)
        soup=BeautifulSoup(html,'html.parser')
        for tag in soup.find_all('div',class_='sub_classify'):
            for i in range(len(tag)):
                try:
                    class_url=tag.find_all('a')[i].get('href')
                    class_name=tag.find_all('a')[i].get_text()
                    print(class_name,class_url)
                except:
                    pass
    #获取商城分类
    def get_Mall_info(self,url):
        r=requestsOpration()
        html=r.myGetRequest(url)
        soup=BeautifulSoup(html,'lxml')
        tag=soup.select('div.select_tag')[0]
        for i in range(len(tag)):
            try:
                class_url=tag.find_all('a')[i].get('href')
                class_name=tag.find_all('a')[i].get_text()
                print(class_name,class_url)
            except:
                pass

    def get_product_info(self,url):
        r=requestsOpration()
        html=r.myGetRequest(url)
        soup=BeautifulSoup(html,'lxml')
        for i in range(31):
            #一页30条
            css_path=('body > div.main.main_hui > div > div > div.bl_list > '
                      'div.bl_list_content > div.bl_box > div.bl_i_lb > ul > li:nth-of-type(%s)'%(i+1))
            info=soup.select(css_path)
            for tag in info:
                #产品url
                product_url=tag.find('div',class_='bl_lb_title').find('a').get('href')
                #直达链接
                product_zhida=tag.find('div',class_='bl_lb_zhida').find('a').get('href')
                #来源
                product_from=tag.find('div',class_='bl_lb_from').get_text()
                #图片
                product_img =tag.find('img',original='').get('data-original')
                #note
                product_note=tag.find('div',class_='bl_lb_note').get_text()
                #title
                product_title=tag.find('div',class_='bl_lb_title').get_text()

                html=r.myGetRequest(product_url)
                product_detail_info=BeautifulSoup(html,'lxml')
                info_detail=product_detail_info.select('body > div.main.main_hui > div > div > div.bl_view > div.bl_v_left')
                for i in info_detail:
                    #原价
                    product_original_price=str(i.find('dd',class_='oprice').get_text()).replace("原价：￥",'')
                    #现价
                    product_now_price=str(i.find('dd',class_='price').get_text()).replace("最终价：￥",'')
                    #推荐理由
                    product_info=i.find('div',class_='bl_v_reason').get_text()
                    print(product_original_price,product_now_price,product_info)




a=gdDataGetOpration()
#a.get_Mall_info(path)
a.get_product_info('http://www.178hui.com/zdm/list/0-0-77-88-1.html')
