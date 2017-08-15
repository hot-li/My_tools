#报告模块
#!/usr/bin/python
#coding=utf8
import os
import datetime
try:
    import xlsxwriter
except:
    os.system('pip install -U xlsxwriter')
    import xlsxwriter


#新建report路径
Path=(os.getcwd())
re_path=Path+'\\ResultReport\\'
if not os.path.exists(re_path):
    os.mkdir(re_path)
curDate = datetime.date.today() - datetime.timedelta(days=0)
ReportPath=''
def re_name(name):
    global ReportPath
    ReportPath = re_path + r'Report_%s.xlsx' % curDate
workbook = xlsxwriter.Workbook(ReportPath)
#新建sheet
worksheet = workbook.add_worksheet("测试概况")
worksheet2 = workbook.add_worksheet("测试详情")


def get_format(wd, option={}):
    return wd.add_format(option)

# 设置居中
def get_format_center(wd,num=1):
    return wd.add_format({'align': 'center','valign': 'vcenter','border':num})

def set_border_(wd, num=1):
    return wd.add_format({}).set_border(num)

# 写数据
def _write_center(worksheet,cl, data, wd):
    return worksheet.write(cl, data, get_format_center(wd))

def init(initData,detailData):
    # 设置列行的宽高
    worksheet.set_column("A:A", 15)
    worksheet.set_column("B:B", 20)
    worksheet.set_column("C:C", 20)
    worksheet.set_column("D:D", 20)
    worksheet.set_column("E:E", 20)
    worksheet.set_column("F:F", 20)

    worksheet.set_row(1, 30)
    worksheet.set_row(2, 30)
    worksheet.set_row(3, 30)
    worksheet.set_row(4, 30)
    worksheet.set_row(5, 30)

    # worksheet.set_row(0, 200)

    define_format_H1 = get_format(workbook, {'bold': True, 'font_size': 18})
    define_format_H2 = get_format(workbook, {'bold': True, 'font_size': 14})
    define_format_H1.set_border(1)

    define_format_H2.set_border(1)
    define_format_H1.set_align("center")
    define_format_H2.set_align("center")
    define_format_H2.set_bg_color("blue")
    define_format_H2.set_color("#ffffff")
    # Create a new Chart object.

    worksheet.merge_range('A1:F1', '测试报告总概况', define_format_H1)
    worksheet.merge_range('A2:F2', '测试概括', define_format_H2)
    worksheet.merge_range('A3:A6', '巨鲸互娱', get_format_center(workbook))

    _write_center(worksheet, "B3", '项目名称', workbook)
    _write_center(worksheet, "B4", '接口版本', workbook)
    _write_center(worksheet, "B5", '脚本语言', workbook)
    _write_center(worksheet, "B6", '测试网络', workbook)

    data=initData
    #data = {"test_name": "云丛人脸分析", "test_version": "v1.0.000", "test_pl": "Python", "test_net": "wifi"}
    _write_center(worksheet, "C3", data['test_name'], workbook)
    _write_center(worksheet, "C4", data['test_version'], workbook)
    _write_center(worksheet, "C5", data['test_pl'], workbook)
    _write_center(worksheet, "C6", data['test_net'], workbook)

    _write_center(worksheet, "D3", "接口总数", workbook)
    _write_center(worksheet, "D4", "通过总数", workbook)
    _write_center(worksheet, "D5", "失败总数", workbook)
    _write_center(worksheet, "D6", "测试日期", workbook)

    data1=detailData
    #data1 = {"test_sum": 100, "test_success": 80, "test_failed": 20, "test_date": "2018-10-10 12:10"}
    _write_center(worksheet, "E3", data1['test_sum'], workbook)
    _write_center(worksheet, "E4", data1['test_success'], workbook)
    _write_center(worksheet, "E5", data1['test_failed'], workbook)
    _write_center(worksheet, "E6", data1['test_date'], workbook)
    _write_center(worksheet, "F3", "分数", workbook)
    score=(1-(data1['test_failed']/data1['test_sum']))*100
    worksheet.merge_range('F4:F6', '%.2f' %score+"%", get_format_center(workbook))
    #pie(workbook, worksheet)
 # 生成饼形图

