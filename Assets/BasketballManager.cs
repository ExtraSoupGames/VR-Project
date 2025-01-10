using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballManager : MonoBehaviour
{
    public Transform basketball;
    public Transform target;
    public float maxDist;
    public GameObject HoorayParticles;
    private bool won;
    // Start is called before the first frame update
    void Start()
    {
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            float distance = Vector3.Magnitude(basketball.position - target.position);
            Debug.Log(distance);
            if (distance < maxDist)
            {
                Instantiate(HoorayParticles, target.transform, false);
                Destroy(basketball.gameObject);
                won = true;
            }
        }
    }
}
