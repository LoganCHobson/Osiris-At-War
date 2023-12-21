using System.Collections.Generic;
using UnityEngine;

public class TargetingMaster : MonoBehaviour
{
    public List<GameObject> targetAbleShips = new List<GameObject>();
    string team;
    float range;

    public Collider[] shipsInRange;

    public bool playerSelected;

    public BaseTurret[] turrets;
    private void Start()
    {
        turrets = GetComponentsInChildren<BaseTurret>();
        team = GetComponent<GeneralShipController>().opposingTeam;
        range = GetComponent<GeneralShipController>().range;

    }
    void Update()
    {
        Debug.Log("Checkpoint1");
        if (targetAbleShips.Count <= 0 && !playerSelected)
        {
            Debug.Log("Checkpoint2");
            shipsInRange = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask(team));
            foreach (Collider collider in shipsInRange)
            {
                if (!targetAbleShips.Contains(collider.transform.gameObject))
                {
                    targetAbleShips.Add(collider.transform.gameObject);
                }
            }

            targetAbleShips.RemoveAll(ship => !System.Array.Exists(shipsInRange, collider => collider.gameObject == ship));

        }
        if (targetAbleShips.Count > 0 && !playerSelected)
        {
            foreach (GameObject ship in targetAbleShips)
            {
                if (Vector3.Distance(ship.transform.position, transform.position) > range)
                {
                    targetAbleShips.Remove(ship);
                    break;
                }
            }
        }

        if(targetAbleShips.Count <= 0 ) 
        { 
            playerSelected = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 30);
    }

    public void PlayerSelect(GameObject _target)
    {
        targetAbleShips.Clear();
        targetAbleShips.Add(_target);
        Debug.Log("Added " + _target);
        playerSelected = true;

        foreach (BaseTurret turret in turrets)
        {
            turret.target = _target.transform;
        }
    }
}
