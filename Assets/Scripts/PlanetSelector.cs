using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
[Serializable]
public class PlanetSelection
{
    public int x;
    public int y;
    public int pelletsRequired;
    public Color color;
    //Terrain Generator values
    public HeightMapSettings heightMapSettings;
    public MeshSettings mesh;
    public TextureData textures;
    //Planet Generator values
    public ColourSettings planetColour;
    public ShapeSettings planetShape;


    //in future this will also store the data required to generate the planet once the player travels there...
    public PlanetSelection(int x, int y, int pelletsRequired, Color color, HeightMapSettings heightMap, MeshSettings mesh, TextureData textures, ColourSettings planetColour, ShapeSettings planetShape)
    {
        this.x = x;
        this.y = y;
        this.pelletsRequired = pelletsRequired;
        this.color = color;
        this.heightMapSettings = heightMap;
        this.mesh = mesh;
        this.textures = textures;
        this.planetColour = planetColour;
        this.planetShape = planetShape;
    }
    public Color GetColor()
    {
        return color;
    }
}
public class PlanetSelector : MonoBehaviour
{
    int targetX;
    int targetY;
    public GameObject xPointer;
    public GameObject yPointer;
    public GameObject finalPointer;
    public List<PlanetSelection> planets;
    List<GameObject> planetDisplay;
    public GameObject planetDisplayPrefab;
    public Planet planetDisplayStand;
    PlanetSelection selectedPlanet;
    public TextMeshProUGUI selectedPlanetDisplayText;
    public GameObject selectedPlanetArea;
    public PlayerStats playerStats;
    private GameObject selectedPlanetDisplay;

    //Planet Values
    // Start is called before the first frame update
    void Start()
    {
        planetDisplay = new List<GameObject>();
        foreach(PlanetSelection p in planets){
            GameObject newPlanetDisplay = Instantiate(planetDisplayPrefab, this.transform);
            planetDisplay.Add(newPlanetDisplay);
            newPlanetDisplay.transform.localPosition = new Vector3(p.x, p.y, 0);
            newPlanetDisplay.GetComponent<MeshRenderer>().material.color = p.GetColor();
        }
        selectedPlanet = null;
    }

    // Update is called once per frame
    void Update()
    {
        xPointer.transform.localPosition = new Vector3(targetX, 10.5f, 0);
        yPointer.transform.localPosition = new Vector3(10.5f, targetY, 0);
        finalPointer.transform.localPosition = new Vector3(targetX, targetY, 0);
    }
    public void XButtonPressed(bool isPos) {
        int moveBy = (isPos ? 1 : -1);
        targetX += moveBy;
        targetX = Math.Clamp(targetX, -9, 9);
    }
    public void YButtonPressed(bool isPos)
    {
        int moveBy = (isPos ? 1 : -1);
        targetY += moveBy;
        targetY = Math.Clamp(targetY, -9, 9);
    }
    public void SelectPlanetPressed()
    {
        selectedPlanet = null;
        selectedPlanetDisplayText.text = "No Planet Selected";
        Destroy(selectedPlanetDisplay);
        foreach(PlanetSelection p in planets)
        {
            if (p.x == targetX && p.y == targetY)
            {
                selectedPlanet = p;
            }
        }
        if(selectedPlanet == null)
        {
            planetDisplayStand.HidePlanet();
            return;
        }
        planetDisplayStand.ShowPlanet();
        planetDisplayStand.colourSettings = selectedPlanet.planetColour;
        planetDisplayStand.shapeSettings = selectedPlanet.planetShape;
        planetDisplayStand.GeneratePlanet();
        if (selectedPlanet.pelletsRequired <= playerStats.GetInformationPellets())
        {
            selectedPlanetDisplayText.text = "Selected Planet!";
        }
        else
        {
            selectedPlanetDisplayText.text = "Planet locket! not enough information pellets";

        }
    }
    public PlanetSelection GetSelectedPlanet() // called by the airlock when spawning in world, returning null means the airlock does not open
    {
        if(selectedPlanet.pelletsRequired <= playerStats.GetInformationPellets())
        {
            return selectedPlanet;
        }
        else
        {
            return null;
        }
    }
}
