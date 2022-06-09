using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    void Update()
    {
        var health = GetComponent<Health>();
        if (health.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
