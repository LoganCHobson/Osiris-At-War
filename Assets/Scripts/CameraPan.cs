using UnityEngine;

public class CameraPanZoom : MonoBehaviour
{
    private bool isPanning;
    private Vector3 mouseStartPosition;
    public float panSpeed = 10f;
    public float zoomSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 45f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isPanning = true;
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 offset = Camera.main.ScreenToViewportPoint(mouseStartPosition - Input.mousePosition);
            Vector3 move = transform.right * offset.x * panSpeed + transform.up * offset.y * panSpeed;
            transform.Translate(move, Space.World);
            mouseStartPosition = Input.mousePosition;
        }

        // Zoom with the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll);
    }

    private void ZoomCamera(float scroll)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);
    }
}
