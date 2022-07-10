using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MouseOnChair : MonoBehaviour
{
    public GameObject chair;
    public GameObject textChair;

    bool inZone;

    public Camera camera1;
    public Camera camera2;

    public Transform other;

    bool inDist;

    // Start is called before the first frame update
    void Start()
    {
        textChair.SetActive(false);
    }

    private void OnMouseEnter()
    {
        float dist = Vector3.Distance(other.position, transform.position);
        if (other && dist <= 3.5f)
        {
            inDist = true;
            textChair.SetActive(true);
            inZone = true;
        }
    }

    private void OnMouseExit()
    {
        inZone = false;
        textChair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && inZone && inDist)
        {
            textChair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
    }
}
