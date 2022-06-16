using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;

    public float zoomSpeed = 10f;
    public float test1 = 10f;
    public float test2 = 10f;

    void Start()
    {
    }

    void Update()
    {
        
        float dx = panSpeed * Time.deltaTime * Input.GetAxis("CamH");
        float dy = panSpeed * Time.deltaTime * Input.GetAxis("CamV");
        
        //dx = Mathf.Clamp(
        Camera.main.transform.Translate(dx, dy, 0);

        float dz = zoomSpeed * Time.deltaTime * Input.GetAxis("CamZoom");

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + dz, 1f ,5f);

    }
}
