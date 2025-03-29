using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using Unity.UI;
using TMPro;
// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    private float FuelAmount ;
    float distance;
    private UIManager uiManager;
    float fuelConsumptionRate= 0.1f;
    GameObject fuelObject;
     bool isMoving;
     float startDistance;
     float currentDistance;

    void Start()
    {
        fuelObject = GameObject.FindGameObjectWithTag("Fuel");
      uiManager = FindAnyObjectByType<UIManager>();
      distance = uiManager.DitanceCalacution();
      FuelAmount = distance;
      startDistance= distance;
    }
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
       isMoving =  Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!=0;
       currentDistance = Vector2.Distance(transform.position, fuelObject.transform.position);

       if(FuelAmount> 0){
      
   //    this.transform.position = Vector2.MoveTowards(this.transform.position,fuelObject.transform.position, speed*Time.deltaTime);
      
          uiManager.FuelAmounttext.text = FuelAmount.ToString();
          Move();
       }

        
    }

    void Move()
    {
        if(isMoving){

 FuelAmount = (currentDistance / startDistance) * startDistance;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
          FuelAmount -=  fuelConsumptionRate; 
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);
        }
    }
}