﻿using UnityEngine;
using System.Collections;

public static class TerrainFalloff {

    public static float[,] CreateFalloffMap(int dimension) {
        float[,] falloffMap = new float[dimension, dimension];

        for (int row = 0; row < dimension; row++) {
            for (int col = 0; col < dimension; col++) {
                float horizontal = row / (float)dimension * 2 - 1;
                float vertical = col / (float)dimension * 2 - 1;

                float maxAxis = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));
                falloffMap[row, col] = CalculateFalloff(maxAxis);
            }
        }

        // Invert the falloff map values
        for (int row = 0; row < dimension; row++) {
            for (int col = 0; col < dimension; col++) {
                falloffMap[row, col] = 1f - falloffMap[row, col]; // Invert the values
            }
        }

        return falloffMap;
    }

    static float CalculateFalloff(float input) {
        float alpha = 3f;
        float beta = 2.2f;

        return Mathf.Pow(input, alpha) / (Mathf.Pow(input, alpha) + Mathf.Pow(beta - beta * input, alpha));
    }
}