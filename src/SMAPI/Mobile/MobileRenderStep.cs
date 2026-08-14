namespace StardewModdingAPI.Mobile;

/// <summary>
/// 渲染步骤（SMAPI 语义层）。
/// 数值与游戏 RenderSteps 一致，由核心负责转换；游戏枚举变化时核心适配，插件不受影响。
/// 语义：每帧渲染管线按序切换各阶段，Overlays 为界面覆盖层阶段（叠加 UI 绘制用）。
/// </summary>
public enum MobileRenderStep
{
    FullScene = 0,
    World = 1,
    World_Background = 2,
    World_Sorted = 3,
    World_AlwaysFront = 4,
    World_Weather = 5,
    World_RenderLightmap = 6,
    World_DrawLightmapOnScreen = 7,
    MenuBackground = 8,
    Menu = 9,
    HUD = 10,
    DialogueBox = 11,
    Overlays = 12,
    Overlays_OverlayMenu = 13,
    Overlays_Chatbox = 14,
    Overlays_OnscreenKeyboard = 15,
    Minigame = 16,
    LoadingScreen = 17,
    GlobalFade = 18,
    OverlayTemporarySprites = 19,
}
