using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactThings : MonoBehaviour
{
    private Rigidbody body;
    public string interactText = "Interact";
    public Text UIText;
    public GameObject UIPrefab;
    public bool isActive = true;
    public GameObject High;
    public GameObject ALLUI;
    public GameObject stupidLight;
    public float Timer=60;

    private GameObject TIMEUP;
    private GameObject Conclu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        UIPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(UIPrefab.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startRun();
            }
        }
        if(ALLUI.activeSelf)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            GameObject.Find("TimeRemain").GetComponent<Text>().text = Timer.ToString();
        }

        if(Timer<0)
        {
            Timer = 0f;
            GameObject.Find("TimeRemain").GetComponent<Text>().text = Timer.ToString();
            TIMEUP.SetActive(true);
            Conclu.SetActive(true);
            GameObject.Find("Conclusion").GetComponent<Text>().text = "You collected " + GameObject.Find("CoinCollected").GetComponent<Text>().text;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && isActive==true)
        {
            UIPrefab.SetActive(true);
            UIText.text = interactText;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        UIPrefab.SetActive(false);
    }

    void startRun()
    {
        
        Vector3 currentbuttonlocation = this.transform.position;
        print(this.name);
        this.GetComponent<Animator>().Play("Button_Down");
        this.transform.position = currentbuttonlocation;
        stupidLight.SetActive(true);
        GameObject.Find("gate").GetComponent<Animator>().Play("dooropen");
        GameObject.Find("gate/dooropen").GetComponent<AudioSource>().Play();
        UIPrefab.SetActive(false);
        ALLUI.SetActive(true);
        TIMEUP = GameObject.Find("TimeUP");
        Conclu = GameObject.Find("Conclusion");
        GameObject.Find("TimeUP").SetActive(false);
        GameObject.Find("Conclusion").SetActive(false);
        GameObject.Find("TimeRemain").GetComponent<Text>().text = Timer.ToString();
    }


}
