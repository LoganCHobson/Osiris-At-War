using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Laser : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 lastPos = Vector3.zero;

    [HideInInspector]
    public string team;
    [HideInInspector]
    public ObjectPool pool;

    public void Start()
    {
        lastPos = transform.position;
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.fixedDeltaTime);
        CheckHit(lastPos);
        lastPos = transform.position;
    }
    void CheckHit(Vector3 _lastPos)
    {
        RaycastHit hit;
        Physics.Raycast(_lastPos, transform.position, out hit, 2);
        if(hit.collider != null)
        {
            if (hit.collider.CompareTag(team))
            {
                hit.collider.GetComponentInParent<Health>().DealDamage(10);
            }
            pool.Recycle(gameObject);
        }
        else
        {
            pool.Recycle(gameObject, 5);
        }
        
    }
        

}
