using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Television.isCasSec)
        {
            gameObject.SetActive(false);
            Destroy(this);
            enabled = false;
        }
    }
}
