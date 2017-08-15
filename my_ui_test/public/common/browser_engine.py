# -*- coding:utf-8 -*-
import os
#import ConfigParser#这是2.X的写法
import configparser
import  time
from selenium import webdriver
from public.common.log import Log
from config import globalparam

logger =Log(logger="browser_engine")
driverpath=globalparam.prj_path
success = "SUCCESS"
fail = "FAIL"

class BrowserEngine(object):
    chrome_driver_path = driverpath + '/tools/chromedriver.exe'
    ie_driver_path = driverpath + '/tools/IEDriverServer.exe'
    def __init__(self, driver):
        self.driver = driver
    def get_driver(self,dr, browser="Chrome", remoteAddress=None):
        t1 = time.time()
        dc = {'platform': 'ANY', 'browserName': 'chrome', 'version': '', 'javascriptEnabled': True}
        dr = None
        if remoteAddress is None:
            if browser == "firefox" or browser == "ff":
                dr = webdriver.Firefox()
                logger.info("Starting firefox browser.")
            elif browser == "chrome" or browser == "Chrome":
                dr = webdriver.Chrome(self.chrome_driver_path)
                logger.info("Starting Chrome browser.")
            elif browser == "internet explorer" or browser == "ie":
                dr = webdriver.Ie(self.ie_driver_path)
                logger.info("Starting IE browser.")
            '''
            elif browser == "opera":
                dr = webdriver.Opera()
            elif browser == "phantomjs":
                dr = webdriver.PhantomJS()
            elif browser == "edge":
                dr = webdriver.Edge()
            '''
        else:
            if browser == "RChrome":
                dr = webdriver.Remote(command_executor='http://' + remoteAddress + '/wd/hub',
                                      desired_capabilities=dc)
                logger.info("Starting RChrome browser.")
            elif browser == "RIE":
                dc['browserName'] = 'internet explorer'
                dr = webdriver.Remote(command_executor='http://' + remoteAddress + '/wd/hub',
                                      desired_capabilities=dc)
                logger.info("Starting RIE browser.")
            elif browser == "RFirefox":
                dc['browserName'] = 'firefox'
                dc['marionette'] = False
                dr = webdriver.Remote(command_executor='http://' + remoteAddress + '/wd/hub',
                                      desired_capabilities=dc)
                logger.info("Starting RFirefox browser.")
        try:
            self.driver = dr
            logger.info("{0} Start a new browser: {1}, Spend {2} seconds".format(success,browser,time.time()-t1))
        except Exception:
            raise NameError("Not found {0} browser,You can enter 'ie','ff',"
                            "'chrome','RChrome','RIe' or 'RFirefox'.".format( browser))
        return dr



