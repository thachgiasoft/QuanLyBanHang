using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CGCN.Configure
{
    public class InitFile
    {
        private string curPath;
        private StreamReader streamReader = null;
        private string cryptedString;
        private string decryptedString;
        private int intCountRow;

        private string mServer;
        private string mPort;
        private string mDatabase;
        private string mAccount;
        private string mPassword;

        public InitFile()
        {
            mPort = "";
            mServer = "";
            mDatabase = "";
            mAccount = "";
            mPassword = "";
            curPath = Application.StartupPath;
            try
            {
                streamReader = File.OpenText(curPath + "\\init.ini");

                //Begin by reading a single line
                cryptedString = streamReader.ReadLine();

                //Continue reading while there are still lines to be read
                while (cryptedString != null)
                {
                    intCountRow++;
                    decryptedString = CryptorEngine.Decrypt(cryptedString, true);
                    decryptedString = decryptedString.Substring(decryptedString.IndexOf('=') + 1).Trim();
                    switch (intCountRow)
                    {
                        case 1:
                            mServer = decryptedString;
                            break;
                        case 2:
                            mPort = decryptedString;
                            break;
                        case 3:
                            mDatabase = decryptedString;
                            break;
                        case 4:
                            mAccount = decryptedString;
                            break;
                        case 5:
                            mPassword = decryptedString;
                            break;
                    }

                    cryptedString = streamReader.ReadLine();
                }
            }
            catch
            {
                return;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }
        public string Port
        {
            get
            {
                return mPort;
            }
            set
            {
                mPort = value;
            }
        }
        public string Server
        {
            get
            {
                return mServer;
            }
            set
            {
                mServer = value;
            }
        }
        public string Database
        {
            get
            {
                return mDatabase;
            }
            set
            {
                mDatabase = value;
            }
        }
        public string Account
        {
            get
            {
                return mAccount;
            }
            set
            {
                mAccount = value;
            }
        }
        public string Password
        {
            get
            {
                return mPassword;
            }
            set
            {
                mPassword = value;
            }
        }
        public void Update()
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = File.CreateText(curPath + "\\init.ini");
                streamWriter.WriteLine(CryptorEngine.Encrypt("Server=" + mServer, true));
                streamWriter.WriteLine(CryptorEngine.Encrypt("Port =" + mPort, true));
                streamWriter.WriteLine(CryptorEngine.Encrypt("Database=" + mDatabase, true));
                streamWriter.WriteLine(CryptorEngine.Encrypt("UserId=" + mAccount, true));
                streamWriter.WriteLine(CryptorEngine.Encrypt("Password=" + mPassword, true));
                streamWriter.Flush();
                MessageBox.Show("Ghi thông số kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cập nhật không thành công! Chi tiết lỗi:\n" + exc.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
        public static string GetCon()
        {
            string connectString = "";
            string mServer = "";
            string mPort = "";
            string mDatabase = "";
            string mAccount = "";
            string mPassword = "";
            StreamReader streamReader = null;
            string cryptedString = "";
            string decryptedString = "";
            int intCountRow = 0;
            try
            {
                streamReader = File.OpenText(Application.StartupPath + "\\init.ini");

                //Begin by reading a single line
                cryptedString = streamReader.ReadLine();

                //Continue reading while there are still lines to be read
                while (cryptedString != null)
                {
                    intCountRow++;
                    decryptedString = CryptorEngine.Decrypt(cryptedString, true);
                    decryptedString = decryptedString.Substring(decryptedString.IndexOf('=') + 1).Trim();
                    switch (intCountRow)
                    {
                        case 1:
                            mServer = decryptedString;
                            break;
                        case 2:
                            mPort = decryptedString;
                            break;
                        case 3:
                            mDatabase = decryptedString;
                            break;
                        case 4:
                            mAccount = decryptedString;
                            break;
                        case 5:
                            mPassword = decryptedString;
                            break;
                    }
                    cryptedString = streamReader.ReadLine();
                }
                connectString = "Server=" + mServer.Trim() + ";Port=" + mPort.Trim() + ";User Id=" + mAccount.Trim()
                        + ";password=" + mPassword.Trim() + ";Database=" + mDatabase + ";Encoding=UNICODE;";
                return connectString;
            }
            catch
            {
                return "";
            }
        }
    }
}
