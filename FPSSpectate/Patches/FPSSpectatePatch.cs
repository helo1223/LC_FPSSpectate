using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPSSpectate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class FPSSpectatePatch
    {

        private const float SPECTATE_OFFSET = 1.5f;
        private static bool firstPerson = true;
        private static bool debounced = false;

        [HarmonyPatch("LateUpdate")]
        [HarmonyPostfix]
        private static void LateUpdate(PlayerControllerB __instance)
        {

            if (Keyboard.current.vKey.wasPressedThisFrame && !debounced)
            {
                firstPerson = !firstPerson;
                debounced = true;
            }

            if(Keyboard.current.vKey.wasReleasedThisFrame)
            {
                debounced = false;
            }

            if (__instance.spectatedPlayerScript != null && firstPerson)
            {

                Transform[] bodyParts = __instance.spectatedPlayerScript.bodyParts;
                bodyParts[0].localScale = new(0,0,0);


                Transform specPivotTransform = __instance.spectateCameraPivot.transform;
                Transform specVisorTransform = __instance.spectatedPlayerScript.visorCamera.transform;
                specPivotTransform.position = specVisorTransform.position + specVisorTransform.forward.normalized * SPECTATE_OFFSET;
                specPivotTransform.rotation = specVisorTransform.rotation;
            }
        }
    }
}
