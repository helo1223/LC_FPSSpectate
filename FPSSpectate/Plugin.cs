using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
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

            ConfigEntry<bool> defaultViewConfig = Config.Bind("Settings", "Default to first person", true, "Whether or not to default to first person when spectating");
            FPSSpectatePatch.firstPerson = defaultViewConfig.Value;

            harmony.PatchAll();
        }
    }


}