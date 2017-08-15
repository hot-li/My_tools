#coding=utf-8
from config import globalparam

# 截图放到report下的img目录下
def get_img(dr, filename):
    path = globalparam.img_path + '\\' + filename
    dr.get_screenshot_as_file(path)

