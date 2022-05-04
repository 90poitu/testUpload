using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    //public GameManager gameManager;
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }
}
