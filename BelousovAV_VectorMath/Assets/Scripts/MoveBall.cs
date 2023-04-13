using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    private float _minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    private Vector3 _initialVelocity = new Vector3(0, 0, 10);

    private void Start()
    {
        
    }
    private void OnEnable()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.velocity += _initialVelocity;

    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
        var layerMask = collision.gameObject.layer;
        if (layerMask == 3)
        {
            GameManager._countOfPoints++;
            Destroy(collision.gameObject);


            // елси уничтожило 10 обЪектов то переход на следующий уровень сложности
        }
        if (layerMask == 7)
        {
            Destroy(this.gameObject);
            //StartBall.Che
        }


    }

    private void Bounce(Vector3 collisionNormal)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, _minVelocity);
    }
}
