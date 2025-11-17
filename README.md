# 🚀 マイクラサーバー専用 シェルランチャー ドキュメント

このシェルランチャーは、自己満足で作成した用途不明のソフトウェアです。  
ソースコードは公開しています。使用は**自己責任**でお願いします。

---

## 目次
1. [ドキュメント・情報](#ドキュメント情報)
2. [注意事項](#注意事項)
3. [改変・導入について](#改変導入について)
4. [サポート対象OS](#サポート対象os)
   - [Windows Server](#windows-server)
   - [Windows Embedded / IoT](#windows-embedded--iot)
   - [Windows Enterprise LTSC](#windows-enterprise-ltsc)
5. [サポート対象外OS](#サポート対象外os)
6. [OSに組み込む場合の注意](#osに組み込む場合の注意)
7. [著作権・ライセンス](#著作権ライセンス)

---

## 📄 ドキュメント情報

PDF版はこちらから閲覧できます：  
[📄 View on Google Drive](https://drive.google.com/file/d/19cAzcT2R6E5SQnot3yOcxvUkj5k8s2uq/view?usp=sharing)

---

## ⚠️ 注意事項

- 無理な設定は避けてください。  
- 不適切な設定により、システムが不安定になる場合があります。

---

## 🛠 改変・導入について

- 改変は**自分のPCまたはサーバーでのみ**行ってください。  
- OSに組み込む場合は、安定した環境で作業してください。  
- 対応OSはすべて**Windows依存**です。  
- Windows Serverは**Standardエディションのみ公式サポート**。  
  DatacenterやEnterpriseは動作する場合がありますがサポート外です。

---

## ✅ サポート対象OS

### Windows Server
- Windows Server 2008 R2  
- Windows Server 2012 R2  
- Windows Server 2019  
- Windows Server 2022  
- Windows Server 2025  

※Standardエディション必須。DatacenterやEnterpriseは非サポート。

### Windows Embedded / IoT
- Windows Embedded Standard 7  
- Windows 10 IoT Enterprise  
- Windows 11 IoT Enterprise  
- Windows 10 IoT Enterprise LTSC 2021  
- Windows 11 IoT Enterprise LTSC 2024  

**制限**  
- 本番環境での使用禁止  
- 最大15人想定  
- サーバー機能以外の使用禁止

### Windows Enterprise LTSC
- Windows 10 Enterprise LTSC 2021  
- Windows 11 Enterprise LTSC 2024  

**制限**  
- 本番環境での使用禁止  
- 最大15人想定  
- サーバー機能以外の使用禁止

---

## ❌ サポート対象外OS

- Windows 10 Home / Pro  
- Windows 10 Enterprise 2016 LTSB以前  
- Windows Server 2003 R2以前  

これらは不具合やカーネル不一致の可能性があります。

---

## 💻 OSに組み込む場合の注意

- `install.wim`などに組み込む場合は、ライセンスを必ず確認してください：  
  - MC Server Soft  
  - Microsoft Windows  
  - 本ソフトウェアのライセンス条項  
- 現在のリリースはすべて**ベータ版**です。

---

## 📄 著作権・ライセンス

**製作者:** ゆっくりFred  
**All rights reserved.**  

改良・配布する場合は、**事前に製作者に連絡**してください。

---

# 🚀 Minecraft Server Shell Launcher Documentation

This Shell Launcher was originally created for personal satisfaction.  
The source code is **publicly available**. Use at your **own risk**.

---

## 📄 Documentation & Information

PDF version:  
[📄 View on Google Drive](https://drive.google.com/file/d/19cAzcT2R6E5SQnot3yOcxvUkj5k8s2uq/view?usp=sharing)

---

## ⚠️ Important Notice

- Do not apply unreasonable settings.  
- Improper settings may cause **system instability**.

---

## 🛠 Modification & Deployment

- Modify only on your **own computer or server**.  
- Integrate into OS only on **stable environments**.  
- Requires **Windows Server OS**.  
- Only **Standard Edition** supported; Datacenter or Enterprise may work but are not officially supported.

---

## ✅ Supported OS Editions

### Windows Server
- Windows Server 2008 R2  
- Windows Server 2012 R2  
- Windows Server 2019  
- Windows Server 2022  
- Windows Server 2025  

### Windows Embedded / IoT
- Windows Embedded Standard 7  
- Windows 10 IoT Enterprise  
- Windows 11 IoT Enterprise  
- Windows 10 IoT Enterprise LTSC 2021  
- Windows 11 IoT Enterprise LTSC 2024  

**Restrictions:**  
- Not for production use  
- Up to 15 players  
- Limited to server functions only

### Windows Enterprise LTSC
- Windows 10 Enterprise LTSC 2021  
- Windows 11 Enterprise LTSC 2024  

**Restrictions:**  
- Not for production use  
- Up to 15 players  
- Limited to server functions only

---

## ❌ Unsupported Editions

- Windows 10 Home / Pro  
- Windows 10 Enterprise 2016 LTSB or earlier  
- Windows Server 2003 R2 or older  

May cause **unexpected errors** or **kernel mismatches**.

---

## 💻 Notes for OS Integration

- When integrating into `install.wim`, read all licenses:  
  - MC Server Soft  
  - Microsoft Windows  
  - This Software License Agreement  
- All releases are **beta versions**.

---

## 📄 Copyright & License

**Author:** ゆっくりFred  
**All rights reserved.**  

Contact the author before modifying or redistributing.
