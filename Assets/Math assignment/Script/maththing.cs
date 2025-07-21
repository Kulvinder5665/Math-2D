using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maththing : MonoBehaviour
{
    public Transform pointA, pointB;
     public  float scalarProj; // a.normalize * b  (One needed to to be normalized)
     Vector2 vectorProj; // a.normalize( a.normalize * b) or a.normalize * scalar projection;
    void OnDrawGizmos()
    {

        Vector2 a = pointA.position;
        Vector2 b = pointB.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, a);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(default, b);

        // Normalizing Manual Version
        // float aLeng=  Mathf.Sqrt((a.x* a.x)  + (a.y *a.y) ); // Best option
        // Vector2 aNorm = a/aLenghth;
        //float aLenghth = a.magnitude; 

        // Qucik and eassy version
       //Normalize A and B
        Vector2 aNorm = a.normalized;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aNorm,0.1f);

        Vector2 bNorm = b.normalized;
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(bNorm,0.1f);


        // Scalar projection
        scalarProj = Vector2.Dot(aNorm, b);
        // Vector Projection
        vectorProj =  aNorm * scalarProj ; // use to place items or get thr distance 
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(vectorProj,0.05f);
    }
}
