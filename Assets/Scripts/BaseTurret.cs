using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public float fireRate = 1.0f;
    public Transform head;
    public Transform firingPoint;
    public Transform target;

    ObjectPool pool;
    float lastShootTime;
    public string team;
    float range;


    TargetingMaster targetList;
    private void Start()
    {
        range = GetComponentInParent<GeneralShipController>().range;
        team = GetComponentInParent<GeneralShipController>().opposingTeam;
        targetList = GetComponentInParent<TargetingMaster>();
        pool = GetComponent<ObjectPool>();
        //target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    private void Update()
    {
        if (target != null)
        {

            head.LookAt(target.position);
            if (Physics.Raycast(firingPoint.position, target.position - firingPoint.position, out RaycastHit hit, range) && hit.collider.CompareTag(team))
            {
                Debug.Log("Shooting");
                Shoot();
            }
            Debug.DrawRay(firingPoint.position, target.position - firingPoint.position);
        }
        
        else
        {
            GetComponentInParent<TargetingMaster>().playerSelected = false;
            target = GetClosestTarget();
        }
       
    }

    Transform GetClosestTarget()
    {
        List<GameObject> ships = targetList.targetAbleShips;

        if(ships.Count == 0)
        {
            return null;
        }

        Transform closestShip = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject ship in ships)
        {
            float distance = Vector3.Distance(transform.position, ship.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestShip = ship.transform.parent;
            }
        }
        Debug.Log("ClosestShip =   " + closestShip);
        Transform target = closestShip.Find("HardPoints").GetChild(Random.Range(0, closestShip.Find("HardPoints").childCount)); //Basically find the child named HardPoints, which is an empty parent I use to organize HardPoints and then chose a random child from there to target.
        Debug.Log("Target = " + target);
        return target;
    }


    public void Shoot()
    {
        if (Time.time - lastShootTime >= fireRate)
        {
            Debug.Log("Fired!");
            GameObject temp = pool.Spawn(firingPoint.position, Quaternion.LookRotation(target.position - firingPoint.position, Vector3.up));
            temp.GetComponent<Laser>().pool = pool;
            temp.GetComponent<Laser>().team = team;
            lastShootTime = Time.time;
        }
    }


}
