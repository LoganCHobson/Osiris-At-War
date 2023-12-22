using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    FleetData fleetData;
    public bool isPlayerOwned = false;
    public GameObject planetInfoUI;
    public GameObject dropZone;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearPlanetUI();
            planetInfoUI.SetActive(false);
        }

        //UpdatePanel();
    }

    void ToggleUi(GameObject _obj)
    {
        _obj.SetActive(!_obj.activeSelf);

    }

    public void UpdatePlanetInfo()
    {
        Debug.Log("Updating");
        
        foreach (Transform zone in dropZone.transform)
        {
            if (zone != dropZone.transform)
            {
                Debug.Log("Looping");
                if (zone.GetComponentInChildren<FleetData>())
                {
                    FleetData temp = zone.GetComponentInChildren<FleetData>();
                    GameObject panel = planetInfoUI.transform.GetChild(zone.transform.GetSiblingIndex() + 2).gameObject;
                    foreach (GameObject ship in temp.Ships)
                    {
                        Instantiate(ship, panel.transform);
                    }
                }
            }

        }
    }

    public void ClearPlanetUI()
    {
        
        foreach(Transform fleetUI in planetInfoUI.transform)
        {
            if(fleetUI.GetSiblingIndex() != 0 && fleetUI.GetSiblingIndex() != 1)
            {
                foreach (Transform child in fleetUI.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }
    }

    public void UpdatePanel()
    {
        foreach (Transform zone in dropZone.transform)
        {
            if (zone != dropZone.transform)
            {
                Debug.Log("Looping");
                if (zone.GetComponentInChildren<FleetData>())
                {
                    FleetData temp = zone.GetComponentInChildren<FleetData>();
                    GameObject panel = planetInfoUI.transform.GetChild(zone.transform.GetSiblingIndex() + 2).gameObject;
                    foreach (GameObject ship in temp.Ships)
                    {
                        Instantiate(ship, panel.transform);
                    }
                }
            }
        }
    }


}




