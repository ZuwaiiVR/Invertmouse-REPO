using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ivm
{
    [BepInPlugin("InvertMouse", "InvertMouse by Zuwaii", "V1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin InvertMouse is loaded!");
            var harmony = new Harmony("com.zuwaii.semiinputpatch");
            harmony.PatchAll();
            Logger.LogInfo("SemiFunc.InputMouseY patched successfully.");

        }
    }


    [HarmonyPatch(typeof(SemiFunc), "InputMouseY")]
    class Patch_SemiFunc_InputMouseY
    {
        static bool Prefix(ref float __result)
        {
            __result = -InputManager.instance.GetMouseY(); // No negation
            return false; // Skip original method
        }
    }

}
