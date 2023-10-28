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
        public override string Version => "1.0.0";
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
            [HarmonyPatch("OnAttach")]
            public static void Postfix(SyncRef<OutlinedArc> ____innerCircle)
            {
                ____innerCircle.Target.Arc.Value = 90f;
                ____innerCircle.Target.InnerRadiusRatio.Value = -5f;
                Slot tempSlot = ____innerCircle.Target.Slot.AddSlot("Visual");
                tempSlot.OrderOffset = -1;
                OutlinedArc tempOutlinedArc = tempSlot.AttachComponent<OutlinedArc>(true, null);

                tempOutlinedArc.FillColor.Value = new colorX(0, 0, 0, 0);
                tempOutlinedArc.OutlineColor.Value = new colorX(0, 0, 0, 0);
                tempOutlinedArc.InnerRadiusRatio.Value = 0f;
            }
        }
    }
}