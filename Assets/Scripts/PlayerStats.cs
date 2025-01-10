using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI fuelText;
    private int fuel;
    // Start is called before the first frame update
    void Start()
    {
        //TODO Remove once pellets are obtainable
        fuel = 300;
    }

    // Update is called once per frame
    void Update()
    {
        fuelText.text = "Fuel: " + fuel;
    }
    public void AddFuel(int numToAdd)
    {
        fuel += numToAdd;
    }
    public int GetFuel()
    {
        return fuel;
    }
}
