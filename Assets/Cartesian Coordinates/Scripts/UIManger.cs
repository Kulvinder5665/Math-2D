using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    public GameObject tank;
    public GameObject fuel;

    public TextMeshProUGUI tankPos, FuelPos, distance;
    
    private ObjectManager objectManager;
    // Start is called before the first frame update
    void Start()
    {
       objectManager = fuel.GetComponent<ObjectManager>();
        tankPos.text = tank.transform.position + "";
        FuelPos.text = objectManager.objPosition+ "";
      //  distance.text= 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
