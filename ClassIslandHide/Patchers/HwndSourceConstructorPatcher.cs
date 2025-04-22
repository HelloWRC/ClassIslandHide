using System.Windows.Interop;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using HarmonyLib;

namespace ClassIslandHide.Patchers;

[HarmonyPatch(typeof(HwndSource), "Initialize")]
public class HwndSourceConstructorPatcher
{
    static void Postfix(HwndSource __instance)
    {
        _ = PInvoke.SetWindowDisplayAffinity((HWND)__instance.Handle, WINDOW_DISPLAY_AFFINITY.WDA_EXCLUDEFROMCAPTURE);
    }
}