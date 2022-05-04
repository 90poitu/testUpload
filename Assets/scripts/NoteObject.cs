using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed, IsLastNote;

    public GameObject hitEffect, goodEffect, perfectEffect, missedEffect;

    public KeyCode keyToPress;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > .25f)
                {
                    GameManager.instance.NormalHit();
                    Debug.Log("Hit");
                    GameObject hit = Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > .05f)
                {
                    GameObject hit = Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("Good Hit");
                    GameManager.instance.GoodHit();
                }
                else
                {
                    GameObject hit = Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed= true;

            if (IsLastNote)
            {
                GameManager.instance.theMusic.Stop();
                GameManager.instance.calculateScore();
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator") && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            GameObject hit = Instantiate(missedEffect, transform.position, missedEffect.transform.rotation);
        }
    }
}
