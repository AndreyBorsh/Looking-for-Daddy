using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPuzzle : MonoBehaviour
{
    private Vector3 offset;

    public GameObject form;
    bool isFinish;

    public AudioClip hitSound;
    new AudioSource audio;

    public Camera activeCamera;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        if(!isFinish)
            offset = gameObject.transform.position - 
                activeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.0f));
    }

    void OnMouseDrag()
    {
        if (!isFinish)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.0f);
            transform.position = activeCamera.ScreenToWorldPoint(newPosition) + offset;
        }  
    }

    void OnMouseUp()
    {
        if(Mathf.Abs(transform.localPosition.x - form.transform.localPosition.x) <= 1f &&
            Mathf.Abs(transform.localPosition.y - form.transform.localPosition.y) <= 1f)
        {
            transform.position = new Vector3(form.transform.position.x, form.transform.position.y, form.transform.position.z);
            isFinish = true;
            audio.Play();
        }
    }
}
