using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    public  int Size =20;

[SerializeField]
  public  int xMax = 200;
[SerializeField]
    public  int yMax=200;


      Coords  StartPositionXAxis ;
     Coords   endPosXAxis ;
       Coords startPosYAxis ;
        Coords endPosYAxis ;
    // Start is called before the first frame update
    void Start()
    {

      StartPositionXAxis = new Coords(xMax ,0);
        endPosXAxis = new Coords(-xMax ,0);
       startPosYAxis = new Coords(0,yMax);
        endPosYAxis = new Coords(0,-yMax);
         Coords.DrawLines(StartPositionXAxis,endPosXAxis,1,Color.white);
         Coords.DrawLines(startPosYAxis,endPosYAxis,1,Color.white);
         int xoffset = (int )(xMax/(float)Size);
        for(int i = -xoffset*Size; i<= xoffset*Size;i+=Size){
            Coords.DrawLines(new Coords(i,-yMax),new Coords(i,yMax),0.5f,Color.white);

        }
            int yoffset = (int )(100/(float)Size);
        for(int y= -yoffset*Size;y<=yoffset*Size; y+=Size){
          Coords.DrawLines(new Coords(-xMax ,y),new Coords(xMax ,y),0.5f,Color.white);
        }
    }

    // Update is called once per frame
}
