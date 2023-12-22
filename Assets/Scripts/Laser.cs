using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Physics.Linecast(_lastPos, transform.position, out hit, 2);
        Debug.DrawRay(_lastPos, transform.position, Color.red);
        if(hit.collider != null)
        {
            if (hit.collider.CompareTag(team))
            {
                if(!hit.collider.GetComponentInParent<Health>())
                {
                    hit.collider.GetComponentInParent<Health>().DealDamage(10);
                }
                else
                {
                    hit.collider.GetComponentInChildren<Health>().DealDamage(10);
                }
            }
            else
            {
                Debug.Log("Idk man");
            }
            
            pool.Recycle(gameObject);
        }
        else
        {
            pool.Recycle(gameObject, 5);
        }
        
    }
        

}
