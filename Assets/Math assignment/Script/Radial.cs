
using UnityEngine;

public class Radial : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    public Transform player;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);

        // Old Method
       // float currentdistance = Vector2.Distance(this.transform.position, player.position);
       // float Dist = Mathf.Sqrt(((player.position.x-this.transform.position.x)*(player.position.x-this.transform.position.x))
           //                  + ((player.position.y- this.transform.position.y)*(player.position.y- this.transform.position.y)));
        // float Dist = Distance(player.position, this.transform.position);
        // if(Dist<= radius){
        //     Gizmos.color = Color.green;
        //     Gizmos.DrawSphere(transform.position, radius);
        // }else{
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawSphere(transform.position, radius);
        // }

        // Better way by using magnitude

        // finding the direction 
        Vector2 direction = player.transform.position - this.transform.position;
        float distance = direction.sqrMagnitude;
        float squareOfRadius= radius * radius;

        Gizmos.color = distance<= squareOfRadius ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }

// calculte the distance between two points
    public float Distance(Vector2 a, Vector2 b){
        float dx = a.x- b.x;
        float dy = a.y- b.y;
        return  Mathf.Sqrt(dx*dx + dy*dy);
    }
}
