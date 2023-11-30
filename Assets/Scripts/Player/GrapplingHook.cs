using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrapplingHook: MonoBehaviour
{
public Camera mainCamera;
public isGrappling grapleTval;
public LineRenderer _lineRenderer;
public DistanceJoint2D _Distancejoint;
public Rigidbody2D rb;
public float force;
private Vector3 MouseDir;
public Transform LinePosition;
public bool isGrappling;
// Start is called before the first frame update
void Start()
{
isGrappling = true;
_Distancejoint.autoConfigureDistance = true;
_Distancejoint. enabled= false;
_lineRenderer.enabled = false;
}
// Update is called once per frame
void Update()
{ if (grapleTval.isGrappling2 == true && grapleTval.isGrappling3 == true && grapleTval.isGrappling1 == true) 
{
    grapleTval.Reddot.enabled = false;
    grapleTval.Greendot.enabled = true;
    MouseDir= mainCamera.ScreenToWorldPoint(Input.mousePosition);
    if (isGrappling == true)
    {
    if (Input.GetKeyDown (KeyCode.Mouse0))
    {
        //Cursor.lockState = CursorLockMode.Locked;
    Vector2 mousepos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
    _lineRenderer. SetPosition (0, mousepos);
    _Distancejoint.connectedAnchor= mousepos;
    _Distancejoint.enabled = false;
    LinePosition. position = mousepos;
    }
    if (Input.GetKey(KeyCode. Mouse0))
    {
        _lineRenderer.SetPosition (1, transform. position);
        _lineRenderer.enabled = true;
    }
    else if (Input. GetKeyUp(KeyCode. Mouse0))
    {
        //Cursor.lockState = CursorLockMode.None;
        //grapleTval.isGrappling3 = false;
        _Distancejoint.enabled = false;
        _lineRenderer.enabled = false;
    }
    if (_Distancejoint.enabled)
    {
        _lineRenderer.SetPosition (1, transform. position);
    }
    if (Input. GetKey(KeyCode. E) && Input. GetKey(KeyCode. Mouse0))
    {
        Vector3 Direction = LinePosition.position - transform. position;
        rb. velocity = new Vector2(Direction.x* force, Direction.y* force).normalized * force * Time.deltaTime;
        _Distancejoint.enabled = false;
    }
    if (Input. GetKeyUp (KeyCode. E) && Input. GetKey(KeyCode. Mouse0))
    {
        _Distancejoint.enabled = false;
    }
    }
}

else if (grapleTval.isGrappling2 == false && grapleTval.isGrappling3 == false && grapleTval.isGrappling1 == false)
{
    grapleTval.Reddot.enabled = false;
    grapleTval.Greendot.enabled = false;
}
else if(grapleTval.isGrappling1 == true)
{

    grapleTval.Reddot.enabled = true;
    grapleTval.Greendot.enabled = false;
}
}
}
