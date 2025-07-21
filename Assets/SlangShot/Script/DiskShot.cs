
using System.Collections;

using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DiskShot : MonoBehaviour
{
    // Variable 
    private Rigidbody2D rb;
    [SerializeField] private float forceMultipler = 5f;
    [SerializeField] private float stopDiskTime = 5f;
    [SerializeField] private float DampingForce = 2.0f;
    [SerializeField] private float maxDragRange = 3f;
    [SerializeField] private Vector2 f;
    Vector2 startPos;
    Vector2 endPos;
    [SerializeField] bool canShoot = true;
    [SerializeField] bool isDraging = false;
    private LineRenderer dragLineRenderer;
    [SerializeField] private LineRenderer futureLineRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dragLineRenderer = GetComponent<LineRenderer>();

        dragLineRenderer.endWidth = 0.1f;
        dragLineRenderer.startWidth = 0.5f;

        dragLineRenderer.positionCount = 2;
        dragLineRenderer.enabled = false;

        futureLineRenderer.positionCount = 2;
        futureLineRenderer.startWidth = 0.5f;
        futureLineRenderer.endWidth = 0.5f;

    }


    void Update()
    {

        if (rb.velocity.magnitude <= 0.01f)
        {
            canShoot = true;
            rb.drag = 0;
        }

        // Check the StartInput pos Input
        if (Input.GetMouseButtonDown(0))
        {
            // using raycast to check if i am colliding with disk
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isDraging = true;
                dragLineRenderer.enabled = true;
                futureLineRenderer.enabled = true;
                Debug.Log($"Clicked on player {startPos}");

                //   Debug.Log($"Start Pos of move {startPos}");
            }


        }
        if (isDraging)
        {
            OnMouseDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
          
            if (isDraging && canShoot)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log($"End Pos of mosue {endPos}");

                Vector2 dragDirection = startPos - endPos;
                //   Debug.Log($" Dir to move {dragDirection}");
                if (dragDirection.magnitude > maxDragRange)
                {
                    dragDirection = dragDirection.normalized * maxDragRange;
                }

                // applying for in the direction of posToMove
                if (rb.velocity.magnitude <= 0.01f)
                {
                    rb.AddForce(dragDirection * forceMultipler, ForceMode2D.Impulse);
                    Debug.Log($" start Applying force {rb.velocity}");
                    canShoot = false;
                    StartCoroutine(StopTheDisk());
                }
                isDraging = false;

                OnRelease();

            }



        }
    }

    IEnumerator StopTheDisk()
    {
        yield return new WaitForSeconds(stopDiskTime);
        rb.drag *= 0.8f;
        //Linear Damping Logic
        //rb.velocity *= (1-)

    }

    void OnMouseDrag()
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dragVector = currentPos - startPos;
       // Vector2 forwardVector = startPos - currentPos;

        if (dragVector.magnitude > maxDragRange)
        {
            dragVector = dragVector.normalized * maxDragRange;
            currentPos = dragVector + startPos;

        }
        // if(forwardVector.magnitude > maxDragRange){
        //     forwardVector = forwardVector.normalized *maxDragRange;
        // }

        dragLineRenderer.SetPosition(0, startPos);
        dragLineRenderer.SetPosition(1, currentPos);

        Vector2 forwardVector = (startPos - currentPos).normalized * 2f;
futureLineRenderer.SetPosition(0, transform.position);
futureLineRenderer.SetPosition(1, (Vector2)transform.position + forwardVector);


    }
    void OnRelease()
    {
        dragLineRenderer.enabled = false;
        futureLineRenderer.enabled = false;
    }
}

