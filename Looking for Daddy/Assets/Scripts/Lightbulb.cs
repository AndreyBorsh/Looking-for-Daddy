using UnityEngine;
using System.Collections;

public class Lightbulb : MonoBehaviour
{
    public float constantIntens;
    public float inten;
    private float TimeDown;
    private new Light light;

    public AudioClip hitSound;
    new AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();

        TimeDown = 1.0f;
        light = gameObject.GetComponent<Light>();
    }
    void Update()
    {
        if (light.intensity != constantIntens)
                light.intensity = constantIntens;

        if (TimeDown > 0) 
            TimeDown -= Time.deltaTime;

        if (TimeDown < 0) 
            TimeDown = 0;

        if (TimeDown == 0)
        {
            inten = Random.Range(0.2f, 4.0f);
            light.intensity = inten;
            TimeDown = Random.Range(0.2f, 0.6f);
        }
    }
}
