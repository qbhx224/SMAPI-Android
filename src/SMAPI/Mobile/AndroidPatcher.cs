using System;
using HarmonyLib;
using StardewModdingAPI.Framework;
using StardewModdingAPI.Internal;
using StardewModdingAPI.Mobile.Facade;
using StardewModdingAPI.Mobile.Vectors;
using StardewValley.Menus;

namespace StardewModdingAPI.Mobile;

[HarmonyPatch]
internal static class AndroidPatcher
{
    public static Harmony? harmony { get; private set; }
    internal static void Setup()
    {
        AndroidLogger.Log("===========================");
        AndroidLogger.Log("===========================");
        AndroidLogger.Log("On AndroidPatcher.Setup()");

        try
        {
            //setup
            Log.enabled = true;
            harmony = new Harmony(nameof(AndroidPatcher));

            VersionInfoMenu.Init();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error on AndroidPatcher.Setup()");
            AndroidLogger.Log(ex);
            throw;
        }
    }
    static void ApplyHarmonyPatchAll()
    {
        var monitor = SCore.Instance.SMAPIMonitor;
        monitor.Log("On ApplyHarmonyPatchAll()..");
        try
        {
            harmony.PatchAll();
            monitor.Log("Done harmony.PatchAll()");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            monitor.Log(ex.GetLogSummary(), LogLevel.Error);
            throw;
        }
    }
    static void SetupModFix()
    {
        //Register mod fix here
        var modFix = AndroidModFixManager.Init();
        //外部修复插件（管理器安装到 ExternalFilesDir/ModFixes）
        ModFixPluginLoader.LoadPlugins(modFix);
    }
    internal static void OnBeforeSCoreRun()
    {
        var saveBackupZip = new SaveBackupZip();
        saveBackupZip.Start();

        SetupModFix();
        ApplyHarmonyPatchAll();
        VectorTypeConverterFix.ApplyPatch(harmony);
        MobileFarmChooserPatcher.Patch(harmony);
        LetterViewerMenuRewriter.ApplyPatch(harmony);
    }


    // Disable checkForAndLoadEmergencySave for Emergency Save
    [HarmonyPatch(typeof(TitleMenu), nameof(TitleMenu.checkForAndLoadEmergencySave))]
    [HarmonyPrefix]
    static bool Disable_checkForAndLoadEmergencySave(ref bool __result)
    {
        TitleMenu.PromptedEmergencySave = true;
        __result = false;
        return false;
    }
}
