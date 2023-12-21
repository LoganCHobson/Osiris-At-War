using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
            ReturnChildren();
            ToggleUi(planetInfoUI);
        }
    }

    void ToggleUi(GameObject _obj)
    {
        _obj.SetActive(!_obj.activeSelf);

    }

    public void UpdatePlanetInfo()
    {
        Debug.Log("Updating");
        Transform[] dropZoneChildren = dropZone.GetComponentsInChildren<Transform>(true);
        foreach (Transform zone in dropZoneChildren)
        {
            Debug.Log("Looping");
            fleetData = zone.GetComponentInChildren<FleetData>();
            Transform hiddenLayoutInfo = zone.Find("HiddenLayoutInfo");
            if (hiddenLayoutInfo != null)
            {
                Debug.Log("Moving");
                GameObject panel = planetInfoUI.transform.GetChild(zone.transform.GetSiblingIndex() + 2).gameObject;

                foreach (Transform child in hiddenLayoutInfo)
                {
                    child.SetParent(panel.transform, false);
                }


            }
            else { Debug.Log("Not Found"); }

        }
    }

    void ReturnChildren()
    {
        Transform[] dropZoneChildren = dropZone.GetComponentsInChildren<Transform>(true);
        foreach (Transform zone in dropZoneChildren)
        {
            Debug.Log("Looping");
            fleetData = zone.GetComponentInChildren<FleetData>();
            Transform hiddenLayoutInfo = zone.Find("HiddenLayoutInfo");
            if (hiddenLayoutInfo != null)
            {
                Debug.Log("Moving");
                

                foreach (Transform child in hiddenLayoutInfo)
                {
                    child.SetParent(hiddenLayoutInfo.transform, false);
                }


            }
            else { Debug.Log("Not Found"); }

        }
    }

    
}

