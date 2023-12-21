using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragDrop dragItem = dropped.GetComponent<DragDrop>();
            dragItem.parentAfterDrag = transform;
        }
        else
        {
            //Combine fleets
        }
    }

  
}
