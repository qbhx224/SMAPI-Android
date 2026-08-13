# SMAPI-Android

[Stardew Modding API](https://smapi.io) 的 Android 移植版，基于上游 [Pathoschild/SMAPI](https://github.com/Pathoschild/SMAPI) 4.5.2（develop @ 79f9bbbe）。

让 SMAPI 与 mod 生态可在 Android 设备上运行（对接自研启动器，注入游戏进程，同进程加载游戏与 mod）。

## 特性

- 完整 SMAPI 4.5.2 功能基线（mod 加载、事件系统、Content/存档/翻译、控制台等）
- 安卓适配层（`src/SMAPI/Mobile/`）：
  - 游戏循环冻结修复 + 帧回调注册表（AndroidGameLoopManager）
  - 分帧任务调度（32ms 预算）与分帧读档（AndroidSModHooks / AndroidSaveLoaderManager）
  - mod 加载屏显状态机（AndroidModLoaderManager）
  - NVorbis OGG 音频支持（CueDef / OggStream / SoundEffectVorbis）
  - IL 重写器（DeepCloner / GameWindow / KeyboardInput / Texture2D 等）
  - 8 个知名 mod 的安卓修复框架（AndroidModFixManager）
  - 沉浸式全屏、刘海屏适配、标题版本信息菜单
- 打包工具 `src/PackSMAPIZip/`：产出 `SMAPI-Android-4.x.x.x.zip`（DLL + smapi-internal）

## 路线借鉴声明

安卓适配层的**设计路线**借鉴了 [NRT-SMAPI-Android](https://github.com/NRTnarathip/SMAPI-Android-1.6)（LGPL-3.0）与 [ZaneYork/SMAPI](https://github.com/ZaneYork/SMAPI) 的安卓移植思路（适配层组织、分帧加载、mod 修复框架等），在此基础上基于上游 4.5.2 重新整合与适配。本项目与 NRT 项目的代码均遵循 LGPL-3.0，详见 [NOTICE](NOTICE)。

## 构建

前置：.NET SDK 9.0.3xx（含 Android workload）、游戏本体 DLL 引用（`src/DependenciesDll/`）

```bash
# 构建 SMAPI Android
dotnet build src/SMAPI -c "Android Release"

# 打包 SMAPI-Android zip
dotnet run --project src/PackSMAPIZip -c Release
```

## 版本

- 版本号：`4.5.2.0`（上游 4.5.2 + Android 构建号）
- 与启动器的契约：`StardewModdingAPI.Mobile.SMAPIAndroidBuild.BuildCode`、`EarlyConstants.RawApiVersionForAndroid` 常量

## 许可

LGPL-3.0（与上游一致），见 [LICENSE.txt](LICENSE.txt)。
