using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{

    public List<GameObject> ships = new List<GameObject>();

    /*
        private Vector2 initialClick;
        private Vector2 currentMousePosition;
        private Rect selectionRect;
    */
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
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit5)) //Adding multiple ships
        {

            if (hit5.collider.CompareTag("TeamA") && !ships.Contains(hit5.collider.gameObject))
            {
                ships.Add(hit5.collider.gameObject);
                hit5.collider.GetComponentInParent<GeneralShipController>().isSelected = true;
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
        else if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit6)) //Adding single ships
        {
            foreach (GameObject ship in ships)
            {
                ship.GetComponentInParent<GeneralShipController>().isSelected = false;
            }
            ships.Clear();

            if (hit6.collider.CompareTag("TeamA") && !ships.Contains(hit6.collider.gameObject))
            {
                Debug.Log("Hit object: " + hit6.collider.gameObject.name);
                ships.Add(hit6.collider.gameObject);
                hit6.collider.GetComponentInParent<GeneralShipController>().isSelected = true;
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
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit4) && hit4.collider.CompareTag("TeamB") && !ships.Contains(hit4.collider.gameObject)) //Selecting target
        {
            foreach (GameObject ship in ships)
            {
                ship.GetComponentInParent<TargetingMaster>().PlayerSelect(hit4.collider.gameObject);

                float shootingRange = ship.GetComponentInParent<GeneralShipController>().range;

                Vector3 directionToTarget = (hit4.transform.position - ship.transform.position).normalized;

                Vector3 destination = hit4.transform.position - directionToTarget * shootingRange;

                ship.GetComponentInParent<BaseShipController>().SetDestination(destination);
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
        /* else if(Input.GetMouseButtonDown(0))
         {
             initialClick = Input.mousePosition;
         }
         if (Input.GetMouseButton(0))
         {
             currentMousePosition = Input.mousePosition;
             UpdateSelectionRectangle();
         }
         else
         {
             CollectSelectedObjects();
             selectionRect = new Rect(0, 0, 0, 0);
             initialClick = Vector3.zero;
         }
     }
     void UpdateSelectionRectangle()
     {



         Vector2 topLeft = new Vector2(
             Mathf.Min(initialClick.x, currentMousePosition.x),
             Mathf.Max(initialClick.y, currentMousePosition.y)
         );

         Vector2 bottomRight = new Vector2(
             Mathf.Max(initialClick.x, currentMousePosition.x),
             Mathf.Min(initialClick.y, currentMousePosition.y)
         );
         selectionRect = new Rect(
             topLeft.x,
             Screen.height - topLeft.y,
             bottomRight.x - topLeft.x,
             topLeft.y - bottomRight.y
         );


     }

     void CollectSelectedObjects()
     {

         Ray ray = Camera.main.ScreenPointToRay(selectionRect.position);
         RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
         Debug.Log(hits);

         foreach (RaycastHit hit in hits)
         {
             GameObject selectedObject = hit.collider.gameObject;
             Debug.Log("Selected: " + selectedObject.name);
         }
     }

     void OnGUI()
     {

         GUI.Box(selectionRect, "");


     }*/
    }
}