using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using HelloData.FWCommon;
using HelloData.FWCommon.Serialize;
using HelloData.Web;

namespace SMSServer.Web.Master
{
    /// <summary>
    /// AjaxFile 的摘要说明
    /// </summary>
    public class AjaxFile : IHttpHandler
    {
        const int ChunkSize = 1024 * 1024 * 50;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile qqfile = context.Request.Files["qqfile"];
            string path = context.Request.PhysicalApplicationPath;
            string uploadPath = "";
            using (var stream = qqfile.InputStream)
            {
                using (var br = new BinaryReader(stream))
                {
                    uploadPath = WriteStream(br, qqfile.FileName, path);
                }
            }
            bool isheader =  context.Request.Params["header"] == "1" ;
            string spilter = context.Request.Params["spilter"];
           string  fulluploadPath = Path.Combine(Path.Combine(path, "uplpod"), uploadPath);
            string extension = Path.GetExtension(qqfile.FileName).ToLower();
            string[] arr = new string[2];
            arr[1] = string.Empty;
            arr[0] = string.Empty;
            switch (extension)
            {
                case ".txt":
                    {
                        Encoding encoding = FileUtily.DetectEncoding(fulluploadPath);

                        StreamReader sr = new StreamReader(fulluploadPath, encoding);
                        String line;
                        int readindex = 0;

                        while ((line = sr.ReadLine()) != null)
                        {
                            char spter = Convert.ToChar(spilter);
                            //arr[readindex] = line.Trim();
                            string[] array = line.Trim().Split(spter);
                            if (isheader && readindex == 0)
                            {
                                for (int i = 0; i < array.Length; i++)
                                {

                                    if (i == 0)
                                        arr[0] = array[i] + "";
                                    else
                                    {
                                        arr[0] += "," + array[i];
                                    }
                                }
                            }
                            else if (isheader && readindex == 1)
                            {
                                for (int i = 0; i < array.Length; i++)
                                {

                                    if (i == 0)
                                        arr[1] = array[i] + "";
                                    else
                                    {
                                        arr[1] += "," + array[i];
                                    }
                                }
                            }
                            else if (!isheader)
                            {
                                for (int i = 0; i < array.Length; i++)
                                {

                                    if (i == 0)
                                    { arr[0] = "column" + i; arr[1] = array[i] + ""; }
                                    else
                                    {
                                        arr[1] += "," + array[i];
                                        arr[0] += "," + "column" + i;
                                    }
                                }
                            }
                            if (readindex == 1)
                                break;
                            readindex++;
                        }
                    }
                    break;
                case ".xls":
                    {
                        DataTable dt = FileUtily.ReadDataTable(fulluploadPath, 0, "");
                        if (dt.Rows.Count > 0)
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j == 0)
                                    arr[0] = dt.Rows[0][j] + "";
                                else
                                {
                                    arr[0] += "," + dt.Rows[0][j];
                                }
                            }
                        if (dt.Rows.Count > 1)
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j == 0)
                                    arr[1] = dt.Rows[1][j] + "";
                                else
                                {
                                    arr[1] += "," + dt.Rows[1][j];
                                }
                            }
                    }
                    break;
            }
            context.Response.Write(JsonHelper.SerializeObject(new { success = true, message = arr, filename = uploadPath }));
        }

        private string WriteStream(BinaryReader br, string fileName, string path)
        {
            byte[] fileContents = new byte[] { };
            var buffer = new byte[br.BaseStream.Length];

            while (br.BaseStream.Position < br.BaseStream.Length - 1)
            {
                int count = int.Parse(br.BaseStream.Length.ToString());
                if (br.Read(buffer, 0, count) > 0)
                {
                    fileContents = fileContents.Concat(buffer).ToArray();
                }
            }
            string uploadFile = DateTime.Now.ToString("yyyyMMddHHmmSS") +
                                Path.GetExtension(fileName).ToLower();
            using (var fs = new FileStream(Path.Combine(Path.Combine(path, "uplpod"), uploadFile), FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(fileContents);
                }
            }
            return uploadFile;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}