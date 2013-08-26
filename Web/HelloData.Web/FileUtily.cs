#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/25 15:02:44
* 文件名：FileUtily
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Cells;

namespace HelloData.Web
{
    public class FileUtily
    {
        public static DataTable ReadDataTable(string filePath, int? workSheetIndex, string separator, bool isheader = true)
        {
            string fileExtension = Path.GetExtension(filePath);
            if (Path.GetExtension(filePath).ToLower().Contains("xls"))
                return FileUtily.ReadDataTable(filePath, (char)44, isheader);
            else
                return FileUtily.ReadDataTable(filePath, !string.IsNullOrEmpty(separator) ? separator[0] : char.MinValue, isheader);
        }

        public static DataTable ReadDataTable(string filePath, char separator, bool isFirstRowAsColumnNames = true)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            DataTable dt = null;
            try
            {
                var encoding = DetectEncoding(filePath);
                var fileExtension = Path.GetExtension(filePath);
                if (string.Equals(fileExtension, ".xls", StringComparison.InvariantCultureIgnoreCase))
                {
                    Workbook wk = new Workbook();
                    wk.Open(filePath);// 这儿
                    var ws = wk.Worksheets[0];
                    dt = ReadDateTable(ws,isFirstRowAsColumnNames);
                    return dt;

                    //return dt;
                }
                else
                {
                    dt = new DataTable();
                    var lines = File.ReadAllLines(filePath, encoding);
                    if (lines.Length > 0)
                    {
                        var columnNames = lines[0].Split(separator);

                        if (isFirstRowAsColumnNames)
                        {
                            foreach (var columnName in columnNames)
                            {
                                dt.Columns.Add(columnName);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                dt.Columns.Add("ColumnName" + i);
                            }
                        }

                        for (int i = 0; i < lines.Length; i++)
                        {
                            var line = lines[i];
                            if ((isFirstRowAsColumnNames && i == 0)) continue;

                            var values = line.Split(separator);
                            var isNullOrEmpty = values.All(x => string.IsNullOrEmpty((string)x));
                            if (isNullOrEmpty) continue;

                            var dr = dt.NewRow();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j < values.Length)
                                {
                                    dr[j] = values[j];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }

                    return dt;

                }

            }
            catch (InvalidOperationException e)
            {
                if (e.Message.Contains("more than"))
                {
                    throw new Exception("导入文件存在相同的列名");
                }
                throw e;
            }
            catch (DuplicateNameException e)
            {
                if (e.Message.Contains("列已属于此"))
                {
                    throw new Exception("导入文件存在相同的列名");
                }
                else if (e.Message.Contains("belongs to this"))
                {
                    throw new Exception("导入文件存在相同的列名");
                }
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public const string LONG_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private static DataTable ReadDateTable(Worksheet sheet, bool isheader)
        {
            var dt = new DataTable();
            if (!isheader)
                for (int j = 0; j < sheet.Cells.MaxColumn + 1; j++)
                {
                    dt.Columns.Add("ColumnName" + j);
                }

            for (int i = 0; i < sheet.Cells.MaxRow + 1; i++)
            {
                var row = dt.NewRow();
                dt.Rows.Add(row);
                for (int j = 0; j < sheet.Cells.MaxColumn + 1; j++)
                {
                    if (sheet.Cells[i, j].Value != null)
                    {
                        if (isheader&&i == 0)
                        {
                            dt.Columns.Add(sheet.Cells[i, j].Value.ToString());
                            continue; 
                        }
                        if (sheet.Cells[i, j].Type == CellValueType.IsDateTime)
                        {
                            row[j] = sheet.Cells[i, j].DateTimeValue.ToString(LONG_DATETIME_FORMAT);
                        }
                        else
                        {
                            row[j] = sheet.Cells[i, j].Value.ToString();
                        }
                    }
                }
            }

            return dt;
        }
        private static void RemoveEmptyRow(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var itemArray = dt.Rows[i].ItemArray;
                for (int j = 0; j < itemArray.Length; j++)
                {
                    dt.Rows[i][j] = dt.Rows[i][j] == DBNull.Value ? "" : dt.Rows[i][j].ToString();
                    itemArray[j] = dt.Rows[i][j] == DBNull.Value ? "" : dt.Rows[i][j].ToString();
                }

                var isNullOrEmpty = itemArray.All(x => string.IsNullOrEmpty((string)x));
                if (isNullOrEmpty)
                {
                    dt.Rows.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// 检查文件的编码，自动打开、关闭文件流
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Encoding DetectEncoding(string filePath)
        {
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return DetectEncoding(file);
            }
        }

        /// <summary>
        /// 检查流的字节编码
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Encoding DetectEncoding(Stream stream)
        {
            if (stream.CanSeek)
            {
                byte[] bom = new byte[4];
                stream.Read(bom, 0, 4);
                if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
                {
                    return Encoding.UTF8;
                }
                else if (bom[0] == 0xff && bom[1] == 0xfe)
                {
                    return Encoding.Unicode;
                }
                else if (bom[0] == 0xfe && bom[1] == 0xff)
                {
                    return Encoding.BigEndianUnicode;
                }
                else if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0)
                {
                    return Encoding.UTF32;
                }
                else
                {
                    return Encoding.GetEncoding("GBK");
                }
            }
            return Encoding.GetEncoding("GBK");
        }
    }
}
