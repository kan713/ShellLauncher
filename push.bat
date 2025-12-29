@echo off
setlocal enabledelayedexpansion

echo ================================
echo   ShellLauncher Branch Creator
echo ================================
echo.

:: ブランチ名入力
set /p BRANCH=作成したいブランチ名を入力してね: 

if "%BRANCH%"=="" (
    echo ブランチ名が空だよ～終了するね。
    pause
    exit /b
)

echo.
echo ▼ Gitリポジトリを確認中...
if not exist ".git" (
    echo ここはGitリポジトリじゃないみたい。
    echo クローンしてない場合は自動で作るよ。
    echo.

    git clone https://github.com/kan713/ShellLauncher.git
    cd ShellLauncher
) else (
    echo 既存リポジトリを使用するよ。
)

echo.
echo ▼ 最新を取得...
git pull

echo.
echo ▼ 新しいブランチを作成中: %BRANCH%
git checkout -b %BRANCH%

echo.
echo ▼ GitHub に push するね...
git push -u origin %BRANCH%

echo.
echo ************************************
echo   ブランチ %BRANCH% を作成したよ！
echo ************************************
pause
