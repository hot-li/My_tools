#hashlib加密
#!/usr/bin/python
#coding=utf8

import hashlib
import types
import json 
from json import *

def hash1Encode(codeStr):
    hashobj = hashlib.sha1()
    hashobj.update(codeStr.encode(encoding='utf-8'))
    return hashobj.hexdigest()

def md5Encode(codeStr):
    #参数必须是byte类型，否则报Unicode-objects must be encoded before hashing错误
    m = hashlib.md5(codeStr.encode(encoding='utf-8'))
    return m.hexdigest()





