@echo off
rem Android SMAPI 构建：产物已就绪，部署由 pack-android.ps1 完成。
rem 若需要 adb 直推调试，取消下面两行注释并改包名为你的启动器包名：
rem set AppName=com.yourpackagename
rem adb push "bin\Android Release\StardewModdingAPI.dll" "/storage/emulated/0/Android/data/%AppName%/files/Stardew Assemblies/StardewModdingAPI.dll"
exit /b 0
