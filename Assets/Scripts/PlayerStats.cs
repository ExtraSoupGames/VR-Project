using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI pelletsText;
    private int informationPellets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pelletsText.text = "Information Pellets: " + informationPellets;
    }
    public void AddInformationPellets(int numToAdd)
    {
        informationPellets += numToAdd;
    }
    public int GetInformationPellets()
    {
        return informationPellets;
    }
}
