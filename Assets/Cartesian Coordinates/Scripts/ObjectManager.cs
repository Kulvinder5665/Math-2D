using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Vector3 objPosition;


    // Start is called before the first frame update
     void Awake() {
        
    
    
        GameObject obj = Instantiate(ObjectPrefab,new Vector3( Random.Range(-100,100),Random.Range(100,-100), 0), Quaternion.identity);
        objPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
