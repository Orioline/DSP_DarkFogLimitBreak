using System;
using BepInEx;
using UnityEngine;
using HarmonyLib;

namespace DarkFogLimitBreak
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class DarkFogLimitBreak : BaseUnityPlugin

    {
        public const string PLUGIN_GUID = "com.orioline.DarkFogLimitBreak";
        public const string PLUGIN_NAME = "DarkFogLimitBreak";
        public const string PLUGIN_VERSION = "0.0.1";

        private static Harmony harmony;

        void Awake()
        {
            ApplyPatches();
        }

        void Start()
        {
            // do nothing
        }

        void Update()
        {
            // do nothing
        }

        void OnDestroy()
        {
            RevertPatches();
        }

        void ApplyPatches()
        {
            try
            {
                harmony = new Harmony(PLUGIN_GUID);
                harmony.PatchAll(typeof(PatchDFLB));

                Logger.LogInfo("Patches applied!");
            }
            catch (Exception e)
            {
                Logger.LogError("Patch failed, exception= " + e.ToString());
            }
        }

        void RevertPatches()
        {
            harmony.UnpatchSelf();
        }
    }

    //--------
    // PATCH
    //--------
    class PatchDFLB
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(UICombatSettingsDF), "UpdateUIParametersDisplay")]
        public static bool UpdateUIParametersDisplay(ref UICombatSettingsDF __instance)
        {
            float num = __instance.combatSettings.aggressiveness;
            string text = "";
            if (num < -0.99f)
            {
                __instance.aggresiveSlider.value = 0f;
            }
            else if (num < 0.01f)
            {
                __instance.aggresiveSlider.value = 1f;
            }
            else if (num < 0.51f)
            {
                __instance.aggresiveSlider.value = 2f;
            }
            else if (num < 1.01f)
            {
                __instance.aggresiveSlider.value = 3f;
            }
            else if (num < 2.01f)
            {
                __instance.aggresiveSlider.value = 4f;
            }
            else
            {
                __instance.aggresiveSlider.value = 5f;
            }
            switch ((int)(__instance.aggresiveSlider.value + 0.5f))
            {
                case 0:
                    text = "活靶子".Translate();
                    break;
                case 1:
                    text = "被动".Translate();
                    break;
                case 2:
                    text = "消极".Translate();
                    break;
                case 3:
                    text = "正常".Translate();
                    break;
                case 4:
                    text = "积极".Translate();
                    break;
                case 5:
                    text = "狂暴".Translate();
                    break;
            }
            __instance.aggresiveText.text = text;
            num = __instance.combatSettings.initialLevel;
            if (num < 0.01f)
            {
                __instance.initLevelSlider.value = 0f;
            }
            else if (num < 1.01f)
            {
                __instance.initLevelSlider.value = 1f;
            }
            else if (num < 3.01f)
            {
                __instance.initLevelSlider.value = 3f;
            }
            else if (num < 6.01f)
            {
                __instance.initLevelSlider.value = 6f;
            }
            else if (num < 10.01f)
            {
                __instance.initLevelSlider.value = 10f;
            }
            else if (num < 12.01f)
            {
                __instance.initLevelSlider.value = 12f;
            }
            else if (num < 15.01f)
            {
                __instance.initLevelSlider.value = 15f;
            }
            else if (num < 18.01f)
            {
                __instance.initLevelSlider.value = 18f;
            }
            else if (num < 21.01f)
            {
                __instance.initLevelSlider.value = 21f;
            }
            else if (num < 24.01f)
            {
                __instance.initLevelSlider.value = 24f;
            }
            else
            {
                __instance.initLevelSlider.value = 30f;
            }
            text = num.ToString();
            __instance.initLevelText.text = text;
            num = __instance.combatSettings.initialGrowth;
            if (num < 0.01f)
            {
                __instance.initGrowthSlider.value = 0f;
            }
            else if (num < 0.26f)
            {
                __instance.initGrowthSlider.value = 1f;
            }
            else if (num < 0.51f)
            {
                __instance.initGrowthSlider.value = 2f;
            }
            else if (num < 0.76f)
            {
                __instance.initGrowthSlider.value = 3f;
            }
            else if (num < 1.01f)
            {
                __instance.initGrowthSlider.value = 4f;
            }
            else if (num < 1.51f)
            {
                __instance.initGrowthSlider.value = 5f;
            }
            else
            {
                __instance.initGrowthSlider.value = 6f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.initGrowthText.text = text;
            num = __instance.combatSettings.initialColonize;
            if (num < 0.02f)
            {
                __instance.initOccupiedSlider.value = 0f;
            }
            else if (num < 0.26f)
            {
                __instance.initOccupiedSlider.value = 1f;
            }
            else if (num < 0.51f)
            {
                __instance.initOccupiedSlider.value = 2f;
            }
            else if (num < 0.76f)
            {
                __instance.initOccupiedSlider.value = 3f;
            }
            else if (num < 1.01f)
            {
                __instance.initOccupiedSlider.value = 4f;
            }
            else if (num < 1.51f)
            {
                __instance.initOccupiedSlider.value = 5f;
            }
            else

            {
                __instance.initOccupiedSlider.value = 6f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.initOccupiedText.text = text;
            num = __instance.combatSettings.maxDensity;
            if (num < 1.01f)
            {
                __instance.maxDensitySlider.value = 0f;
            }
            else if (num < 2.01f)
            {
                __instance.maxDensitySlider.value = 2f;
            }
            else if (num < 3.01f)
            {
                __instance.maxDensitySlider.value = 3f;
            }
            else if (num < 4.01f)
            {
                __instance.maxDensitySlider.value = 4f;
            }
            else if (num < 5.01f)
            {
                __instance.maxDensitySlider.value = 5f;
            }
            else
            {
                __instance.maxDensitySlider.value = 6f;
            }
            text = num.ToString() + "x";
            __instance.maxDensityText.text = text;
            num = __instance.combatSettings.growthSpeedFactor;
            if (num < 0.26f)
            {
                __instance.growthSpeedSlider.value = 0f;
            }
            else if (num < 0.51f)
            {
                __instance.growthSpeedSlider.value = 1f;
            }
            else if (num < 1.01f)
            {
                __instance.growthSpeedSlider.value = 2f;
            }
            else if (num < 2.01f)
            {
                __instance.growthSpeedSlider.value = 3f;
            }
            else
            {
                __instance.growthSpeedSlider.value = 4f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.growthSpeedText.text = text;
            num = __instance.combatSettings.powerThreatFactor;
            if (num < 0.02f)
            {
                __instance.powerThreatSlider.value = 0f;
            }
            else if (num < 0.11f)
            {
                __instance.powerThreatSlider.value = 1f;
            }
            else if (num < 0.21000001f)
            {
                __instance.powerThreatSlider.value = 2f;
            }
            else if (num < 0.51f)
            {
                __instance.powerThreatSlider.value = 3f;
            }
            else if (num < 1.01f)
            {
                __instance.powerThreatSlider.value = 4f;
            }
            else if (num < 2.01f)
            {
                __instance.powerThreatSlider.value = 5f;
            }
            else if (num < 5.01f)
            {
                __instance.powerThreatSlider.value = 6f;
            }
            else if (num < 8.01f)
            {
                __instance.powerThreatSlider.value = 7f;
            }
            else
            {
                __instance.powerThreatSlider.value = 8f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.powerThreatText.text = text;
            num = __instance.combatSettings.battleThreatFactor;
            if (num < 0.02f)
            {
                __instance.combatThreatSlider.value = 0f;
            }
            else if (num < 0.11f)
            {
                __instance.combatThreatSlider.value = 1f;
            }
            else if (num < 0.21000001f)
            {
                __instance.combatThreatSlider.value = 2f;
            }
            else if (num < 0.51f)
            {
                __instance.combatThreatSlider.value = 3f;
            }
            else if (num < 1.01f)
            {
                __instance.combatThreatSlider.value = 4f;
            }
            else if (num < 2.01f)
            {
                __instance.combatThreatSlider.value = 5f;
            }
            else if (num < 5.01f)
            {
                __instance.combatThreatSlider.value = 6f;
            }
            else if (num < 8.01f)
            {
                __instance.combatThreatSlider.value = 7f;
            }
            else
            {
                __instance.combatThreatSlider.value = 8f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.combatThreatText.text = text;
            num = __instance.combatSettings.battleExpFactor;
            if (num < 0.02f)
            {
                __instance.DFExpSlider.value = 0f;
            }
            else if (num < 0.11f)
            {
                __instance.DFExpSlider.value = 1f;
            }
            else if (num < 0.21000001f)
            {
                __instance.DFExpSlider.value = 2f;
            }
            else if (num < 0.51f)
            {
                __instance.DFExpSlider.value = 3f;
            }
            else if (num < 1.01f)
            {
                __instance.DFExpSlider.value = 4f;
            }
            else if (num < 2.01f)
            {
                __instance.DFExpSlider.value = 5f;
            }
            else if (num < 5.01f)
            {
                __instance.DFExpSlider.value = 6f;
            }
            else if (num < 8.01f)
            {
                __instance.DFExpSlider.value = 7f;
            }
            else
            {
                __instance.DFExpSlider.value = 8f;
            }
            text = (num * 100f).ToString() + "%";
            __instance.DFExpText.text = text;
            GameDesc gameDesc = new GameDesc();
            float difficulty = __instance.combatSettings.difficulty;
            string arg = (difficulty >= 9.9999f) ? difficulty.ToString("0.00") : difficulty.ToString("0.000");
            __instance.difficultyText.text = string.Format("难度系数值".Translate(), arg);
            __instance.difficultTipGroupDF.SetActive((__instance.combatSettings.aggressiveLevel == EAggressiveLevel.Rampage && difficulty > 4.5f) || difficulty > 6f);
            __instance.gameDesc.CopyTo(gameDesc);
            gameDesc.combatSettings = __instance.combatSettings;
            __instance.propertyMultiplierText.text = "元数据生成倍率".Translate() + " " + gameDesc.propertyMultiplier.ToString("0%");
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(UICombatSettingsDF), "OnMaxDensitySliderChanged")]
        private static bool OnMaxDensitySliderChanged(ref UICombatSettingsDF __instance, float arg0)
        {
            float value = __instance.maxDensitySlider.value;
            if (value < 0.5f)
            {
                __instance.combatSettings.maxDensity = 1f;
            }
            else if (value < 2.5f)
            {
                __instance.combatSettings.maxDensity = 2f;
            }
            else if (value < 3.5f)
            {
                __instance.combatSettings.maxDensity = 3f;
            }
            else if (value < 4.5f)
            {
                __instance.combatSettings.maxDensity = 4f;
            }
            else if (value < 5.5f)
            {
                __instance.combatSettings.maxDensity = 5f;
            }
            else
            {
                __instance.combatSettings.maxDensity = 6f;
            }
            __instance.UpdateUIParametersDisplay();
            return false;
        }

        [HarmonyPrefix]
		[HarmonyPatch(typeof(UICombatSettingsDF), "OnInitLevelSliderChanged")]
		private static bool OnInitLevelSliderChanged(ref UICombatSettingsDF __instance, float arg0)
		{
            float value = __instance.initLevelSlider.value;
            if (value < 0.5f)
            {
                __instance.combatSettings.initialLevel = 0f;
            }
            else if (value < 1.5f)
            {
                __instance.combatSettings.initialLevel = 1f;
            }
            else if (value < 3.5f)
            {
                __instance.combatSettings.initialLevel = 3f;
            }
            else if (value < 6.5f)
            {
                __instance.combatSettings.initialLevel = 6f;
            }
            else if (value < 10.5f)
            {
                __instance.combatSettings.initialLevel = 10f;
            }
            else if (value < 12.5f)
            {
                __instance.combatSettings.initialLevel = 12f;
            }
            else if (value < 15.5f)
            {
                __instance.combatSettings.initialLevel = 15f;
            }
            else if (value < 18.5f)
            {
                __instance.combatSettings.initialLevel = 18f;
            }
            else if (value < 21.5f)
            {
                __instance.combatSettings.initialLevel = 21f;
            }
            else if (value < 24.5f)
            {
                __instance.combatSettings.initialLevel = 24f;
            }
            else
            {
                __instance.combatSettings.initialLevel = 30f;
            }
            __instance.UpdateUIParametersDisplay();
            return false;
		}

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UICombatSettingsDF), "_OnOpen")]
        public static void _OnOpen(ref UICombatSettingsDF __instance)
        {
            __instance.initLevelSlider.maxValue = 30f;
            __instance.maxDensitySlider.maxValue = 6f;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(StarGen), "CreateStar")]
        [HarmonyPatch(typeof(StarGen), "CreateBirthStar")]
        public static void ClampHiveCount(ref StarData __result)
        {
            __result.maxHiveCount = Mathf.Clamp(__result.maxHiveCount, 0, 8);
            __result.initialHiveCount = Mathf.Clamp(__result.initialHiveCount, 0, 8);
        }
    }
}
