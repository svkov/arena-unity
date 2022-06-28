using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicking : MonoBehaviour
{
    public Item item;
    public GameObject graphics;
    public GameObject hint;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            hint.GetComponent<Hint>().ShowHint();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            hint.GetComponent<Hint>().HideHint();
        }
    }

}