def pie(self):
    chart1 = workbook.add_chart({'type': 'pie'})
    chart1.add_series({
    'name':       '接口测试统计',
    'categories':'=测试概况!$D$4:$D$5',#读取$D$4:$D$52个标题
    'values':    '=测试概况!$E$4:$E$5',#读取$D$4:$D$5的值，用于饼状图
    })
    chart1.set_size({'width': 835, 'height': 340})#饼状图长宽
    chart1.set_title({'name': '接口测试统计'})
    chart1.set_style(10)#颜色
    worksheet.insert_chart('A8', chart1, {'x_offset': 0, 'y_offset': 10})#A9是图表中的坐标，x_offset X轴偏移度

def test_detail(resultDate,nrows=3):
    #format = workbook.add_format()
    #format.set_align('left')
    #format.set_text_wrap("G:G")
    # 设置列行的宽高
    worksheet2.set_column("A:A", 5)
    worksheet2.set_column("B:B", 20)
    worksheet2.set_column("C:C", 10)
    worksheet2.set_column("D:D", 45)
    worksheet2.set_column("E:E", 80)
    worksheet2.set_column("F:F", 30)
    worksheet2.set_column("G:G", 100)
    worksheet2.set_column("H:H", 40)
    worksheet2.set_column("I:I", 25)

    worksheet2.set_row(1, 30)
    worksheet2.set_row(2, 30)
    worksheet2.set_row(3, 30)
    worksheet2.set_row(4, 30)
    worksheet2.set_row(5, 30)
    worksheet2.set_row(6, 30)
    worksheet2.set_row(7, 30)
    worksheet2.set_row(8, 30)

    worksheet2.merge_range('A1:H1', '测试详情', get_format(workbook, {'bold': True, 'font_size': 18, 'align': 'center',
                                                                  'valign': 'vcenter', 'bg_color': 'blue',
                                                                  'font_color': '#ffffff'}))
    _write_center(worksheet2, "A2", '用例ID', workbook)
    _write_center(worksheet2, "B2", '接口用例名称', workbook)
    _write_center(worksheet2, "C2", '接口协议', workbook)
    _write_center(worksheet2, "D2", 'URL', workbook)
    _write_center(worksheet2, "E2", '参数', workbook)
    _write_center(worksheet2, "F2", '预期值', workbook)
    _write_center(worksheet2, "G2", '实际值', workbook)
    _write_center(worksheet2, "H2", '断言', workbook)
    _write_center(worksheet2, "I2", '测试结果', workbook)
    '''
    data = {"info": [{"t_id": "1001", "t_name": "登陆", "t_method": "post", "t_url": "http://XXX?login",
                      "t_param": "{user_name:test,pwd:111111}",
                      "t_hope": "{code:1,msg:登陆成功}", "t_actual": "{code:0,msg:密码错误}", "t_result": "失败"},
                     {"t_id": "1002", "t_name": "商品列表", "t_method": "get", "t_url": "http://XXX?getFoodList",
                      "t_param": "{}",
                      "t_hope": "{code:1,msg:成功,info:[{name:123,detal:dfadfa,img:product/1.png},{name:456,detal:dfadfa,img:product/1.png}]}",
                      "t_actual": "{code:1,msg:成功,info:[{name:123,detal:dfadfa,img:product/1.png},{name:456,detal:dfadfa,img:product/1.png}]}",
                      "t_result": "成功"}],
           "test_sum": 100, "test_success": 20, "test_failed": 80}
    '''
    data = resultDate
    _write_center(worksheet2, "A" + str(nrows), resultDate["t_id"], workbook)
    _write_center(worksheet2, "B" + str(nrows), resultDate["t_name"], workbook)
    _write_center(worksheet2, "C" + str(nrows), resultDate["t_method"], workbook)
    _write_center(worksheet2, "D" + str(nrows), resultDate["t_url"], workbook)
    _write_center(worksheet2, "E" + str(nrows), resultDate["t_param"], workbook)
    _write_center(worksheet2, "F" + str(nrows), resultDate["t_hope"], workbook)
    _write_center(worksheet2, "G" + str(nrows), resultDate["t_actual"], workbook)
    _write_center(worksheet2, "H" + str(nrows), resultDate["t_check_point"], workbook)
    _write_center(worksheet2, "I" + str(nrows), resultDate["t_result"], workbook)


def writeReportDetail(resultDate,nrows):#数据，行
    test_detail(resultDate,nrows)
    #workbook.close()
def writeReportInit(initData,detailData):#dict传参，报表基础数据+详细数据
    init(initData,detailData)
    pie()
    workbook.close()
