using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDeleter : MonoBehaviour
{
    public void DeleteMe()
    {
        Destroy(gameObject);
    }
}
