import csv #java의 import같은 것
import pymysql
f = open("sangin.csv",'r',encoding='utf-8')
rdr = csv.reader(f)
count = 0
mydata = []
for line in rdr:
        mydata.append(line)

del mydata[0]

for item in mydata:
    print(item)

f.close() #파일 관련 객체 종료시킴

sql = 'insert into weather(lowTemp, highTemp) values(%f, %f)'
for item in mydata:
    try :
        conn = pymysql.connect(host='localhost',
                               user='root',
                               password='1234',
                               db='shopping',
                               charset='utf8')
        with conn: #db 연결 및 끊어주는 걸 자동으로 함. db명령수행하면 자동끊김
            with conn.cursor() as cur: #conn의 cursor를 cur로 변경(db 안의 커서)
                print(sql % ( float(item[2]), float(item[4]) ))
                cur.execute(
                    sql % ( float(item[2]), float(item[4]) )
                )
                conn.commit()
    except :
        pass
