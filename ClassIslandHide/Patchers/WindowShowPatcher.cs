using System.Windows;
using HarmonyLib;
using Windows.Win32;
using Avalonia.Controls;
using Avalonia.Platform;
using ClassIsland.Platforms.Abstraction;
using ClassIsland.Platforms.Abstraction.Enums;

namespace ClassIslandHide.Patchers;

[HarmonyPatch(typeof(Window))]
public class WindowPatcher
{
    private static void PrefixCore(Window __instance)
    {
        __instance.Title = Plugin.GetRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-={}|:\"<>?[]\\;',./~`");
    }
    
    [HarmonyPatch("EnsureStateBeforeShow")]
    [HarmonyPrefix]
    public static void ShowPrefix(Window __instance)
    {
        PrefixCore(__instance);
    }
    
    
    [HarmonyPatch(MethodType.Constructor, typeof(IWindowImpl))]
    [HarmonyPostfix]
    static void CtorPostfix(Window __instance)
    {
        PlatformServices.WindowPlatformService.SetWindowFeature(__instance, WindowFeatures.Private, true);
    }
}