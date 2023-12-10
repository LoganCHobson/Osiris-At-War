using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public List<GameObject> ships = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (GameObject ship in ships) 
            {
                ship.GetComponentInParent<GeneralShipController>().isSelected = false;
            }

            ships.Clear();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) //Adding more ships
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Ship") && !ships.Contains(hit.collider.gameObject))
            {
                ships.Add(hit.collider.gameObject);
                hit.collider.GetComponentInParent<GeneralShipController>().isSelected = true;
            }
            else
            {
                foreach (GameObject ship in ships)
                {
                    ship.GetComponentInParent<GeneralShipController>().isSelected = false;
                }
                ships.Clear();
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit2)) //Chaining commands
        {
            foreach (GameObject ship in ships)
            {
                ship.GetComponentInParent<BaseShipController>().AddDestination(hit2.point);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit3)) //Singular Command
        {
            foreach (GameObject ship in ships)
            {
                ship.GetComponentInParent<BaseShipController>().ClearDestinations();
                ship.GetComponentInParent<BaseShipController>().SetDestination(hit3.point);
            }
        }


    }
}
