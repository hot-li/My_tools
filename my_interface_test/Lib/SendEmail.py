#邮件模块
#!/usr/bin/python
#coding=utf8
import os
import smtplib
import datetime
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.application import MIMEApplication
from email.utils import formataddr

def mail(content,receiver):
    _user = 'dalaopo7891@163.com'
    _pwd = 'babaya5201314'
    _to = receiver

    msg = MIMEMultipart()
    msg["Subject"] ="接口自动化测试完成通知"
    msg["From"] = formataddr(["自动化测试中心", _user])#发件人邮箱昵称、发件人邮箱账号
    msg["To"] = formataddr([_to, _to]) #收件人邮箱昵称、收件人邮箱账号
    ret = True
    # ---这是文字部分---
    part = MIMEText(content, 'plain','utf-8')
    msg.attach(part)
    # ---这是附件部分---
    # xlsx类型附件

    #获取附件地址
    path = (os.getcwd())
    email_path = path + '\\ResultReport\\'
    if not os.path.exists(email_path):
        os.mkdir(email_path)
    curDate = datetime.date.today() - datetime.timedelta(days=0)
    filePath = email_path + r'Report_%s.xlsx' % curDate

    try:
        # 添加xlsx附件
        name = ('TestReport_%s.xlsx' % curDate)
        part = MIMEApplication(open(filePath, 'rb').read())
        part.add_header('Content-Disposition', 'attachment', filename=name)
        msg.attach(part)
        '''
        # jpg类型附件
        part = MIMEApplication(open('foo.jpg', 'rb').read())
        part.add_header('Content-Disposition', 'attachment', filename="foo.jpg")
        msg.attach(part)

        # pdf类型附件
        part = MIMEApplication(open('foo.pdf', 'rb').read())
        part.add_header('Content-Disposition', 'attachment', filename="foo.pdf")
        msg.attach(part)

        # mp3类型附件
        part = MIMEApplication(open('foo.mp3', 'rb').read())
        part.add_header('Content-Disposition', 'attachment', filename="foo.mp3")
        msg.attach(part)
        '''
        s = smtplib.SMTP("smtp.163.com", timeout=30)  # 连接smtp邮件服务器,端口默认是25
        s.login(_user, _pwd)  # 登陆服务器
        s.sendmail(_user, _to, msg.as_string())  # 发送邮件
        s.close()
    except Exception:
        ret = False
    return ret
'''
ret=mail('hello,小丽啊，明天来上班吧', '164845216@qq.com')
if ret:
    print("邮件发送成功")
else:
    print("邮件发送失败")
'''