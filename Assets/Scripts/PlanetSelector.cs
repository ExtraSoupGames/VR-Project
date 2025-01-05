using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

internal class Planet
{
    public int x;
    public int y;
    int pelletsRequired;
    Color color;
    public Planet(int x, int y, int pelletsRequired, Color color)
    {
        this.x = x;
        this.y = y;
        this.pelletsRequired = pelletsRequired;
        this.color = color;
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
    List<Planet> planets;
    List<GameObject> planetDisplay;
    public GameObject planetDisplayPrefab;
    Planet selectedPLanet;
    public TextMeshProUGUI selectedPlanetDisplayText;
    public GameObject selectedPlanetArea;
    private GameObject selectedPlanetDisplay;
    // Start is called before the first frame update
    void Start()
    {
        planets = new List<Planet> { 
        new Planet(3, 4, 5, new Color(0, 0, 1)),
        new Planet(-3, -4, 10, new Color(0, 1, 0)),
        new Planet(8, -6, 15, new Color(1, 0, 0))};
        planetDisplay = new List<GameObject>();
        foreach(Planet p in planets){
            GameObject newPlanetDisplay = Instantiate(planetDisplayPrefab, this.transform);
            planetDisplay.Add(newPlanetDisplay);
            newPlanetDisplay.transform.localPosition = new Vector3(p.x, p.y, 0);
            newPlanetDisplay.GetComponent<MeshRenderer>().material.color = p.GetColor();
        }
        selectedPLanet = null;
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
        selectedPLanet = null;
        selectedPlanetDisplayText.text = "No Planet Selected";
        Destroy(selectedPlanetDisplay);
        foreach(Planet p in planets)
        {
            if (p.x == targetX && p.y == targetY)
            {
                selectedPLanet = p;
            }
        }
        if(selectedPLanet == null)
        {
            return;
        }
        selectedPlanetDisplayText.text = "Selected Planet!";
        selectedPlanetDisplay = Instantiate(planetDisplayPrefab, selectedPlanetArea.transform);
        selectedPlanetDisplay.GetComponent<MeshRenderer>().material.color = selectedPLanet.GetColor();
        selectedPlanetDisplay.transform.localPosition = new Vector3(0, 3, 0);
    }
}
