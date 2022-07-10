using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revival : MonoBehaviour
{
    bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inZone)
        {
            MovementOfRoof.isDown = true;
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnMouseEnter()
    {
        inZone = true;
    }
    void OnMouseExit()
    {
        inZone = false;
    }
}
