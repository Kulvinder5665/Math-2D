using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject fuel;

    public TextMeshProUGUI tankPos, FuelPos, distanceText;
    
    private ObjectManager objectManager;
   public  GameObject fuelSpawnObject;

    void Start()
    {
        // Ensure fuel has the ObjectManager script
        objectManager = fuel.GetComponent<ObjectManager>();
        if (objectManager == null)
        {
            Debug.LogError("ObjectManager script not found on Fuel!");
            return;
        }

        fuelSpawnObject = GameObject.FindGameObjectWithTag("Fuel");

        // Display Positions
        tankPos.text = "Tank Position: " + tank.transform.position;
        FuelPos.text = "Fuel Position: " + fuelSpawnObject.transform.position;

        // Calculate Distance
        

        // Calculate Angle
        float angle = Mathf.Atan2(
            fuelSpawnObject.transform.position.y - tank.transform.position.y, 
            fuelSpawnObject.transform.position.x - tank.transform.position.x
        ) * Mathf.Rad2Deg - 90;

        // Apply Rotation to Tank
        tank.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void Update()
    {
        DitanceCalacution();
    }

    public float DitanceCalacution(){
      float calculatedDistance = Vector2.Distance(tank.transform.position, fuelSpawnObject.transform.position);
        distanceText.text = "Distance: " + calculatedDistance.ToString("F2");
        return calculatedDistance;
    }
}
