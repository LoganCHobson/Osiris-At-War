using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler
{
    private RectTransform rectTrans;
    private Vector2 originalPosition;
    public void OnDrag(PointerEventData eventData)
    {
        originalPosition = rectTrans.anchoredPosition;
        rectTrans.anchoredPosition += eventData.delta;
    }

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

 
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Transform dropZone = hit.transform;
                if (dropZone.CompareTag("DropZone"))
                {
                    rectTrans.anchoredPosition = dropZone.GetComponent<RectTransform>().anchoredPosition;
                }
            }
        }
    }
}
