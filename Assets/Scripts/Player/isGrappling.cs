using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isGrappling : MonoBehaviour
{
    public bool isGrappling1 = false; // Activated when pressing Q to activate the Grappling mode;
    // After activating the grappling mode, we can aim & upon proper aim, we can grapple 
    public bool isGrappling2; // Activated when the mouse pointer is at a certain distance from player

    public bool isGrappling3; // Activated when the player is in range to throw the grapple and 
                              // provides the signal for the Grappling code.
    public Image Reddot;
    public Image Greendot;
    public KeyCode activationKey = KeyCode.Q; // This is basically the key code. The aiming system will come only when we press the Q button.

    // Now we need to decide the range where we can throw our grapple.
    private Transform player;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Getting the transform of the player.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Set z to 0 for 2D positioning

        // Set the red dot position to the mouse position
        Reddot.transform.position = mousePosition;
        Greendot.transform.position = mousePosition;

        if (Input.GetKeyDown(activationKey))
        {
            isGrappling1 = !isGrappling1;
        }

        if (isGrappling1)
        {
            //reddot.enabled = true;
            Vector3 playerPosition = player.position;

            // Corrected typo: Vector3.Distance instead of Vector3.distance
            if (Vector3.Distance(playerPosition, mousePosition) <= 20)
            {
                
                isGrappling2 = true;
                
            }
            else
            {
                
                isGrappling2 = false;
            }
        }
        else
        {
            isGrappling2 = false;
        }
    }
}
