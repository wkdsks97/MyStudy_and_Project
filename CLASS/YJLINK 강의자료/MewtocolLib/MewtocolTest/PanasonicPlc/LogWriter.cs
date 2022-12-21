using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace PanasonicPlc
{
    public class LogWriter
    {
        //private static LogWriter m_logWriter = new LogWriter();
        //private LogWriter() { }
        //public static LogWriter getInstance() { return m_logWriter; }

        static private string[] m_aMsg = new string[256];
        static private byte m_pushIndex = 0;
        static private byte m_popIndex = 0;

        static private object m_lockKey = new object();


        static string m_logFileName = "Incident\\OperationMessage.txt";
        const uint LOG_FILE_SIZE = 8388608;	// 파일 크기 제한 - 8MByte 
        const uint INCIDENT_FILE_KEEP_DAY = 90;

        //delegate void OnMessage(string msg);

        static Thread m_runThread;

        static public void SetPath(string folder)
        {
            if (Directory.Exists(folder) == false)
            {
                Directory.CreateDirectory(folder);
            }

            m_logFileName = System.IO.Path.Combine(folder, "OperationMessage.txt");

            m_runThread = new Thread(FileWrte);
            m_runThread.IsBackground = true;
            m_runThread.Start();
        }

        //System.Object lockFile = new System.Object();

        private delegate void MessageCallback(string msg);
        //static private BaseForm m_baseForm;
        static MessageCallback ShowMsg;

        //static public void SetMessageForm(BaseForm baseForm)
        //{
        //    m_baseForm = baseForm;
        //    ShowMsg = new MessageCallback(m_baseForm.ShowListBoxMsg);
        //}


        static public void WriteLogMessage(string className, string msg)
        {
            lock (m_lockKey)
            {
                string logMsg = String.Format("{0}  {1, -20} {2, -50}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "[" + className + "]", msg);
                m_aMsg[m_pushIndex] = logMsg;
                m_pushIndex++;
            }
        }

        static private void FileWrte()
        {
            while (true)
            {
                if (m_popIndex != m_pushIndex)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(m_logFileName, true))
                        {
                            do
                            {
                                string logMsg = m_aMsg[m_popIndex];
                                m_popIndex++;
                                Debug.WriteLine(logMsg);
                                sw.WriteLine(logMsg);

                                //if (null != m_baseForm)
                                //    m_baseForm.BeginInvoke(ShowMsg, logMsg);

                                Thread.Sleep(10);
                            } while (m_popIndex != m_pushIndex);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    FileInfo fileInfo = new FileInfo(m_logFileName);
                    if (LOG_FILE_SIZE < fileInfo.Length)
                    {
                        try
                        {
                            string sDate = String.Format("{0:D4}-{1:D2}-{2:D2}[{3:D2}-{4:D2}-{5:D2}]",
                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            string path = String.Format("{0}\\{1}{2}", fileInfo.DirectoryName, sDate, fileInfo.Extension);
                            fileInfo.CopyTo(path);
                            fileInfo.Delete();

                            //장비를 안끄고 연속적으로 사용하는 경우가 있어서
                            //파일 8MB시마다 오래된 파일을 제거 하도록 수정 
                            DeleteOldFile(fileInfo.DirectoryName, INCIDENT_FILE_KEEP_DAY, "-[]");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }




        /// <summary>
        /// HJ 오래된 파일 삭제용, 찾은 파일이 KeepDay보다 오래됬으면 삭제
        /// </summary>
        /// <param name="directory">Incident파일 경로, 폴더까지만 작성</param>
        /// <param name="KeepDay"> 일단위 보관기간</param>
        /// <param name="filter"> 찾고자 하는 파일, 해당 문자들이 포함된 파일만 검색</param>
        static public void DeleteOldFile(string directory, long KeepDay, string filter = "")
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            foreach(FileInfo file in directoryInfo.GetFiles())
            {
                if (false == FineOneOf(file.Name, filter)) continue;

                long passDay = (DateTime.Today.Year * 365 + DateTime.Today.DayOfYear)
                    - (file.CreationTime.Year * 365 + file.CreationTime.DayOfYear);

                if(KeepDay < passDay)
                {
                    file.Delete();
                }
            }
        }
        /// <summary>
        /// FindChar의 문자들을 한개씩 짤라서 있는지 검사,
        /// 원하는 문자들이 전부 있으면 TRUE, 하나라도 없으면 FALSE
        /// </summary>
        /// <param name="str">검색될 문자열</param>
        /// <param name="FindChars"></param>
        /// <returns></returns>
        static private bool FineOneOf(string str,string FindChars)
        {
            if ("" == FindChars) return true;

            foreach (char c in FindChars.ToArray())
            {
                if (-1 == str.IndexOf(c))
                    return false;
            }

            return true;
        }
    }
}
