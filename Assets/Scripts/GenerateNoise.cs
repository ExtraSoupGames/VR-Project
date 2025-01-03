﻿using UnityEngine;

public static class NoiseGenerator {

    public enum NormalizeMode { Local, Global };

    public static float[,] CreateNoiseMap(int width, int height, NoiseConfig config, Vector2 center) {
        float[,] map = new float[width, height];

        System.Random random = new System.Random(config.seed);
        Vector2[] offsets = new Vector2[config.octaves];

        float maxPossibleHeight = 0;
        float amplitude = 1;
        float frequency = 1;

        for (int i = 0; i < config.octaves; i++) {
            float offsetX = random.Next(-100000, 100000) + config.offset.x + center.x;
            float offsetY = random.Next(-100000, 100000) - config.offset.y - center.y;
            offsets[i] = new Vector2(offsetX, offsetY);

            maxPossibleHeight += amplitude;
            amplitude *= config.persistence;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {

                amplitude = 1;
                frequency = 1;
                float currentHeight = 0;

                for (int i = 0; i < config.octaves; i++) {
                    float sampleX = (x - halfWidth + offsets[i].x) / config.scale * frequency;
                    float sampleY = (y - halfHeight + offsets[i].y) / config.scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    currentHeight += perlinValue * amplitude;

                    amplitude *= config.persistence;
                    frequency *= config.lacunarity;
                }

                if (currentHeight > maxNoiseHeight) {
                    maxNoiseHeight = currentHeight;
                } 
                if (currentHeight < minNoiseHeight) {
                    minNoiseHeight = currentHeight;
                }

                map[x, y] = currentHeight;

                if (config.normalizeMode == NormalizeMode.Global) {
                    float normalizedHeight = (map[x, y] + 1) / (maxPossibleHeight / 0.9f);
                    map[x, y] = Mathf.Clamp(normalizedHeight, 0, int.MaxValue);
                }
            }
        }

        if (config.normalizeMode == NormalizeMode.Local) {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
                }
            }
        }

        return map;
    }
}

[System.Serializable]
public class NoiseConfig {
    public NoiseGenerator.NormalizeMode normalizeMode;

    public float scale = 50;

    public int octaves = 6;
    [Range(0, 1)]
    public float persistence = .6f;
    public float lacunarity = 2;

    public int seed;
    public Vector2 offset;

    public void EnsureValidValues() {
        scale = Mathf.Max(scale, 0.01f);
        octaves = Mathf.Max(octaves, 1);
        lacunarity = Mathf.Max(lacunarity, 1);
        persistence = Mathf.Clamp01(persistence);
    }
}