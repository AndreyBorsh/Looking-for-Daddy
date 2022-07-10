using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfRoof : MonoBehaviour
{
    public GameObject roof;
    public float speed = 0.05f;

    bool isReady;
    public static bool isOpen;

    public static bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Television.isReady && !isReady)
        {
            isReady = true;
            StartCoroutine(YieldOneSecond());
        }
    }

    IEnumerator YieldOneSecond()
    {
        if(!isDown)
            yield return new WaitForSeconds(30);
        Movement.isWalk = true;
        while (Application.isPlaying && !isOpen)
        {
            isDown = true;
            roof.transform.position = new Vector3(roof.transform.position.x, roof.transform.position.y - speed,
                roof.transform.position.z);
            yield return new WaitForSecondsRealtime(1f);
        }
        if (isOpen)
        {
            roof.transform.position = new Vector3(roof.transform.position.x, 4.127f,
                roof.transform.position.z);
        }
    }
}
