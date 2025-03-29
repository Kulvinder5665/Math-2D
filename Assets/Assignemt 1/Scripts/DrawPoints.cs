using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoints 
{
      float x ;
   float y; 
   float z;
    
    public  DrawPoints(float _x, float _y){
        x=_x;
        y=_y;
        z=-1;

    }
    public override string ToString()
    {
        return "(" + x +"," +y +"," + z+")";
    }

    static  public GameObject DrawPoint( DrawPoints position , float width,Color color ){
        GameObject line = new GameObject("Point_" + position.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = color;
        lineRenderer.positionCount= 2;
        lineRenderer.SetPosition(0, new Vector3(position.x- width/3.0f, position.y- width/3.0f, position.z));
        lineRenderer.SetPosition(1, new Vector3(position.x +width/3.0f, position.y+ width/3.0f, position.z));
        lineRenderer.startWidth= width;
        lineRenderer.endWidth = width;
        return line;
    }
    
}
