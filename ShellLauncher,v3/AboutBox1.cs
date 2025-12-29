using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();

        }

        #region アセンブリ属性アクセサー

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelCompanyName_Click(object sender, EventArgs e)
        {

        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            string edition = "不明なエディション";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        edition = key.GetValue("ProductName")?.ToString() ?? "エディション情報なし";
                    }
                }
            }
            catch
            {
                edition = "エディション情報の取得に失敗";
            }

            // 取得したエディションをラベルに追記
            labelCompanyName.Text = "OS情報: " + edition;
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show(
                    "ログオフしますか？？",  // ダイアログのメッセージ
                    "ログオフ",               // ダイアログのタイトル
                    MessageBoxButtons.YesNo,  // 「はい」と「いいえ」のボタンを表示
                    MessageBoxIcon.Warning   // 質問アイコンを表示
                );

                // OK（Yes）が押された場合に再起動を実行
                if (result == DialogResult.Yes)
                {
                    Process.Start("logoff.exe");
                    // 説明:
                    // "/r" : 再起動を実行
                    // "/f" : 実行中のアプリケーションを強制終了
                    // "/t 0" : 再起動までの待ち時間を0秒に設定
                }
                else
                {
                    // キャンセル（いいえ）が押された場合は何もしない
                    MessageBox.Show("キャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
