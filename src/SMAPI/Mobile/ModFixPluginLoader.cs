using System;
using System.IO;
using System.Reflection;
using StardewModdingAPI.Framework;
using StardewModdingAPI.Internal;

namespace StardewModdingAPI.Mobile;

/// <summary>
/// 从 <c>ExternalFilesDir/ModFixes</c> 目录加载 mod 修复插件（由管理器安装到启动器目录）。
/// 必须在 mod 加载（RunInteractively）之前调用，插件才能抢先注册回调。
/// 约定：文件重命名为 *.dll.disabled 即禁用（*.dll 通配不匹配）；API 版本不匹配的插件显式跳过。
/// </summary>
internal static class ModFixPluginLoader
{
    public static void LoadPlugins(IMobileFixRegistry registry)
    {
        var monitor = SCore.Instance.SMAPIMonitor;
        string dir = Path.Combine(EarlyConstants.ExternalFilesDir, "ModFixes");
        if (!Directory.Exists(dir))
            return;

        int loaded = 0;
        int failed = 0;
        foreach (string dll in Directory.GetFiles(dir, "*.dll", SearchOption.AllDirectories))
        {
            try
            {
                var asm = Assembly.LoadFrom(dll);
                foreach (var type in asm.GetTypes())
                {
                    if (type.IsAbstract || !typeof(IMobileFixPlugin).IsAssignableFrom(type))
                        continue;

                    var plugin = (IMobileFixPlugin)Activator.CreateInstance(type)!;
                    if (plugin.ApiVersion != registry.ApiVersion)
                    {
                        failed++;
                        monitor.Log($"Skipped mod fix plugin {asm.GetName().Name}: requires API v{plugin.ApiVersion}, current v{registry.ApiVersion}", LogLevel.Warn);
                        continue;
                    }

                    plugin.Init(registry);
                    loaded++;
                    monitor.Log($"Loaded mod fix plugin: {asm.GetName().Name}");
                }
            }
            catch (Exception ex)
            {
                failed++;
                monitor.Log($"Failed to load mod fix plugin {dll}: {ex.GetLogSummary()}", LogLevel.Error);
            }
        }
        monitor.Log($"Mod fix plugins loaded: {loaded}, failed/skipped: {failed}");
    }
}
