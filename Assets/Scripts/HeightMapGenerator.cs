using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeightMapGenerator {

	public static HeightMap CreateHeightMap(int width, int height, HeightMapSettings settings, Vector2 sampleCentre) {
		float[,] values = NoiseGenerator.CreateNoiseMap (width, height, settings.noiseConfig, sampleCentre);

		AnimationCurve heightCurve_threadsafe = new AnimationCurve (settings.heightCurve.keys);

		float minValue = float.MaxValue;
		float maxValue = float.MinValue;

		// Check if falloff is enabled and create falloff map
    if (settings.useFalloff) {
        float[,] falloffMap = TerrainFalloff.CreateFalloffMap(width);
        
        // Apply falloff map to noise values
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                values[i, j] *= falloffMap[i, j]; // Apply falloff effect to height values
            }
        }
    }

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				values [i, j] *= heightCurve_threadsafe.Evaluate (values [i, j]) * settings.heightMultiplier;

				if (values [i, j] > maxValue) {
					maxValue = values [i, j];
				}
				if (values [i, j] < minValue) {
					minValue = values [i, j];
				}
			}
		}

		return new HeightMap (values, minValue, maxValue);
	}

}

public struct HeightMap {
	public readonly float[,] values;
	public readonly float minValue;
	public readonly float maxValue;

	public HeightMap (float[,] values, float minValue, float maxValue)
	{
		this.values = values;
		this.minValue = minValue;
		this.maxValue = maxValue;
	}
}