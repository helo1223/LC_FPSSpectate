using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using FPSSpectate.Patches;

namespace FPSSpectate
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class FPSSpectate : BaseUnityPlugin
    {
        private const string modGUID = "5Bit.FPSSpectate";
        private const string modName = "FPSSpectate";
        private const string modVersion = "1.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static FPSSpectate Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            harmony.PatchAll();
        }
    }


}