using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectObject : MonoBehaviour
{
    public float lifetime = 1;
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
