# 🌟 ShellLauncher v1.9 Summary

## 🧩 目的 (Purpose)
- MSI インストーラー方式の導入  
- シェルランチャーから Windows デスクトップへ切り替える際のユーザー選択機能を強化  
- Windows 7～11、Windows Server、Windows IoT Enterprise まで幅広い環境に最適化  
- 全体的な安定性向上とリソース削減  

---

# 🛠️ 変更点 (Changes)

## 🇯🇵 日本語

### 🚀 コア改善
- アプリケーションを **管理者権限必須** に変更し、安定動作を確保  
- ユーザー切り替え操作をキャンセルした後、再度切り替えを押すと  
  **資格情報入力画面が表示されなくなるバグを修正**
- インストーラー形式を **MSI のみに統一**
- Windows IoT Enterprise に合わせて内部処理を再最適化

### 📉 パフォーマンス向上
- メモリ使用量を **最低 200MB 削減**
- CPU 使用率を改善し、より均等なリソース配分に調整  

---

## 🌍 English

### 🚀 Core Improvements
- Application now **requires administrator privileges** for consistent and stable operation  
- Fixed an issue where, after canceling a user switch,  
  the **credential dialog would not appear** on the next attempt  
- Installer format unified to **MSI only**  
- Internal logic re-optimized for **Windows IoT Enterprise**

### 📉 Performance Enhancements
- Reduced memory usage by **at least 200MB**  
- Improved CPU efficiency and resource balancing  

---

# 📦 v1.9 Release Cycle

## ✔️ v1.9 Next Pre-Release
- Introduced MSI installer  
- Improved user-switch logic  
- Rechecked optimization for Windows 7–11  

## ✔️ v1.9 Release Candidate (RC1 / RC2)
- Fixed incorrect post-install behavior  
- Switched to mandatory administrator execution  
- Verified operation across Windows 7–11 and Windows Server  
 

---
