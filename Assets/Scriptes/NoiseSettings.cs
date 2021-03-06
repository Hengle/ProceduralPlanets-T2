﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // to show values in inspector
public class NoiseSettings
{
    public enum FilterType { Simple , Ridged };
    public FilterType filterType;

    [ConditionalHide("filterType",0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RidgedNoiseSettings ridgedNoiseSettings;

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        public float strength = 1f;
        [Range(1, 8)]
        public int numLayers = 1;  // number of noise layers to be added to gether
        public float baseRoughness = 1f;
        public float roughness = 2f;
        public float presistance = 0.5f; // when presistance is less than one amplitude will deecrease , for example here amplitude will be halfed
        public Vector3 center;
        public float minValue; // to allow us to minimize noiseValue less than zero to be on planet surface(water)
    }

    [System.Serializable]
    public class RidgedNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultipier = 0.8f;
    }
}
