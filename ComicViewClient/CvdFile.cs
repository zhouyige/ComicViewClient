using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace ComicViewClient
{
    public struct CVD //占用空间99bit
    {
        //string version;//最大10个字节
        public uint AnimationNum; //弹出顺序编号     
        public string Picturefilename; //图片文件名索引 最大50字节
        public int PictureCutX; //图片剪切X坐标
        public int PictureCutY; //图片剪切Y坐标
        public int PictureCutWidth; //图片剪切宽度
        public int PictureCutHeight; //图片剪切高度
        public int X; //图片显示X坐标
        public int Y; //图片显示Y坐标
        public int Width; //图片显示宽度
        public int Height; //图片显示高度
        public int StopTime; //图片显示驻留时间
        public uint PopInStyle; //图片弹入方式
        //public int PopInSpeed; //图片弹入速度
        //public int PopInAmpli;  //图片移动幅度
        public uint PopOutStyle; //图片弹出方式
        public bool EndFlag; //卷结束标志
    }

    internal class CvdFile
    {
        private string Version = "CVD1.00000";
        public uint _pagenum = 0;
        //public CVD MyCvdFile;
        private string _filePath;
        public bool CreateFile(string filepath)
        {
            try
            {
                if (!(filepath.Contains(".cvd") || filepath.Contains(".CVD")))
                {
                    filepath += ".cvd";
                }
                _filePath = filepath;
                var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write);//出现文件夹拒绝访问问题
                var versionbuf = new byte[11];
                versionbuf = System.Text.Encoding.Default.GetBytes(Version);
                fs.Write(versionbuf, 0, versionbuf.Length);
                //fs.Write(System.BitConverter.GetBytes(_pagenum), 0, sizeof(uint));
                fs.Close();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        private byte[] memset(byte[] bytebuf, byte value)
        {
            for (int i = 0; i < bytebuf.Length; i++)
            {
                bytebuf[i] = value;
            }
            return bytebuf;
        }

        public bool Add(CVD cvd)
        {
            if (_filePath == null)
            {
                return false;
            }
            //读取文件确定如何添加数据
            var fread = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            var versionbuf = new byte[11];
            fread.Read(versionbuf, 0, 10);
            string versionstr = System.Text.Encoding.Default.GetString(versionbuf);
            
            if (versionstr != "CVD1.00000\0")
            {
                return false;
            }
            byte[] cvdbuf = new byte[100];
            fread.Read(cvdbuf, 0, 99);
            fread.Close();

            uint uibuf = System.BitConverter.ToUInt32(cvdbuf, 0);
            //如果还未添加帧
            if (uibuf == 0)
            {
                cvd.EndFlag = true;
                var fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write);
                fs.Write(System.BitConverter.GetBytes(cvd.AnimationNum), 0, sizeof(uint));
                //写入图片文件名保持占用50字节
                byte[] picturefilenamebuf = new byte[50];
                memset(picturefilenamebuf, 0);
                string str = cvd.Picturefilename;
                int i;
                for (i = 0; i < str.Length; i++)
                {
                    picturefilenamebuf[i] = (byte)str[i];
                }
                fs.Write(picturefilenamebuf, 0, 50);
                fs.Write(System.BitConverter.GetBytes(cvd.PictureCutX), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.PictureCutY), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.PictureCutWidth), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.PictureCutHeight), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.X), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.Y), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.Width), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.Height), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.StopTime), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.PopInStyle), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.PopOutStyle), 0, sizeof(uint));
                fs.Write(System.BitConverter.GetBytes(cvd.EndFlag), 0, sizeof(bool));
                fs.Close();
            }
            else//如果是在其它帧后面添加帧
            {
                List<CVD> cvdlistbuf = new List<CVD>();
                CVD cvdaddtolistbuf = new CVD();
                var fread1 = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                var versionbuf1 = new byte[11];
                fread1.Read(versionbuf1, 0, 10);
                string versionstr1 = System.Text.Encoding.Default.GetString(versionbuf1);

                if (versionstr1 != "CVD1.00000\0")
                {
                    return false;
                }
                System.Console.WriteLine("{0}", fread1.Position); 
                byte[] cvdbuf1 = new byte[100];
                fread1.Read(cvdbuf1, 0, 99);
                cvdaddtolistbuf.AnimationNum = System.BitConverter.ToUInt32(cvdbuf1, 0);
                cvdaddtolistbuf.Picturefilename = System.Text.Encoding.Default.GetString(cvdbuf1, 4, 50);
                cvdaddtolistbuf.PictureCutX = System.BitConverter.ToInt32(cvdbuf1, 54);
                cvdaddtolistbuf.PictureCutY = System.BitConverter.ToInt32(cvdbuf1, 58);
                cvdaddtolistbuf.PictureCutWidth = System.BitConverter.ToInt32(cvdbuf1, 62);
                cvdaddtolistbuf.PictureCutHeight = System.BitConverter.ToInt32(cvdbuf1, 66);
                cvdaddtolistbuf.X = System.BitConverter.ToInt32(cvdbuf1, 70);
                cvdaddtolistbuf.Y = System.BitConverter.ToInt32(cvdbuf1, 74);
                cvdaddtolistbuf.Width = System.BitConverter.ToInt32(cvdbuf1, 78);
                cvdaddtolistbuf.Height = System.BitConverter.ToInt32(cvdbuf1, 82);
                cvdaddtolistbuf.StopTime = System.BitConverter.ToInt32(cvdbuf1, 86);
                cvdaddtolistbuf.PopInStyle = System.BitConverter.ToUInt32(cvdbuf1, 90);
                cvdaddtolistbuf.PopOutStyle = System.BitConverter.ToUInt32(cvdbuf1, 94);
                cvdaddtolistbuf.EndFlag = System.BitConverter.ToBoolean(cvdbuf1, 98);
                cvdlistbuf.Add(cvdaddtolistbuf);
                while (cvdaddtolistbuf.EndFlag == false)
                {
                    fread1.Read(cvdbuf1, 0, 99);
                    cvdaddtolistbuf.AnimationNum = System.BitConverter.ToUInt32(cvdbuf1, 0);
                    cvdaddtolistbuf.Picturefilename = System.Text.Encoding.Default.GetString(cvdbuf1, 4, 50);
                    cvdaddtolistbuf.PictureCutX = System.BitConverter.ToInt32(cvdbuf1, 54);
                    cvdaddtolistbuf.PictureCutY = System.BitConverter.ToInt32(cvdbuf1, 58);
                    cvdaddtolistbuf.PictureCutWidth = System.BitConverter.ToInt32(cvdbuf1, 62);
                    cvdaddtolistbuf.PictureCutHeight = System.BitConverter.ToInt32(cvdbuf1, 66);
                    cvdaddtolistbuf.X = System.BitConverter.ToInt32(cvdbuf1, 70);
                    cvdaddtolistbuf.Y = System.BitConverter.ToInt32(cvdbuf1, 74);
                    cvdaddtolistbuf.Width = System.BitConverter.ToInt32(cvdbuf1, 78);
                    cvdaddtolistbuf.Height = System.BitConverter.ToInt32(cvdbuf1, 82);
                    cvdaddtolistbuf.StopTime = System.BitConverter.ToInt32(cvdbuf1, 86);
                    cvdaddtolistbuf.PopInStyle = System.BitConverter.ToUInt32(cvdbuf1, 90);
                    cvdaddtolistbuf.PopOutStyle = System.BitConverter.ToUInt32(cvdbuf1, 94);
                    cvdaddtolistbuf.EndFlag = System.BitConverter.ToBoolean(cvdbuf1, 98);
                    cvdlistbuf.Add(cvdaddtolistbuf);
                }
                cvdaddtolistbuf = cvdlistbuf[cvdlistbuf.Count - 1];
                cvdaddtolistbuf.EndFlag = false;
                cvdlistbuf[cvdlistbuf.Count - 1] = cvdaddtolistbuf;
                cvd.EndFlag = true;
                cvdlistbuf.Add(cvd);
                fread1.Close();

                //开始进行将list写入操作
                var fwrite = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite);//open操作可能有问题
                var _versionbuf = new byte[11];
                _versionbuf = System.Text.Encoding.Default.GetBytes(Version);
                fwrite.Write(_versionbuf, 0, _versionbuf.Length);
                for (int listNum = 0; listNum < cvdlistbuf.Count; listNum++)
                {
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].AnimationNum), 0, sizeof(uint));
                    //写入图片文件名保持占用50字节
                    byte[] picturefilenamebuf = new byte[50];
                    memset(picturefilenamebuf, 0);
                    string str = cvdlistbuf[listNum].Picturefilename;
                    for (int strNum = 0; strNum < str.Length; strNum++)
                    {
                        picturefilenamebuf[strNum] = (byte)str[strNum];
                    }
                    fwrite.Write(picturefilenamebuf, 0, 50);
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PictureCutX), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PictureCutY), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PictureCutWidth), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PictureCutHeight), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].X), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].Y), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].Width), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].Height), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].StopTime), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PopInStyle), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].PopOutStyle), 0, sizeof(uint));
                    fwrite.Write(System.BitConverter.GetBytes(cvdlistbuf[listNum].EndFlag), 0, sizeof(bool));
                }
                fwrite.Close();
            }

            
            return true;
        }

        public bool Read(string filepath, List<CVD> cvdlist)
        {
            if (filepath == null)
            {
                return false;
            }     
            try
            {
                CVD cvdaddtolistbuf = new CVD();
                var fread = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                var versionbuf = new byte[11];
                fread.Read(versionbuf, 0, 10);
                string versionstr = System.Text.Encoding.Default.GetString(versionbuf);

                if (versionstr != "CVD1.00000\0")
                {
                    return false;
                }
                byte[] cvdbuf1 = new byte[100];
                fread.Read(cvdbuf1, 0, 99);
                cvdaddtolistbuf.AnimationNum = System.BitConverter.ToUInt32(cvdbuf1, 0);
                cvdaddtolistbuf.Picturefilename = System.Text.Encoding.Default.GetString(cvdbuf1, 4, 50);
                cvdaddtolistbuf.PictureCutX = System.BitConverter.ToInt32(cvdbuf1, 54);
                cvdaddtolistbuf.PictureCutY = System.BitConverter.ToInt32(cvdbuf1, 58);
                cvdaddtolistbuf.PictureCutWidth = System.BitConverter.ToInt32(cvdbuf1, 62);
                cvdaddtolistbuf.PictureCutHeight = System.BitConverter.ToInt32(cvdbuf1, 66);
                cvdaddtolistbuf.X = System.BitConverter.ToInt32(cvdbuf1, 70);
                cvdaddtolistbuf.Y = System.BitConverter.ToInt32(cvdbuf1, 74);
                cvdaddtolistbuf.Width = System.BitConverter.ToInt32(cvdbuf1, 78);
                cvdaddtolistbuf.Height = System.BitConverter.ToInt32(cvdbuf1, 82);
                cvdaddtolistbuf.StopTime = System.BitConverter.ToInt32(cvdbuf1, 86);
                cvdaddtolistbuf.PopInStyle = System.BitConverter.ToUInt32(cvdbuf1, 90);
                cvdaddtolistbuf.PopOutStyle = System.BitConverter.ToUInt32(cvdbuf1, 94);
                cvdaddtolistbuf.EndFlag = System.BitConverter.ToBoolean(cvdbuf1, 98);
                cvdlist.Add(cvdaddtolistbuf);
                while (cvdaddtolistbuf.EndFlag == false)
                {
                    fread.Read(cvdbuf1, 0, 99);
                    cvdaddtolistbuf.AnimationNum = System.BitConverter.ToUInt32(cvdbuf1, 0);
                    cvdaddtolistbuf.Picturefilename = System.Text.Encoding.Default.GetString(cvdbuf1, 4, 50);
                    cvdaddtolistbuf.PictureCutX = System.BitConverter.ToInt32(cvdbuf1, 54);
                    cvdaddtolistbuf.PictureCutY = System.BitConverter.ToInt32(cvdbuf1, 58);
                    cvdaddtolistbuf.PictureCutWidth = System.BitConverter.ToInt32(cvdbuf1, 62);
                    cvdaddtolistbuf.PictureCutHeight = System.BitConverter.ToInt32(cvdbuf1, 66);
                    cvdaddtolistbuf.X = System.BitConverter.ToInt32(cvdbuf1, 70);
                    cvdaddtolistbuf.Y = System.BitConverter.ToInt32(cvdbuf1, 74);
                    cvdaddtolistbuf.Width = System.BitConverter.ToInt32(cvdbuf1, 78);
                    cvdaddtolistbuf.Height = System.BitConverter.ToInt32(cvdbuf1, 82);
                    cvdaddtolistbuf.StopTime = System.BitConverter.ToInt32(cvdbuf1, 86);
                    cvdaddtolistbuf.PopInStyle = System.BitConverter.ToUInt32(cvdbuf1, 90);
                    cvdaddtolistbuf.PopOutStyle = System.BitConverter.ToUInt32(cvdbuf1, 94);
                    cvdaddtolistbuf.EndFlag = System.BitConverter.ToBoolean(cvdbuf1, 98);
                    cvdlist.Add(cvdaddtolistbuf);
                }
                fread.Close();
                    


            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
