using UnityEngine;
using UnityEngine.UIElements;

public class BaseTurret : MonoBehaviour
{
    public Transform turretHead;
    public Transform firePoint;
    public float rotationSpeed = 5f;
    public float elevationSpeed = 2f;
    public float fireRate = 1f;
    public int damage = 10;
    public GameObject projectilePrefab;

    public float range;

    private float elevationAngle = 0f; 
    private float nextFireTime;
    private Transform currentTarget;

    protected virtual void Update()
    {
        TargetAndFire();
        TraverseTurretUpDown();
    }

    protected virtual void TargetAndFire()
    {
        if (currentTarget == null)
        {
            FindNewTarget();
        }
        else
        {
            // Rotate turret head to face the current target
            RotateTurretHead(currentTarget.position);

            // Fire at the current target
            if (Time.time >= nextFireTime && Vector3.Distance(currentTarget.position, gameObject.transform.position) <= range)  
            {
                Fire(currentTarget.position);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    protected virtual void FindNewTarget()
    {
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("EnemyShip");

        if (potentialTargets.Length > 0)
        {
            currentTarget = GetRandomTarget(potentialTargets);
        }
    }

    protected virtual Transform GetRandomTarget(GameObject[] potentialTargets)
    {
        return potentialTargets[Random.Range(0, potentialTargets.Length)].transform;
    }

    protected virtual void RotateTurretHead(Vector3 targetPosition)
    {
        // Rotate turret head to face the target
        Vector3 targetDirection = targetPosition - turretHead.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        turretHead.rotation = Quaternion.RotateTowards(turretHead.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    protected virtual void TraverseTurretUpDown()
    {
        float inputVertical = Input.GetAxis("Vertical");  // Get input for turret elevation
        elevationAngle += inputVertical * elevationSpeed * Time.deltaTime;

        // Clamp the elevation angle to a reasonable range
        elevationAngle = Mathf.Clamp(elevationAngle, -45f, 45f);

        // Rotate turret head up and down based on the elevation angle
        turretHead.localRotation = Quaternion.Euler(elevationAngle, 0f, 0f);
    }

    protected virtual void Fire(Vector3 targetPosition)
    {
        // Instantiate a projectile or perform the firing logic
        GameObject temp = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(targetPosition - firePoint.position));
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
    }
}
