using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationBox : MonoBehaviour
{
    bool showingInformation;
    public GameObject InformationUI;
    void Start()
    {
        showingInformation = false;
    }
    public void ToggleInformation() // called when selected
    {
        showingInformation = !showingInformation;
        UpdateInformation();
    }
    private void UpdateInformation()
    {
        InformationUI.SetActive(showingInformation);
    }
}
