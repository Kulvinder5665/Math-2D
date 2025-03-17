using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    Coords point = new Coords(10,20);
    Coords startPointY = new Coords(0,100);
    Coords endPointY= new Coords(0,-100);

    Coords startPointX = new Coords(190,0);
    Coords endPointX= new Coords(-190,0);

    Coords[] artes ={
                       new Coords(10,20),
                       new Coords(35,18),
                       new Coords(45, 8),
                       new Coords(45,5)
    };

    
    void Start()
    {
        Debug.Log(point.ToString());
        Coords.DrawPoints(new Coords(0,0),2,Color.red);
        Coords.DrawPoints(point,2, Color.green);
        Coords.DrawLines(startPointY,endPointY,1, Color.green);
        Coords.DrawLines(startPointX,endPointX,1,Color.red);

        for (int i =0 ;i < artes.Length;i++ ){
        Coords.DrawPoints(artes[i],2, Color.green);
        }
       

        Coords.DrawLines(artes[0],artes[1],1,Color.white);
        Coords.DrawLines(artes[1],artes[2],1,Color.white);
         Coords.DrawLines(artes[2],artes[3],1,Color.white);
      //  Coords.DrawLines(artes[1],artes[2],1,Color.white);
    }

  
    void Update()
    {
        
    }


}
