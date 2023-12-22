using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public bool fleetUI = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0 || fleetUI)
        {
            GameObject dropped = eventData.pointerDrag;
            DragDrop dragItem = dropped.GetComponent<DragDrop>();
            dragItem.parentAfterDrag = transform;


        }
        else
        {
            GameObject dropped = eventData.pointerDrag;

            transform.GetChild(0).GetComponent<FleetData>().Ships.AddRange(dropped.GetComponent<FleetData>().Ships);
            Destroy(dropped);
        }


    }


}
