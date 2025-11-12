# 🚀 マイクラサーバー専用 シェルランチャー ドキュメント
このシェルランチャーは、自己満足で作成した用途不明のものです。  
ソースコードは公開しておりません。 → ソースコードを公開しました  
本ソフトウェアを使用する際は必ず自己責任でお使いください。  

---


## 📝 ドキュメント・情報

下記のGoogle Driveにpdfを公開中
[📄 View on Google Drive](https://drive.google.com/file/d/19cAzcT2R6E5SQnot3yOcxvUkj5k8s2uq/view?usp=sharing)

---


⚠️ 注意事項

無茶な設定はしないように！！！

無茶苦茶にすると予期しないエラーや動作をして、システムが不安定になる可能性があります！！！

---


🛠️ 改変・導入について
* 改変する際は、各自のコンピューターまたはサーバーでお使いください。

* OSにコミットする際は、安定した環境で、ご自身のコンピューターでお使い頂ますようお願い申し上げます。

* サーバーOSはすべてWindowsに依存します。

改変する際は各自のコンピューターまたはサーバーでお使いください。  
OSにコミットする際は安定した環境で、自分のコンピュータでお使い頂ますようお願い申し上げます。

本ソフトウェアが対応してるOSエディションは以下の通りです。  
本ソフトウェアのサーバーOSはすべてWindowsに依存します。  
またWindows ServerエディションはすべてStandardエディションのみ動作します。  
Datacenterエディションなどのエンタープライズシリーズは動作しますがサポート対象外です。

---


## ✅ サポート対象のOSエディション

### Windows Server OS
* Windows Server 2008 R2
* Windows Server 2012 R2
* Windows Server 2019
* Windows Server 2022
* Windows Server 2025

ℹ️ Windows Serverについて
Windows ServerエディションはすべてStandardエディションのみ動作します。 
Datacenterエディションなどのエンタープライズシリーズは動作しますが、サポート対象外です。

### Windows Embedded (Windows IoT)
* Windows Embedded Standard 7
* Windows 10 IoT Enterprise
* Windows 11 IoT Enterprise
* Windows 10 IoT Enterprise LTSC 2021
* Windows 11 IoT Enterprise LTSC 2024

サポート対象外
* Windows Server 2008以前のOS
* Windows Server 2012 / Windows Server 2016（動作環境の都合上）

制約事項
* 本番環境として使用禁止
* 最大15人の参加を想定して使用 
* 特定の機能以外の使用禁止

### Windows For Enterprise LTSC
* Windows 10 Enterprise LTSC 2021
* Windows 11 Enterprise LTSC 2024

制約事項
* 本番環境として使用禁止
* 最大15人の参加を想定して使用 
* 特定の機能以外の使用禁止

### 🚫 サポート対象外のエディション
* Windows 10 HomeやProなどの一般向け
* Windows 10 Ent 2016 LTSB以前
* Windows Server 2003 R2以前

予期せぬトラブルやカーネルバージョン不一致の可能性あり

---


# 💻 OSに組み込む場合の注意事項
本ソフトウェアを組み込んでinstall.wimなどのインストールパッケージにする場合、  
必ず以下のソフトウェア・ライセンスをよく読んでからから実施するようお願いします。

* MC Server Soft
* Microsoft Windows
* 本ソフトウェアライセンス条項

リリースは現時点ですべてベータ版リリースとなります。
ご了承ください。

---

📄 著作権・ライセンス情報
本ソフトウェア製作者： ゆっくりFred

著作権は本ソフトウェア製作者に依存しますが、改良を第三者が行い配布を行う場合、必ず製作者にお問い合わせください。

Copyright 2021-2025 ykFred_699 All rights reserved.

---

# 🚀 Minecraft Server Shell Launcher Documentation

This Shell Launcher was originally created for personal satisfaction and had no clear purpose.  
The source code was **originally private**, but it is now **publicly available**.  
Please use this software **at your own risk**.

---

## 📝 Documentation & Information

A PDF version of this documentation is available on Google Drive:  
[📄 View on Google Drive](https://drive.google.com/file/d/19cAzcT2R6E5SQnot3yOcxvUkj5k8s2uq/view?usp=sharing)

---

⚠️ **Important Notice**

Do **not** apply unreasonable settings!  
Doing so may cause **unexpected errors** or **system instability**.

---

## 🛠️ Modification & Deployment

* You may modify this software **only on your own computer or server**.  
* When committing changes to an OS, ensure that your system is **stable and properly configured**.  
* This software **depends entirely on Windows Server operating systems**.

> All supported Windows Server editions must be **Standard Edition**.  
> Datacenter or Enterprise editions **may work**, but are **not officially supported**.

---

## ✅ Supported OS Editions

### Windows Server
- Windows Server 2008 R2  
- Windows Server 2012 R2  
- Windows Server 2019  
- Windows Server 2022  
- Windows Server 2025  

ℹ️ **Note:**  
All supported editions must be **Windows Server Standard**.  
Datacenter or Enterprise editions are not officially supported due to system compatibility concerns.

---

### Windows Embedded / Windows IoT
- Windows Embedded Standard 7  
- Windows 10 IoT Enterprise  
- Windows 11 IoT Enterprise  
- Windows 10 IoT Enterprise LTSC 2021  
- Windows 11 IoT Enterprise LTSC 2024  

**Unsupported:**
- Windows Server 2008 or older  
- Windows Server 2012 / 2016 (due to environmental limitations)

**Restrictions:**
- Not intended for production use  
- Designed for up to **15 concurrent players**  
- Use limited to specific server-related functions

---

### Windows Enterprise LTSC
- Windows 10 Enterprise LTSC 2021  
- Windows 11 Enterprise LTSC 2024  

**Restrictions:**
- Not intended for production use  
- Designed for up to **15 concurrent players**  
- Use limited to specific server-related functions

---

### 🚫 Unsupported Editions
- Windows 10 Home / Pro (consumer versions)  
- Windows 10 Enterprise 2016 LTSB or earlier  
- Windows Server 2003 R2 or older  

These editions may encounter **unexpected errors** or **kernel mismatches**.

---

## 💻 Notes for OS Integration

If you plan to integrate this software into an installation package (e.g., `install.wim`),  
make sure you have **read and understood** all related software license agreements:

* MC Server Soft  
* Microsoft Windows  
* This Software License Agreement

All releases are currently **beta versions**.  
Please understand that stability is **not guaranteed**.

---

## 📄 Copyright & License

**Author:** ゆっくりFred  
**All rights reserved by the creator.**

If you wish to modify or redistribute this software,  
please **contact the author for permission** before doing so.

---
