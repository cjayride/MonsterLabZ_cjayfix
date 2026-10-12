using System.Collections.Generic;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace MonsterLabZ
{
    public static class SpiderVolume
    {
        internal static ConfigEntry<float> VolumeEntry;

        static readonly HashSet<string> HitAndDeathClips = new HashSet<string>
        {
            "sfx_spider_hit",
            "sfx_spider_death",
            "sfx_spiderboss_hit",
            "sfx_spiderboss_death",
            "sfx_spideregg_hit",
            "sfx_spideregg_death",
        };

        public static void Init(ConfigFile config)
        {
            VolumeEntry = config.Bind(
                "Spider Sounds",
                "Volume",
                0.35f,
                "Volume of spider hit and death sounds, including Frigga and spider eggs. 1 is full volume. 0.35 is 35%.");
            new Harmony("MonsterLabZ.SpiderVolume").PatchAll(typeof(SpiderSoundPatch));
            BepInEx.Logging.Logger.CreateLogSource("MonsterLabZ").LogInfo("Spider hit and death volume is " + Volume.ToString("0.###") + ".");
        }

        internal static float Volume
        {
            get
            {
                float volume = VolumeEntry == null ? 0.35f : VolumeEntry.Value;
                if (volume < 0f)
                    return 0f;
                return volume;
            }
        }

        internal static bool IsHitOrDeath(string clipName)
        {
            return clipName != null && HitAndDeathClips.Contains(clipName);
        }
    }

    [HarmonyPatch(typeof(ZSFX), nameof(ZSFX.Play))]
    static class SpiderSoundPatch
    {
        static void Postfix(ZSFX __instance)
        {
            AudioSource source = __instance.GetComponent<AudioSource>();
            if (source == null || source.clip == null)
                return;
            if (SpiderVolume.Volume >= 0.999f || !SpiderVolume.IsHitOrDeath(source.clip.name))
            {
                __instance.SetVolumeModifier(1f);
                return;
            }

            __instance.SetVolumeModifier(SpiderVolume.Volume);
            source.volume *= SpiderVolume.Volume;
        }
    }
}
