using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteSpeed : MonoBehaviour
{
    public beatScroller BS;
    void Start()
    {
        BS = GameObject.FindGameObjectWithTag("NoteHolder").GetComponent<beatScroller>();
    }
    void Update()
    {
        transform.position -= new Vector3(0, BS.beatTempo * Time.deltaTime, 0);
    }
}
