using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        float cameraHeight = 10.0f; // Ќужное значение размера камеры
        float desiredAspect = 16.0f / 9.0f; // —оотношение под которое подобран размер
        float aspect = camera.aspect;
        float ratio = desiredAspect / aspect;
        camera.orthographicSize = cameraHeight * ratio;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
