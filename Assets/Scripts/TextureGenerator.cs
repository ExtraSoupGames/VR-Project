﻿﻿using UnityEngine;
using System.Collections;

public static class TextureGenerator {

	public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height) {
		Texture2D texture = new Texture2D (width, height);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.SetPixels (colourMap);
		texture.Apply ();
		return texture;
	}


	public static Texture2D TextureFromHeightMap(HeightMap heightMap) {
		int texWidth = heightMap.values.GetLength (0);
		int texHeight = heightMap.values.GetLength (1);

		Color[] colourMap = new Color[texWidth * texHeight];
		for (int y = 0; y < texHeight; y++) {
			for (int x = 0; x < texWidth; x++) {
				colourMap [y * texWidth + x] = Color.Lerp (Color.black, Color.white, Mathf.InverseLerp(heightMap.minValue,heightMap.maxValue,heightMap.values [x, y]));
			}
		}

		return TextureFromColourMap (colourMap, texWidth, texHeight);
	}

}