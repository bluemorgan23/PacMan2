using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public bool receiving = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!receiving)
        {
            otherPortal.receiving = true;
            
        }
        receiving = false;
    }
}
