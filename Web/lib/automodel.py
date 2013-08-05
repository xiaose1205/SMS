#encoding:utf-8
import MySQLdb
import os, sys
import string
import time
dto = os.getcwd() + "\\dto"
dao = os.getcwd() + "\\dao"
idao = os.getcwd() + "\\dao\\impl"
service = os.getcwd() + "\\service"
iservice = os.getcwd() + "\\service\\impl"
config = os.getcwd() + "\\config"


def convertColum(name):
    if(len(name.replace("_", ""))==len(name)):
        return name
    a =  name.replace("_", " ")
    word = string.capwords(a).replace(" ", "")
    return word

def convertColumCap(name):
    a = name.replace("_", " ")
    word = string.capwords(a).replace(" ", "")
    return word
 
def changeType(type,nullable):
   
    if(type == "varchar"):
        return "string"
    elif(type=="char"):
        return "String"
    elif(type == "int"):
        if(nullable=="YES"):
            return "int?"
        return "int"
    elif(type == "tinyint"):
        if(nullable=="YES"):
            return "int?"
        return "int"
    elif(type == "datetime"):
        if(nullable=="YES"):
            return "DateTime?"
        return "DateTime" 
    elif(type == "float"):
        if(nullable=="YES"):
            return "float?"
        return "float" 
    elif(type == "bit"):
        if(nullable=="YES"):
            return "bool?"
        return "bool" 
    elif(type == "longblob"):
        return "byte[]"
    print(type)
    return "string"
def changeName(name):
    return convertColumCap(name)

def creatrFile(fileP, fileN, fileS):
    if(os.path.exists(fileP) != True):
        os.makedirs(fileP)
    f = file(fileP + "\\" + fileN, 'w')    
    f.write(fileS)
    f.close()
    
print("begining to connect Mysql.")
try:
    dbName = 'sms'
    connection = MySQLdb.connect(user="root", passwd="123456", host="127.0.0.1", db=dbName,port=3309)
    cursor = connection.cursor()
    cursor.execute("SELECT TABLE_NAME,TABLE_COMMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'  AND TABLE_SCHEMA='" + dbName + "' ")
   
    filestr = []
    configstr = []
    for row in cursor.fetchall():
        filestr = []        
        tableName = row[0]
        filestr.append('/*\n'
			'以下代码为python3.0自动生成的代码，请不要擅自修改\n'
			'生成时间:'+ time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()) +'\n'
			'生成机器：wangjun\n'
			'author：xiaose\n'
			'*/\n'
            'using System;\n'
			'using System.Collections.Generic; \n'
			'using System.Text;\n'
			'using HelloData.FrameWork.Data;\n'
            '/// <summary>\n'
            '/// '+row[1]+'   \n'
            '/// </summary>\n'
            '[Serializable]\n'
            'public partial class ' + convertColumCap(tableName) + 'Info: BaseEntity\n' 
			'{\n'
            '    public ' + convertColumCap(tableName) + 'Info(){\n' 
            '         base.SetIni(this,"'+tableName+'","ID");\n'
            '    }\n')
       
        cursor1 = connection.cursor()
        cursor1.execute("SELECT COLUMN_NAME as ColumnName,DATA_TYPE as dataType,IS_NULLABLE AS nullable,COLUMN_KEY as prikey,COLUMN_COMMENT as comment FROM INFORMATION_SCHEMA.COLUMNS  where table_name='" + tableName + "' and TABLE_SCHEMA='" + dbName + "'")
        getsetStr = []
        getcolmuStr=[]
        getcolmuStr.append('    public static class Columns \n')
        getcolmuStr.append('    { \n')
        for row1 in cursor1.fetchall():
            filestr.append('    /// <summary>\n')
            filestr.append('    /// '+row1[4]+'   \n')
            filestr.append('    /// </summary>\n')
            if(row1[3]!=""):
                filestr.append('    [Column(IsKeyProperty = true,AutoIncrement=true)]\n')
            filestr.append('    public ' + changeType(row1[1],row1[2]) + ' ' + convertColum(row1[0]) + ' {get; set;}\n\n')
            
            getcolmuStr.append('        public const string ' + convertColum(row1[0]) + ' = "' + row1[0]+ '";\n')
           
        getcolmuStr.append('    }\n')
     
        getcolmuStr.append('}\n')   
        creatrFile(dto, convertColumCap(tableName) + "Info.cs", ''.join(filestr) + ''.join(getsetStr)+''.join(getcolmuStr))
      
        cursor.close()
    print("end!")
except MySQLdb.Error, e:
    print "Mysql Error %d: %s" % (e.args[0], e.args[1])
    



 
