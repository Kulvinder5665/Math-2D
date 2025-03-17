using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Drive player;
     Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

   
    void Update()
    {
        
    }

    void LateUpdate(){
            FollowPlayer();        
    }
    void FollowPlayer(){
        transform.position = player.transform.position + offset;
    }
}
