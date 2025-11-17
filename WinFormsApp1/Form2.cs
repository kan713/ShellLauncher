using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        // ここを追加：Form1 でアクセスするためのプロパティ
        public string[] UserInfo { get; private set; }

        public Form2()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 特に初期化処理がなければ空のままでOK
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            // 空チェック
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "ユーザー名とパスワードを入力してください。",
                    "警告",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Administrator / Guest の禁止
            if (username.Equals("Administrator", StringComparison.OrdinalIgnoreCase) ||
                username.Equals("Guest", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "このユーザーは選択できません。\nその他のユーザーを選択してください。",
                    "ユーザー選択ポリシー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 存在確認
            try
            {
                var user = new System.Security.Principal.NTAccount(username);
                var sid = (System.Security.Principal.SecurityIdentifier)user.Translate(
                    typeof(System.Security.Principal.SecurityIdentifier));
                // Translate() が成功すれば存在している
            }
            catch
            {
                MessageBox.Show(
                    "指定されたユーザーは存在しません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // OK → Form1 に返す
            this.UserInfo = new string[] { username, password }; // ユーザー情報セット
            this.Tag = 1; // 数値 1 をセット
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cancel → Form1 に 2 を送る
            this.Tag = 2; // 数値 2 をセット
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
