using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        }
    }
    private void OnMouseDown()                   // this will be used when we stretch the ball 
    {
        isPressed = true;
        rb.isKinematic = true;
    
    }
    private void OnMouseUp()                      // this will be used when we release the ball 

    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;


    }
}
