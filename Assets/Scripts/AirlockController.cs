using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockController : MonoBehaviour
{
    public GameObject outerDoor;
    private int outerDoorClosedX;
    private int outerDoorOpenX;
    public GameObject innerDoor;
    private int innerDoorClosedX;
    private int innerDoorOpenX;
    private float movementSpeed;

    public TerrainGenerator terrainGenerator;
    public HeightMapSettings heightMapSettings;
    enum AirlockState
    {
        OpenInside,
        OpenOutside,
        Closed
    }
    AirlockState state;
    bool renderingOutside;
    // Start is called before the first frame update
    void Start()
    {
        outerDoorClosedX = 0;
        outerDoorOpenX = 5;
        innerDoorClosedX = 0;
        innerDoorOpenX = 5;
        movementSpeed = 3f;
        state = AirlockState.Closed;
        renderingOutside = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case AirlockState.OpenInside:
                if(outerDoor.transform.localPosition.x == outerDoorClosedX)
                {
                    if(innerDoor.transform.localPosition.x != innerDoorOpenX)
                    {
                        OpenInnerDoor();
                    }
                    else
                    {
                        //done
                    }
                }
                else
                {
                    CloseOuterDoor();
                }
                break;
            case AirlockState.OpenOutside:
                if(innerDoor.transform.localPosition.x == innerDoorClosedX)
                {
                    if(outerDoor.transform.localPosition.x != outerDoorOpenX)
                    {
                        OpenOuterDoor();
                    }
                    else
                    {
                        //done
                    }
                }
                else
                {
                    CloseInnerDoor();
                }
                break;
            case AirlockState.Closed:
                if(innerDoor.transform.localPosition.x != innerDoorClosedX)
                {
                    CloseInnerDoor();
                }
                if(outerDoor.transform.localPosition.x != outerDoorClosedX)
                {
                    CloseOuterDoor();
                }
                else
                {
                    //if the outer door is closed already, then we can stop rendering the outside
                    if (renderingOutside)
                    {
                        renderingOutside = false;
                        DestroyTerrain();
                    }
                }
                break;
        }
    }
    private void OpenInnerDoor()
    {
        float difference = innerDoorOpenX - innerDoor.transform.localPosition.x;
        innerDoor.transform.localPosition += new Vector3(Mathf.Clamp(difference, -movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime), 0, 0);
    }
    private void CloseInnerDoor()
    {
        float difference = innerDoorClosedX - innerDoor.transform.localPosition.x;
        innerDoor.transform.localPosition += new Vector3(Mathf.Clamp(difference, -movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime), 0, 0);
    }
    private void OpenOuterDoor()
    {
        float difference = outerDoorOpenX - outerDoor.transform.localPosition.x;
        outerDoor.transform.localPosition += new Vector3(Mathf.Clamp(difference, -movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime), 0, 0);
    }
    private void CloseOuterDoor()
    {
        float difference = outerDoorClosedX - outerDoor.transform.localPosition.x;
        outerDoor.transform.localPosition += new Vector3(Mathf.Clamp(difference, -movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime), 0, 0);

    }
    public void OpenInnerDoorPressed()
    {
        if(state == AirlockState.Closed)
        {
            state = AirlockState.OpenInside;
        }
    }
    public void CloseInnerDoorPressed()
    {
        if(state == AirlockState.OpenInside)
        {
            state = AirlockState.Closed;
        }
    }
    public void OpenOuterDoorPressed()
    {
        if(state == AirlockState.Closed)
        {
            state = AirlockState.OpenOutside;
            GenerateTerrain();
            renderingOutside = true;
        }
    }
    public void CloseOuterDoorPressed() 
    {
        if(state == AirlockState.OpenOutside)
        {
            state = AirlockState.Closed;
        }
    }
    public void GenerateTerrain()
    {
        terrainGenerator.heightMapSettings = heightMapSettings;
        terrainGenerator.CreateTerrain();
    }
    public void DestroyTerrain()
    {
        terrainGenerator.DestroyTerrain();
    }
}
