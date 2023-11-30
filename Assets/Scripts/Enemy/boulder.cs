using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
