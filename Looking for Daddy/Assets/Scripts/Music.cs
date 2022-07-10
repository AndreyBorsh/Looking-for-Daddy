using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] hitSound = new AudioClip[7];
    new AudioSource[] audio = new AudioSource[7];

    public static List<string> musical = new List<string>();

    bool inZone;

    bool isPress;

    public float time;

    float timer;

    public int step;

    // Start is called before the first frame update
    void Start()
    {
        timer = time;

        musical.Add($"6"); musical.Add($"1");

        for (int i = 0; i < 7; i++)
        {
            audio[i] = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Television.isCasSec)
        {
            transform.position = new Vector3(transform.position.x, 0.797f, transform.position.z);
        }
        if (MusicalKeys.isThirdCas)
        {
            gameObject.SetActive(false);
            Destroy(this);
            enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && inZone)
        {
            isPress = true;
            for (int i = 0; i < musical.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (musical[i] == j.ToString())
                    {
                        while (timer > 0) 
                        { 
                            timer -= Time.deltaTime * step; 
                        }
                        if (timer < 0) 
                        { 
                            audio[j].PlayOneShot(hitSound[j]);
                            timer = time; 
                        }
                        break;
                    }
                }
            }
            isPress = false;
        }
    }

    IEnumerator YieldOneSecond(int id)
    {
        if (isPress)
        {
            audio[id].PlayOneShot(hitSound[id]);
            yield return new WaitForSeconds(10);
        }
    }

    private void OnMouseEnter()
    {
        inZone = true;
    }
    private void OnMouseExit()
    {
        inZone = false;
    }
}
