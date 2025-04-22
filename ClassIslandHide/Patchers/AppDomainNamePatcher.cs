using System.Diagnostics;
using HarmonyLib;

namespace ClassIslandHide.Patchers;

[HarmonyPatch(typeof(AppDomain))]
[HarmonyPatch("get_FriendlyName")]
public class AppDomainNamePatcher
{
    static void Postfix(ref string __result)
    {
        var stackTrace = new StackTrace();
        if (stackTrace.GetFrames().Any(x => x.GetMethod()?.DeclaringType?.Name == "HwndWrapper"))
        {
            __result = Plugin.GetRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
        }
    }
}