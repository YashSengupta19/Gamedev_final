using UnityEngine;

public class HoverDetection : MonoBehaviour
{
    // Called when the mouse enters the collider
    public isGrappling grapleTval;
    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered the collider!");
        // Do something when the mouse enters the collider
        grapleTval.isGrappling3 = true;
    }

    // Called when the mouse exits the collider
    private void OnMouseExit()
    {
        Debug.Log("Mouse exited the collider!");
        // Do something when the mouse exits the collider
        grapleTval.isGrappling3 = false;
    }
}