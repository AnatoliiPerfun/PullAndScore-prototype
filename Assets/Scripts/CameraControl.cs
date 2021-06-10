﻿
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera depthCamera;
    void Start()
    {
        ChangeCameraRect();
    }

    void ChangeCameraRect()
    {
        float targetaspect = 4f / 6f;
        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;

        if (scaleheight < 1.0f)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            //rect.y = (1.0f - scaleheight) / 2.0f;

            mainCamera.rect = rect;
            ChangeFOV(depthCamera);
        }
    }
    
    void ChangeFOV(Camera camera)
    {
        float fixedHorizontalFOV = 28f;
        camera.fieldOfView = 2 * Mathf.Atan(Mathf.Tan(fixedHorizontalFOV * Mathf.Deg2Rad * 0.5f) / camera.aspect) * Mathf.Rad2Deg;
    }
}
