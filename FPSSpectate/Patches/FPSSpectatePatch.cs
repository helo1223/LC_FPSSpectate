using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace FPSSpectate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class FPSSpectatePatch
    {

        private const float SPECTATE_OFFSET = 1.5f;

        [HarmonyPatch("LateUpdate")]
        [HarmonyPostfix]
        private static void LateUpdate(PlayerControllerB __instance)
        {
            if (__instance.spectatedPlayerScript != null)
            {
                Transform specVisorTransform = __instance.spectatedPlayerScript.visorCamera.transform;

                __instance.spectateCameraPivot.position = specVisorTransform.position + specVisorTransform.forward.normalized * SPECTATE_OFFSET;
                __instance.spectateCameraPivot.rotation = specVisorTransform.rotation;
            }
        }
    }
}
