using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float speed;
    private float maxDistance;
    private float currentDistance;
    private float stPoint;

    private void Start()
    {
        stPoint = transform.position.x;
    }
    public void Create(float s, float d)
    {
        speed = s;
        maxDistance = d;
        
    }

    private void Update()
    {

        currentDistance = Mathf.Abs( Mathf.Abs(transform.position.x) - Mathf.Abs(stPoint));

        if (currentDistance >= maxDistance)
            Destroy(gameObject);

        transform.Translate(Vector3.right * speed);
       

       
    }

}
