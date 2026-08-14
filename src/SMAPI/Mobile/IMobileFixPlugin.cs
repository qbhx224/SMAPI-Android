using System;
using System.Reflection;
using Mono.Cecil;

namespace StardewModdingAPI.Mobile;

/// <summary>
/// mod 修复插件注册表（SMAPI 提供，插件通过它挂接修复回调）。
/// </summary>
public interface IMobileFixRegistry
{
    /// <summary>SMAPI 日志（插件用它输出日志）。</summary>
    IMonitor Monitor { get; }

    /// <summary>目标 mod 程序集加载完成后回调（对应 AppDomain.AssemblyLoad）。</summary>
    /// <param name="dllFileName">目标 DLL 文件名（如 "SpaceCore.dll"）。</param>
    /// <param name="callback">回调（参数为已加载的程序集）。</param>
    void RegisterOnModLoaded(string dllFileName, Action<Assembly> callback);

    /// <summary>目标 mod 程序集 IL 重写阶段回调（mod 加载管线内，可用 Mono.Cecil 修改 IL）。</summary>
    /// <param name="assemblyName">目标程序集名（去 .dll）。</param>
    /// <param name="callback">回调（参数为可写的 AssemblyDefinition）。</param>
    void RegisterRewriteModAssemblyDef(string assemblyName, Action<AssemblyDefinition> callback);

    /// <summary>目标 mod 入口类实例化后回调。</summary>
    /// <param name="asmFileName">目标 DLL 文件名。</param>
    /// <param name="onPostModEntry">回调（参数为 mod 实例）。</param>
    void RegisterOnPostModEntry(string asmFileName, Action<IMod> onPostModEntry);
}

/// <summary>
/// mod 修复插件：放入启动器 ExternalFilesDir/ModFixes 目录，SMAPI 启动时自动发现并加载。
/// </summary>
public interface IMobileFixPlugin
{
    /// <summary>初始化插件并注册修复回调。</summary>
    /// <param name="registry">修复注册表。</param>
    void Init(IMobileFixRegistry registry);
}
