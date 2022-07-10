using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToScene : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            camera2.gameObject.SetActive(false);
            camera1.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
