using System.Windows;
using System.Windows.Interop;
using HarmonyLib;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32;

namespace ClassIslandHide.Patchers;

[HarmonyPatch(typeof(Window), nameof(Window.Show))]
public class WindowShowPatcher
{
    static void Prefix(Window __instance)
    {
        __instance.Title = Plugin.GetRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-={}|:\"<>?[]\\;',./~`");
    }
}