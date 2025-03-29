using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectManager : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Vector3 objPosition;
      public     GameObject obj;


    // Start is called before the first frame update
     void Awake() {
        
    
    
        obj = Instantiate(ObjectPrefab,new Vector3( Random.Range(-100,100),Random.Range(100,-100), 0), Quaternion.identity);
        objPosition = obj.transform.position;
    }

   
}
