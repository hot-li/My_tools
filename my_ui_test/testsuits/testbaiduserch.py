import unittest
from  public.page.base_page import *
from public.page import base_operation
from public.common.log import Log

class baidu(base_operation.MyTest):

    def testbaidu(self):
        u'''百度搜索'''
        homepage=BasePage(self.driver)
        homepage.open("http://www.baidu.com")
        time.sleep(2)
        self.driver.find_element_by_id("kw").send_keys("selenium")
        self.driver.find_element_by_xpath(".//*[@id='su']").click()
        homepage.get_img("baidu_serch_selenium")



