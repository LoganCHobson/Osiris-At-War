using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetData : MonoBehaviour
{
  public List<GameObject> Ships = new List<GameObject>();
    private void Start()
    {
        UpdateFleet();
    }
    void UpdateFleet()
    {

    }

    private void Update()
    {
        if(Ships.Count == 0)
        {
            Destroy(gameObject);
        }    


    }

    public void RemoveShip(GameObject _ship)
    {
        Ships.Remove(_ship);
    }

    public void AddShip(GameObject _ship)
    {
        Ships.Remove(_ship);
    }
}
