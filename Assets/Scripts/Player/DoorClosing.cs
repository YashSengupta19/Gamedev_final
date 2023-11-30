using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public Lever2 L;
    public bool bouldertrigger= false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "DoorClosingCollider")
        {
            if (L != null)
            {
                L.isCollision = false; // Assuming Lever2 has a public variable named isCollsion
                bouldertrigger = true;
            }
            else
            {
                Debug.LogWarning("Lever2 reference is missing.");
            }
        }
    }
}
