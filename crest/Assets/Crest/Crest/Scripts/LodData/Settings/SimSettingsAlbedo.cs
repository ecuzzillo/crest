﻿// Crest Ocean System

// This file is subject to the MIT License as seen in the root of this folder structure (LICENSE)

using UnityEngine;

namespace Crest
{
    [CreateAssetMenu(fileName = "SettingsAlbedo", menuName = "Crest/Albedo Settings", order = 10000)]
    [CrestHelpURL("user/ocean-simulation", "albedo")]
    public class SimSettingsAlbedo : SimSettingsBase
    {
        /// <summary>
        /// The version of this asset. Can be used to migrate across versions. This value should
        /// only be changed when the editor upgrades the version.
        /// </summary>
        [SerializeField, HideInInspector]
#pragma warning disable 414
        int _version = 0;
#pragma warning restore 414

        /// <summary>
        /// Resolution control. Set higher for sharper results, at the cost of increased memory usage.
        /// </summary>
        [Delayed]
        public int _resolution = 768;

        public override void AddToSettingsHash(ref int settingsHash)
        {
            base.AddToSettingsHash(ref settingsHash);
            Hashy.AddInt(_resolution, ref settingsHash);
        }
    }
}
