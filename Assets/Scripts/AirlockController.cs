using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockController : MonoBehaviour
{
    public GameObject outerDoor;
    public GameObject innerDoor;
    enum AirlockState
    {
        OpenInside,
        OpenOutside,
        Closed
    }
    AirlockState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
