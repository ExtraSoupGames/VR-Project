﻿using UnityEngine;
using System.Collections;

public class MapPreview : MonoBehaviour {

	public Renderer textureRender;
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;


	public enum RenderMode { NoiseMap, Mesh, FalloffMap };
    public RenderMode renderMode;

	public MeshSettings meshSettings;
	public HeightMapSettings heightMapSettings;
	public TextureData textureData;

	public Material terrainMaterial;



	[Range(0,MeshSettings.numSupportedLODs-1)]
	public int PreviewLOD;
	public bool enableautoUpdate;




	public void RenderMapInEditor() {
		textureData.ApplyToMaterial (terrainMaterial);
		textureData.UpdateMeshHeights (terrainMaterial, heightMapSettings.minHeight, heightMapSettings.maxHeight);
		HeightMap heightMap = HeightMapGenerator.CreateHeightMap (meshSettings.vertsPerLine, meshSettings.vertsPerLine, heightMapSettings, Vector2.zero);

		if (renderMode == RenderMode.NoiseMap) {
			RenderTexture (TextureGenerator.TextureFromHeightMap (heightMap));
		} else if (renderMode == RenderMode.Mesh) {
			RenderMesh (MeshGenerator.CreateTerrainMesh (heightMap.values,meshSettings, PreviewLOD));
		} else if (renderMode == RenderMode.FalloffMap) {
			RenderTexture(TextureGenerator.TextureFromHeightMap(new HeightMap(TerrainFalloff.CreateFalloffMap(meshSettings.vertsPerLine),0,1)));
		}
	}





	public void RenderTexture(Texture2D texture) {
		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3 (texture.width, 1, texture.height) /10f;

		textureRender.gameObject.SetActive (true);
		meshFilter.gameObject.SetActive (false);
	}

	public void RenderMesh(MeshDetails MeshDetails) {
		meshFilter.sharedMesh = MeshDetails.MakeMesh ();

		textureRender.gameObject.SetActive (false);
		meshFilter.gameObject.SetActive (true);
	}



	void OnValuesUpdated() {
		if (!Application.isPlaying) {
			RenderMapInEditor ();
		}
	}

	void OnTextureValuesUpdated() {
		textureData.ApplyToMaterial (terrainMaterial);
	}

	void OnValidate() {

		if (meshSettings != null) {
			meshSettings.OnValuesUpdated -= OnValuesUpdated;
			meshSettings.OnValuesUpdated += OnValuesUpdated;
		}
		if (heightMapSettings != null) {
			heightMapSettings.OnValuesUpdated -= OnValuesUpdated;
			heightMapSettings.OnValuesUpdated += OnValuesUpdated;
		}
		if (textureData != null) {
			textureData.OnValuesUpdated -= OnTextureValuesUpdated;
			textureData.OnValuesUpdated += OnTextureValuesUpdated;
		}

	}

}