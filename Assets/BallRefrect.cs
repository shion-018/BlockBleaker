using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRefrect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Rigidbody ball = collision.rigidbody;
            if (ball == null)
            {
                Vector3 C = collision.contacts[0].normal;
                ContactPoint contactPoint = collision.GetContact(0);
                //ball.velocity = Vector3.Reflect(collision.relativeVelocity, contactPoint.normal);
                ball.velocity = Vector3.Reflect(collision.relativeVelocity, C);
            
            }
           
        }
    }
}
