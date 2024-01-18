using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private Vector3 dragOrigin;

    void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(1))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;

            // Clamp camera position to screen boundaries
            float boundaryWidth = cam.orthographicSize * Screen.width / Screen.height;
            float leftBoundary = -boundaryWidth / 2;
            float rightBoundary = boundaryWidth / 2;
            float topBoundary = cam.orthographicSize / 2;
            float bottomBoundary = -cam.orthographicSize / 2;

            cam.transform.position = new Vector3(
                Mathf.Clamp(cam.transform.position.x, leftBoundary, rightBoundary),
                Mathf.Clamp(cam.transform.position.y, bottomBoundary, topBoundary),
                cam.transform.position.z
            );
        }
    }

    public void zoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

    }

    public void zoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

    }

    private void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0) // forward
        {
            zoomIn();
        }
        else if (scroll < 0) // backward
        {
            zoomOut();
        }
    }
}