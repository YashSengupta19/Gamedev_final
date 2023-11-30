using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    
    public isGrappling grapleTval;
    private Transform player; //Getting a reference to the player's transform
    private Vector3  tempPos; // Temporary position of the camera

    // Start is called before the first frame update
    void Start()
    {
        // Inorder to get the player's transform we use something called findWithTag
        // So we select the player and make its Tag-->Player.
        player = GameObject.FindWithTag("Player").transform; // Find a game object with the specified tag.
        // The function findWithTag will go inside the scene and look for a game object which has a tag that we 
        // specify.

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp (KeyCode.Mouse0))
        {
            tempPos = transform.position;
            float CameraPosition = transform.position.x;
            float PlayerPosition = player.transform.position.x;
            {
                if(CameraPosition > PlayerPosition)
                {
                    CameraPosition -= (float)200000000* Time.deltaTime;
                }

                if(CameraPosition < PlayerPosition)
                {
                    CameraPosition += (float)200000000 * Time.deltaTime;
                }
            }
            tempPos.x = CameraPosition;
            transform.position = tempPos;
            
        }
        if(grapleTval.isGrappling2 == false || grapleTval.isGrappling3 == false)
        {tempPos = transform.position; //Position of the camera
        tempPos.x = player.position.x ;

        // This statement is used to access the bottom left corner of the camera. This takes into assumption
        // that we attach this script on our camera object. Otherwise we will have to get reference to the main Camera.

        Vector3 bottomleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0,Camera.main.nearClipPlane));
        Vector3 topright = Camera.main.ViewportToWorldPoint(new Vector3(1, 1,Camera.main.nearClipPlane));

        float upperThreshhold = topright.y - (float)1.5;
        float lowerThreshhold = bottomleft.y + (float)1.5;

        if(player.position.y >= upperThreshhold) tempPos.y += (float)20 * Time.unscaledDeltaTime;
        if(player.position.y <= lowerThreshhold) tempPos.y -= (float)20 * Time.unscaledDeltaTime;

        transform.position = tempPos; //Position of camera = tempPos
        }

        if(grapleTval.isGrappling2 == true || grapleTval.isGrappling3 == true)
        {
            tempPos = transform.position; //Position of the camera
        //tempPos.x = player.position.x ;

        // This statement is used to access the bottom left corner of the camera. This takes into assumption
        // that we attach this script on our camera object. Otherwise we will have to get reference to the main Camera.

        Vector3 bottomleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0,Camera.main.nearClipPlane));
        Vector3 topright = Camera.main.ViewportToWorldPoint(new Vector3(1, 1,Camera.main.nearClipPlane));

        float upperThreshhold = topright.y - (float)5;
        float lowerThreshhold = bottomleft.y + (float)5;

        if(player.position.y >= upperThreshhold) tempPos.y += (float)20 * Time.unscaledDeltaTime;
        if(player.position.y <= lowerThreshhold) tempPos.y -= (float)20 * Time.unscaledDeltaTime;

        transform.position = tempPos; //Position of camera = tempPos
        }

    }
}
