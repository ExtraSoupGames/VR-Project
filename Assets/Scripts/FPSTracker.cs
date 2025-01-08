using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSTracker : MonoBehaviour
{
    public TextMeshProUGUI text;
    double timeSinceLastUpdate;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastUpdate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if(timeSinceLastUpdate > 0.1)
        {
            text.text = "FPS: " + ((int)(1 / Time.deltaTime)).ToString();
            timeSinceLastUpdate = 0;
        }
    }
}
