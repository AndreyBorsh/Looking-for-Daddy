using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOnLock : MonoBehaviour
{
    public Text text;

    public AudioClip hitSound;
    public new AudioSource audio;

    public AudioClip hitSound2;
    public AudioSource audio2;

    public GameObject cabinet;
    public GameObject casset;

    bool inZone;
    bool isOpen;

    List<string> pin = new List<string>();

    public Transform other;

    bool inDist;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;

        audio = gameObject.GetComponent<AudioSource>();

        audio2 = gameObject.GetComponent<AudioSource>();

        PlayerPrefs.SetString("Lock", ""); //при запуске сохран€ю в ключ Lock значение, которое сохран€етс€ при новом запуске скрипта
    }

    void OnMouseEnter()
    {
        float dist = Vector3.Distance(other.position, transform.position);
        if (other && dist <= 3.5f)
        {
            text.enabled = true;
            inZone = true;
            inDist = true;
        }
            
    }

    void OnMouseExit()
    {
        text.enabled = false;
        inZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inZone && text.text == "OK" && inDist)
        {
            string lenght = PlayerPrefs.GetString("Lock");
            if(lenght.Length == 4 && lenght[0] == '6' && lenght[1] == '4' && lenght[2] == '1' && lenght[3] == '2' && !isOpen)
            {
                audio2.PlayOneShot(hitSound2);
                cabinet.transform.position = new Vector3(cabinet.transform.position.x, cabinet.transform.position.y, 
                    cabinet.transform.position.z + 0.3f);
                casset.transform.position = new Vector3(casset.transform.position.x, casset.transform.position.y,
                    casset.transform.position.z + 0.3f);
                isOpen = true;
                MovementOfRoof.isOpen = true;
            }
            else
            {
                audio.PlayOneShot(hitSound);
                PlayerPrefs.SetString("Lock", "");
                pin.Clear();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && inZone && inDist)
        {
            pin.Add(text.text);
            string a = PlayerPrefs.GetString("Lock");
            PlayerPrefs.SetString("Lock", pin[0]);
            PlayerPrefs.SetString("Lock", a + pin[0]);
            audio.Play();
        }
    }
}
