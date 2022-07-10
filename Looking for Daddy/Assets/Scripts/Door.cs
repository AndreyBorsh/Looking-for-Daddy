using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool inZone;
    bool inDist;

    public AudioClip hitSound;
    new AudioSource audio;

    public Transform other;

    public static bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inZone && inDist)
        {
            audio.Play();
        }
        if (isOpen)
        {
            transform.rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
            isOpen = false;
        }
    }

    private void OnMouseEnter()
    {
        float dist = Vector3.Distance(other.position, transform.position);
        if (other && dist <= 3.5f)
        {
            inZone = true;
            inDist = true;
        }
    }
    private void OnMouseExit()
    {
        inZone = false;
    }
}
