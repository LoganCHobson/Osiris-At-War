using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector]
    public Transform parentAfterDrag;

    public UnityEvent onBeginDrag, onDrag, onEndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDrag.Invoke();
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag.Invoke();
        Debug.Log("Drag");
        transform.position = Input.mousePosition;

        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag.Invoke();

        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        
    }

    
}
