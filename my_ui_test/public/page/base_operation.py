#coding=utf-8

import unittest
from public.common import browser_engine
from config import globalparam
from public.common.log import Log
from public.page.base_page import *

class MyTest(unittest.TestCase):
    """
    The base class is for all testcase.
    """
    @classmethod
    def setUpClass(cls):
        cls.logger =Log(logger="base_operation")
        cls.logger.info('############################### START ###############################')
        browser = browser_engine.BrowserEngine(globalparam.browser)
        cls.driver = browser.get_driver(cls)
        #cls.dr.max_window()
    @classmethod
    def tearDownClass(cls):
        homepage=BasePage(cls.driver)
        cls.quit = homepage.quit_browser()
        cls.logger.info('############################### END ################################')