using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;
using FrooxEngine.UIX;
using Elements.Core;

namespace CenterCircleJank
{
    public class CenterCircleJank : ResoniteMod
    {
        public override string Name => "CenterCircleJank";
        public override string Author => "APnda";
        public override string Version => "1.0.1";
        public override string Link => "https://github.com/ap6661/CenterCircleJank";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.apnda.centercirclejank");
            harmony.PatchAll();
        }

        
        [HarmonyPatch(typeof(ContextMenu))]
        class CenterCircleJankPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch("OnAwake")]
            public static void Postfix(ContextMenu __instance, 
                                       SyncRef<OutlinedArc> ____innerCircle)
            {
                __instance.RunInUpdates(3, () =>
                {
                    if (__instance.Slot.ActiveUserRoot.ActiveUser != __instance.LocalUser)
                        return;

                    ____innerCircle.Target.Arc.Value = 90f;
                    ____innerCircle.Target.InnerRadiusRatio.Value = -5f;
                    Slot tempSlot = ____innerCircle.Target.Slot.AddSlot("Visual");
                    tempSlot.OrderOffset = -1;
                    OutlinedArc tempOutlinedArc = tempSlot.AttachComponent<OutlinedArc>(true, null);

                    tempOutlinedArc.FillColor.Value = new colorX(0, 0, 0, 0);
                    tempOutlinedArc.OutlineColor.Value = new colorX(0, 0, 0, 0);
                    tempOutlinedArc.InnerRadiusRatio.Value = 0f;
                });
            }
        }
    }
}