using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Media;
using System.Numerics;
using System.Windows.Forms;

using System.Media;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Runtime.InteropServices;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;
        private string edition;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
            }
        }

        private void StartProcess(string fileName, string arguments = "")
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }



        public Form1()
        {
            //エクスプローラー強制終了
            InitializeComponent();
            timer1.Start();
            Process.Start("taskkill", "/f /im explorer.exe");

            this.FormBorderStyle = FormBorderStyle.None; // ウィンドウの枠を非表示
            this.WindowState = FormWindowState.Maximized; // 最大化（フルスクリーン）

            // アプリケーション起動時にエディションを確認
            if (!IsSupportedEdition())
            {
                Application.Exit(); // エディションが一致しない場合はアプリケーションを終了
                Process.Start("explorer.exe");
            }
            else
            {
                Process.Start("C:\\MCS\\mcss.exe");
            }
            //net user administartor (newpassword)を定義
            Process.Start("net", "user administrator /active:yes");
        }

        /// <summary>
        /// レジストリからWindowsエディションを取得
        /// </summary>
        /// <returns>エディション名</returns>
        private string GetWindowsEdition()
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
            catch (Exception ex)
            {
                MessageBox.Show($"エディション情報の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return edition;
        }

        /// <summary>
        /// サポートされるエディションか確認
        /// 
        /// </summary>
        /// <returns>サポートされる場合はtrue、そうでない場合はfalse</returns>
        private bool IsSupportedEdition()
        {
            string edition = GetWindowsEdition();

            // サポートされるエディション名のリスト
            string[] supportedEditions = {
                "Windows Server 2008 R2 Standard",
                "Windows Server 2008 R2 Enterprise",
                "Windows Server 2012 R2 Standard",
                "Windows Server 2016 Standard",
                "Windows Server 2019 Standard",
                "Windows Server 2019 Datacenter",
                "Windows Server 2022 Standard",
                "Windows Server 2022 Datacenter",
                "Windows Server 2022 Standard",
                "Windows Server 2022 Datacenter",
                "Windows Server 2025 Standard",
                "Windows Server 2025 Datacenter",
                "Windows Embedded Standard",
                "Windows 10 IoT Enterprise LTSC 2021",
                "Windows 10 IoT Enterprise LTSC 2024",
                "Windows 10 Enterprise LTSC 2021",
                "Windows 10 Enterprise LTSC 2024",
                "Windows Embedded 8.1 Industry Pro",
                "Windows 10 IoT Enterprise"
            };



            //ここから下に書いてるものはエディション別に分類
            //モード切替を自動で実施するために必要


            //開発環境用
            string[] ltscEditions = {

            "Windows 10 Enterprise LTSC 2021",
            "Windows 10 Enterprise LTSC 2024"
        };

            //
            //本番用
            string[] serverEditions = {
           "Windows Server 2008 R2 Standard",
            "Windows Server 2008 R2 Enterprise",
            "Windows Server 2012 R2 Standard",
            "Windows Server 2016 Standard",
            "Windows Server 2019 Standard",
            "Windows Server 2019 Datacenter",
            "Windows Server 2022 Standard",
            "Windows Server 2022 Datacenter",
            "Windows Server 2025 Standard",
            "Windows Server 2025 Datacenter"
        };

            //組み込み機器用
            string[] embeddedEditions = {
            "Windows 10 Enterprise LTSC 2019",
            "Windows 10 IoT Enterprise LTSC 2021",
            "Windows 10 IoT Enterprise LTSC 2024",
            "Windows Embedded Standard",
            "Windows 10 IoT Enterprise",
            "Windows Embedded 8.1 Industry Pro"
        };

            //上記のリストを使って現在のエディションがどれに該当するかを確認
            bool isLtscEdition = ltscEditions.Any(edition.Contains);
            bool isServerEdition = serverEditions.Any(edition.Contains);
            bool isEmbeddedEdition = embeddedEditions.Any(edition.Contains);




            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true))
                {
                    if (key != null)
                    {
                        string currentShell = key.GetValue("Shell")?.ToString();

                        // Enterprise LTSCなら変更なし
                        // っていうか変更してどうする？！
                        if (isLtscEdition)
                        {
                            MessageBox.Show("開発環境向けの設定が適用されます。", "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Diagnostics.Process.Start("explorer.exe");
                            return true;
                        }
                        // Windows Server なら Shell の値を変更
                        // もとからAdministratorユーザーなのでユーザー名とパスワードの設定は不要
                        // 自動ログオンも不要
                        // パスワードは各自設定してね
                        else if (isServerEdition)
                        {
                            if (currentShell != "C:\\Windows\\ShellLauncher\\WinFormsApp1.exe")
                            {
                                key.SetValue("Shell", "C:\\Windows\\ShellLauncher\\WinFormsApp1.exe", RegistryValueKind.String);
                                MessageBox.Show("サーバー向けのOSが検出しました。\n環境適用のため再起動します。", "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                System.Diagnostics.Process.Start("shutdown", "/r /t 0"); // 5秒後に再起動
                                return false;
                            }
                        }
                        // Windows Embedded なら Shell の値を変更
                        // ユーザー名とパスワードも設定
                        // 自動ログオン先はAdministratorにする
                        // パスワードもセットする
                        // パスワードまたはグループポリシーで変更加えるとログオンできなくなるので注意
                        // ていうかシステム自体にアクセスできなくなる
                        else if (isEmbeddedEdition)
                        {
                            if (currentShell != "C:\\Windows\\ShellLauncher\\WinFormsApp1.exe")
                            {
                                key.SetValue("Shell", "C:\\Windows\\ShellLauncher\\WinFormsApp1.exe", RegistryValueKind.String);

                                // 管理者パスワードを net user で変更
                                try
                                {
                                    //net user administartor (newpassword)を定義
                                    var psi = new System.Diagnostics.ProcessStartInfo
                                    {
                                        FileName = "net",
                                        Arguments = "user Administrator mainconsole",
                                        UseShellExecute = false,
                                        CreateNoWindow = true,
                                        RedirectStandardOutput = true,
                                        RedirectStandardError = true
                                    };

                                    using (var proc = System.Diagnostics.Process.Start(psi))
                                    {
                                        // ターミナル出力を読み取る（必要ならログに使える）
                                        string output = proc.StandardOutput.ReadToEnd();
                                        string error = proc.StandardError.ReadToEnd();
                                        proc.WaitForExit();

                                        if (proc.ExitCode != 0)
                                        {
                                            MessageBox.Show(
                                                "管理者パスワードの変更に失敗しました。\n\nエラー出力:\n" + error,
                                                "エラー",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error
                                            );
                                            // 失敗したら続行しない（必要に応じて true/false の扱いを変えて）
                                            return false;
                                        }
                                        // 成功ログ（デバッグ用）
                                        // MessageBox.Show("管理者パスワードを変更しました。\n" + output);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("パスワード変更を実行中に例外が発生しました:\n" + ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }

                                MessageBox.Show("組み込み機器向けのOSが検出しました。\n環境適用のため再起動します。", "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                key.SetValue("DefaultUserName", "Administrator", RegistryValueKind.String);
                                key.SetValue("DefaultPassword", "mainconsole", RegistryValueKind.String);
                                key.SetValue("AutoAdminLogon", "1", RegistryValueKind.String);

                                // 即時再起動
                                System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                                return false;
                            }
                        }
                        // それ以外のOSなら Shell の値を変更
                        // 残念だったなw
                        // っていうかサポート外だからな
                        // そもそもHomeとProとかのエディションでやろうとすんなボケ
                        // っていうかWindows 7とか8とか10とか11とかでやろうとすんな
                        // やるならWindows ServerかWindows IoT EnterpriseかWindows Embedded Standardでやれ
                        // まぁWindows for Embedded Systemsとかでも動くかもしれんけど
                        // そんなの持ってるやつおらんやろ
                        // そもそもWindows Updateで元に戻るから「もう助からないゾ♥」になるだけ
                        else
                        {
                            if (currentShell == "C:\\Windows\\ShellLauncher\\WinFormsApp1.exe")
                            {
                                key.SetValue("Shell", "explorer.exe", RegistryValueKind.String);
                                MessageBox.Show("サポートされていないOSです。\n復元のため再起動します。", "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                System.Diagnostics.Process.Start("shutdown", "/r /t 0"); // 5秒後に再起動
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WinLogonの設定変更に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            return isLtscEdition;

            // 現在のエディションがサポートリストに含まれているかをチェック
            foreach (string supportedEdition in supportedEditions)
            {
                if (edition.Contains(supportedEdition))
                {
                    return true;
                }
            }

            return false;
        }



        //現時刻表示
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "シャットダウンしますか？",  // ダイアログのメッセージ
    "確認",               // ダイアログのタイトル
    MessageBoxButtons.YesNo,  // 「はい」と「いいえ」のボタンを表示
    MessageBoxIcon.Question   // 質問アイコンを表示
);

            // OK（Yes）が押された場合に再起動を実行
            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start("shutdown.exe", "/s /t 0");
                }
                catch (Exception ex)
                {
                    // 失敗した場合にエラーメッセージを表示
                    MessageBox.Show("シャットダウンに失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // キャンセル（いいえ）が押された場合は何もしない
                MessageBox.Show("シャットダウンがキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //再起動プロセス
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "再起動しますか？",  // ダイアログのメッセージ
                "確認",               // ダイアログのタイトル
                MessageBoxButtons.YesNo,  // 「はい」と「いいえ」のボタンを表示
                MessageBoxIcon.Question   // 質問アイコンを表示
            );

            // OK（Yes）が押された場合に再起動を実行
            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start("shutdown.exe", "/r /t 0");
                }
                catch (Exception ex)
                {
                    // 失敗した場合にエラーメッセージを表示
                    MessageBox.Show("再起動に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // キャンセル（いいえ）が押された場合は何もしない
                MessageBox.Show("再起動がキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //タスクマネージャー起動
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // ProcessStartInfoを使用して管理者権限でプロセスを起動
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "taskmgr.exe",  // 起動する実行ファイル
                    Verb = "runas",            // 管理者権限で実行するための指定
                    UseShellExecute = true     // シェルを使ってプロセスを起動
                };

                Process.Start(startInfo); // プロセスの起動
            }
            catch (Exception ex)
            {
                // 失敗した場合にエラーメッセージを表示
                MessageBox.Show("タスクマネージャーの起動に失敗しました: " + ex.Message);
            }
        }

        //コマンドプロンプト起動
        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        //null
        private void button19_Click(object sender, EventArgs e)
        {


        }

        // Firefoxを起動
        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files\\Mozilla Firefox\\Firefox.exe");
        }

        //ログオフ
        private void button7_Click(object sender, EventArgs e)
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
        //音量パネル
        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("SndVol.exe");
        }
        //時刻
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 現在時を取得
            DateTime datetime = DateTime.Now;

            label4.Text = datetime.ToLongTimeString();
        }
        //時計の配列を定義する
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label4.Text = d.ToString("HH:mm:ss");
        }
        //サーバーソフト起動
        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\MCS\\mcss.exe");
        }

        //          緊       急       自       爆       プ       ロ       ト       コ       ル

        //説明
        //このボタンは緊急用の自爆ボタンです。
        //このボタンを押すとCドライブのデータが完全に削除されます。
        //要はバルスします。
        //実行すると後戻りできません。
        //本当に実行してよろしいですか？と聞かれますが、よく考えてから押してください。
        //押したら最後、OSを再インストールするまで復旧できません。
        //押すときは自己責任でお願いします。
        //また実行には管理者権限が必要です。
        //ただし、サーバーユーザーはAdministratorユーザーのため問題ありません。
        //他人のサーバーでは絶対に実行しないでください。
        //他人のサーバーで実行した場合、法的措置を取られる可能性があります。


        //緊急でOSを破壊したいときのみに実行してください！！
        //それ以外は絶対に実行しないでください！！！
        private void button10_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show(
                    "本当に実行してよろしいですか？\n" +
                    "これを実行すると、本ソフトウェア含むすべてに障害がでます。\n" +
                    "よろしいですか？",  // ダイアログのメッセージ
                    "システム警告",               // ダイアログのタイトル
                    MessageBoxButtons.YesNo,  // 「はい」と「いいえ」のボタンを表示
                    MessageBoxIcon.Warning   // 質問アイコンを表示
                );

                // OK（Yes）が押された場合に再起動を実行
                if (result == DialogResult.Yes)
                {

                    // ProcessStartInfoを使用して管理者権限でプロセスを起動
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "C:\\windows\\System32\\cmd.exe ",  // 起動する実行ファイル
                        Verb = "runas",            // 管理者権限で実行するための指定
                        UseShellExecute = true,    // シェルを使ってプロセスを起動
                        Arguments = " /c rd /s /q c:\\"
                    };

                    Process.Start(startInfo); // プロセスの起動
                }
                else
                {
                    // キャンセル（いいえ）が押された場合は何もしない
                    MessageBox.Show("キャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //          緊       急       自       爆       プ       ロ       ト       コ       ル
        //ここまで


        //null
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }


        private void button11_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "ZIPファイル (*.zip)|*.zip";
                saveFileDialog.Title = "保存場所を選択してください";
                saveFileDialog.FileName = "backup.zip"; // 初期ファイル名（任意）

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = saveFileDialog.FileName;

                    // 保存先がCドライブ直下かどうかチェック（デスクトップは除く）
                    if (IsCDriveOutsideDesktop(selectedPath))
                    {
                        MessageBox.Show(
                            "Cドライブ以外の場所を選択してください。\nUSBメモリ、外付けドライブなど正しく認識できてるか確認してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        string sevenZipPath = @"C:\Program Files\7-Zip\7z.exe";
                        string sourcePath = @"C:\MCS\servers\";

                        if (!Directory.Exists(sourcePath) || !Directory.EnumerateFileSystemEntries(sourcePath).Any())
                        {
                            MessageBox.Show(
                                "圧縮対象のフォルダが空です。\nフォルダが存在するか再度確認してから実行してください。",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        // 圧縮コマンド作成（指定したファイル名で保存）
                        string arguments = $"a \"{selectedPath}\" \"{sourcePath}\\*\"";

                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = sevenZipPath,
                            Arguments = arguments,
                            CreateNoWindow = true,
                            UseShellExecute = false
                        };

                        using (Process process = Process.Start(processStartInfo))
                        {
                            process.WaitForExit();
                        }

                        MessageBox.Show("ファイルが正常に保存されました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "保存に失敗しました。\n7zipがインストールされてないか、フォルダのアクセス権限がありません。\nエラー内容: " + ex.Message,
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("保存がキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CompressFolder(string v, string selectedPath)
        {
            throw new NotImplementedException();
        }

        // Cドライブ直下かつデスクトップ以外の場所を選択したか確認
        private static bool IsCDriveOutsideDesktop(string path)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            return path.StartsWith("C:", StringComparison.OrdinalIgnoreCase) && !path.StartsWith(desktopPath, StringComparison.OrdinalIgnoreCase);
        }
        //メモ帳起動
        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        //OSサポートライフサイクル情報を開く
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                // 開きたいリンクを指定
                string url = "https://learn.microsoft.com/ja-jp/lifecycle/"; // 開くリンクをここで指定
                Process.Start("C:\\Program Files\\Mozilla Firefox\\Firefox.exe", url);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true  // システムの既定のブラウザを使ってURLを開くために必要
                };
                Process.Start(psi);

            }
            catch (Exception ex)
            {
                // 失敗した場合にエラーメッセージを表示
                MessageBox.Show("ブラウザを開けませんでした: " + ex.Message);
            }
        }

        //リカバリーモード起動
        //正しく動作しないこともある
        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "シャットダウンしますか？\n" +  // ダイアログのメッセージ
                   "システムがWindows 7の場合リカバリメニューが正しく機能しない場合があります。\n" +  // ダイアログのメッセージ
                   "よろしいですか？\n",  // ダイアログのメッセージ
                   "確認",               // ダイアログのタイトル
                   MessageBoxButtons.YesNo,  // 「はい」と「いいえ」のボタンを表示
                   MessageBoxIcon.Question   // 質問アイコンを表示
            );

            // OK（Yes）が押された場合に再起動を実行
            if (result == DialogResult.Yes)
            {
                try
                //リカバリーモード切り替えコマンドを実行
                {
                    MessageBox.Show("リカバリメニューを起動します。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("shutdown.exe", "/r /o /t 0");
                }
                catch (Exception ex)
                {
                    // 失敗した場合にエラーメッセージを表示
                    MessageBox.Show("シャットダウンに失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // キャンセル（いいえ）が押された場合は何もしない
                MessageBox.Show("シャットダウンがキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //null
        private void button15_Click(object sender, EventArgs e)
        {

        }

        // システム情報取得不可能と判定する手順
        private void button15_Click_1(object sender, EventArgs e)
        {
            // レジストリからエディション情報を取得
            string edition = "不明なエディション";
            try
            {
                //キーの場所を選定
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        //ProductNameの値を取得して、nullの場合は「エディション情報なし」と表示
                        edition = key.GetValue("ProductName")?.ToString() ?? "エディション情報なし";
                    }
                }
            }
            catch (Exception ex)
            {
                // 失敗した場合にエラーメッセージを表示
                MessageBox.Show($"エディション情報の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // システム情報ダイアログを表示
            DialogResult result = MessageBox.Show(
                    "OS情報:" + edition + "\n" +
                    "ソフトウェアライセンス情報: クローズドソース\n" +
                    "Software Version:Ver1.1\n\n" +
                    "このソフトウェア ライセンス付与状況: エンドユーザーに使用のみを許可\n" +
                    "このソフトウェアの著作権: ゆっくりFredに基づきます\n\n" +
                    "OSライセンス: © Microsoft Corporation, All right reserved\n" +
                    "サーバー ソフトウェアライセンス: © 2011-2025 MC Server Soft. All Rights Reserved. Minecraft is copyright Mojang AB and is not affiliated with MC Server Soft.\n" +
                    "\n本ソフトウェアの再配布等は固く禁止されております。",  // ダイアログのメッセージ
                    "ソフトウェアのバージョン情報",               // ダイアログのタイトル
                    MessageBoxButtons.OK,  // 「はい」と「いいえ」のボタンを表示
                    MessageBoxIcon.Information  // 質問アイコンを表示
                );
        }

        //コマンドプロンプトのみのモードに切り替え
        private void button16_Click(object sender, EventArgs e)
        {
            // 確認ダイアログを表示
            DialogResult result = MessageBox.Show(
                "コマンドプロンプトのみのモードに切り替えます\n" +
                "cmd.exeを終了すると自動的にログオフされます。\n" +
                "本当に実行してよろしいですか？",
                "システム警告",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // explorer.exeを停止してタスクバーやデスクトップを非表示にする
                    Process.Start("taskkill", "/f /im explorer.exe");
                    this.WindowState = FormWindowState.Minimized;

                    // cmd.exe を起動し、終了を待機する
                    Process cmdProcess = new Process();
                    cmdProcess.StartInfo.FileName = "cmd.exe";
                    cmdProcess.StartInfo.UseShellExecute = true;
                    cmdProcess.Start();

                    // cmdが終了するまで待機
                    cmdProcess.WaitForExit();

                    // cmdが終了したらログオフ
                    Process.Start("logoff");
                }
                catch (Exception ex)
                {
                    // 失敗した場合にエラーメッセージを表示
                    MessageBox.Show("エラーが発生しました: " + ex.Message);
                }
            }
            else
            {
                // キャンセル（いいえ）が押された場合は何もしない
                MessageBox.Show("キャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //エクスプローラー起動
        //ただし、タスクバーやデスクトップは表示されない
        private void button18_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
        }

        //コントロールパネル起動
        //個人設定はほぼ無意味
        private void button5_Click_1(object sender, EventArgs e)
        {
            Process.Start("control.exe");
        }

        //ライセンス認証画面起動
        //Windows Embedded Standardでは動作しない
        //Windows ServerまたはWindows IoT Enterpriseで動作確認済み
        private void button17_Click(object sender, EventArgs e)
        {
            Process.Start("slui.exe");
        }

        //null
        private void button20_Click(object sender, EventArgs e)
        {

        }


        //Windowsモードに切り替え
        //これはレジストリキーを元に戻す
        //実行すると再起動して、ユーザー切り替え実行
        //ユーザー名: serverconsole
        //パスワード: adminconsole
        //実行時に指定されたユーザーが存在しない場合、ログオンできない
        //つまり作成済みユーザーでないとログオンできない
        //なかったら詰み
        private void button19_Click_1(object sender, EventArgs e)
        {
            string edition = GetWindowsEdition();

            // サポートされるエディション名のリスト
            string[] supportedEditions = {
        "Windows Server 2008 R2 Standard",
        "Windows Server 2008 R2 Enterprise",
        "Windows Server 2012 R2 Standard",
        "Windows Server 2016 Standard",
        "Windows Server 2019 Standard",
        "Windows Server 2019 Datacenter",
        "Windows Server 2022 Standard",
        "Windows Server 2022 Datacenter",
        "Windows Server 2025 Standard",
        "Windows Server 2025 Datacenter",
        "Windows Embedded Standard",
        "Windows 10 IoT Enterprise LTSC 2021",
        "Windows 10 IoT Enterprise LTSC 2024",
        "Windows 10 Enterprise LTSC 2021",
        "Windows 10 Enterprise LTSC 2024",
        "Windows 10 IoT Enterprise"
    };

            // エディション分類
            string[] ltscEditions = {
        "Windows 10 Enterprise LTSC 2021",
        "Windows 10 Enterprise LTSC 2024"
    };

            string[] serverEditions = {
        "Windows Server 2008 R2 Standard",
        "Windows Server 2008 R2 Enterprise",
        "Windows Server 2012 R2 Standard",
        "Windows Server 2016 Standard",
        "Windows Server 2019 Standard",
        "Windows Server 2019 Datacenter",
        "Windows Server 2022 Standard",
        "Windows Server 2022 Datacenter",
        "Windows Server 2025 Standard",
        "Windows Server 2025 Datacenter"
    };

            string[] embeddedEditions = {
        "Windows 10 Enterprise LTSC 2019",
        "Windows 10 IoT Enterprise LTSC 2021",
        "Windows 10 IoT Enterprise LTSC 2024",
        "Windows Embedded Standard",
        "Windows 10 IoT Enterprise",
        "Windows Embedded 8.1 Industry Pro"
    };

            // 判定
            bool isLtscEdition = ltscEditions.Any(edition.Contains);
            bool isServerEdition = serverEditions.Any(edition.Contains);
            bool isEmbeddedEdition = embeddedEditions.Any(edition.Contains);
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true))
            {
                DialogResult result = MessageBox.Show(
                    "Windowsモードに切り替えますか？",
                    "マネージャーを終了",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    string currentShell = key.GetValue("Shell")?.ToString();

                    if (currentShell == @"C:\Windows\ShellLauncher\WinFormsApp1.exe")
                    {
                        // 共通: ShellをExplorerに変更
                        // key.SetValue("Shell", "explorer.exe", RegistryValueKind.String);

                        if (isEmbeddedEdition)
                        {

                            // Embedded: 自動ログオン設定＋再起動
                            using (Form2 f2 = new Form2())
                            {
                                f2.ShowDialog();
                                int sresult = (int)f2.Tag; // Tag から 1 (OK) または 2 (Cancel) を取得

                                if (sresult == 2) // Cancel
                                {
                                    MessageBox.Show(
                                        "操作を取り消しました。",
                                        "キャンセル",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                    return; // 後続処理を止める
                                }
                                else if (sresult == 1) // OK
                                {
                                    // ★修正点：ユーザー情報を Form2 の別のプロパティから取得する★
                                    string[] userInfo = f2.UserInfo; // 例えば、UserInfoプロパティから取得
                                                                     // あるいは、f2.UserName や f2.Password のような専用プロパティから取得

                                    string username = userInfo[0];
                                    string password = userInfo[1];

                                    using (var winlogonKey = Registry.LocalMachine.OpenSubKey(
                                        @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true))
                                    {
                                        winlogonKey.SetValue("AutoAdminLogon", "1", RegistryValueKind.String);
                                        winlogonKey.SetValue("DefaultUserName", username, RegistryValueKind.String);
                                        winlogonKey.SetValue("DefaultPassword", password, RegistryValueKind.String);
                                    }

                                    MessageBox.Show(
                                        "設定を反映させました。\n変更を適用するため、再起動します。",
                                        "環境設定",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );

                                    key.SetValue("Shell", "explorer.exe", RegistryValueKind.String);
                                    // Administrator 無効化
                                    Process.Start("net", "user administrator /active:no");

                                    // 再起動
                                    System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                                }
                            }

                        }
                        else if (isServerEdition)
                        {
                            // Server: 再起動（ログオン設定なし）
                            MessageBox.Show("設定を反映させました。\n変更を適用するため、再起動します。",
                                "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                        }
                        else if (isLtscEdition)
                        {
                            // LTSC: 再起動なしで終了
                            MessageBox.Show("設定を反映しました。\nこのウィンドウを終了します。",
                                "環境設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            System.Diagnostics.Process.Start("logoff");
                        }
                        else
                        {
                            // それ以外（サポート外）
                            key.SetValue("Shell", "explorer.exe", RegistryValueKind.String);

                            MessageBox.Show(
                                "既定のWindowsがサポート対象外のものです。\n復元して再起動します。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("キャンセルされました。", "キャンセル",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //ウィンドウを最背面に移動
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Process.Start("net", "user administrator /active:yes");
        }

        // Win32 API定義
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOACTIVATE = 0x0010;
        private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(
            IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

