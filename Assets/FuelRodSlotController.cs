using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FuelRodSlotController : MonoBehaviour
{
    public Transform attachTransform;
    public PlayerStats playerStats;
    public XRSocketInteractor fuelRodSlotInteractor;
    private IXRSelectInteractable attachedObject;
    public GameObject ParticlePrefab;
    public AudioClip FuelRodSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyAttached()
    {
        if (fuelRodSlotInteractor.interactablesSelected.Count > 0)
        {
            attachedObject = fuelRodSlotInteractor.interactablesSelected[0];
        }
        XRBaseInteractable fuelRod = (XRBaseInteractable)attachedObject;
        Destroy(fuelRod.gameObject);
        GameObject particles = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity, this.transform.parent);
        particles.GetComponent<AudioSource>().clip = FuelRodSound;
        //TODO particles
        playerStats.AddFuel(100);
    }
}
