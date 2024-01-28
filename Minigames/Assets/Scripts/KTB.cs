using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KTB : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject keyboard_e;
    [SerializeField] private GameObject keyboard_c;
    [SerializeField] private GameObject keyboard_g;
    [SerializeField] private GameObject keyboard_f;

    [SerializeField] private TMP_Text powerTMP;
    [SerializeField] private GameObject instructionstxt;
    [SerializeField] private GameObject foot;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject goal;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject ballgoalthing;
    private bool ekeyActive;
    private bool cKeyActive;
    private bool gKeyActive;
    private bool fKeyActive;


    private bool successfulKeyPress;

    private float power;

    void Start()
    {
        power = 0;
        ekeyActive = false;
        cKeyActive = false;
        gKeyActive = false;
        fKeyActive = false;
        successfulKeyPress = false;
        StartCoroutine(minigame());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && ekeyActive)
        {
            successfulKeyPress = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && cKeyActive)
        {
            successfulKeyPress = true;
        }
        if(Input.GetKeyDown(KeyCode.G) && gKeyActive)
        {
            successfulKeyPress = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && fKeyActive)
        {
            successfulKeyPress = true;
        }
    }

    public void setKeyActive()
    {
        int rand = Random.Range(0, 4);
        if(rand == 0)
        {
            ekeyActive = true;
            keyboard_e.SetActive(true);
        }
        else if(rand == 1)
        {
            cKeyActive = true;
            keyboard_c.SetActive(true);
        }
        else if (rand == 2)
        {
            gKeyActive = true;
            keyboard_g.SetActive(true);
        }
        else if (rand == 3)
        {
            fKeyActive = true;
            keyboard_f.SetActive(true);
        }

    }

    public void disableKeys()
    {
        keyboard_e.SetActive(false);
        keyboard_c.SetActive(false);
        keyboard_g.SetActive(false);
        keyboard_f.SetActive(false);

        ekeyActive = false;
        gKeyActive = false;
        cKeyActive = false;
        fKeyActive = false;

    }

    IEnumerator minigame()
    {
        yield return new WaitForSeconds(1F);
        setKeyActive();
        yield return new WaitForSeconds(0.75F);
        disableKeys();
        if(successfulKeyPress)
        {
            power += 3;
            powerTMP.SetText("POWER: " + power);
        }
        successfulKeyPress = false;
        yield return new WaitForSeconds(1F);
        setKeyActive();
        yield return new WaitForSeconds(0.75F);
        disableKeys();
        if (successfulKeyPress)
        {
            power += 3;
            powerTMP.SetText("POWER: " + power);
        }
        successfulKeyPress = false;
        instructionstxt.SetActive(false);
        ballgoalthing.SetActive(true);
        yield return new WaitForSeconds(1F);

        bool didPlayerWin;
        if(power <= 5)
        {
            anim.SetTrigger("KickFail");
            didPlayerWin = false;
        }
        else if(power >= 6)
        {
            anim.SetTrigger("KickSuccess");
            didPlayerWin = true;
        }
        else
        {
            anim.SetTrigger("KickFail");
            didPlayerWin = false;
        }

        yield return new WaitForSeconds(1F);
        GameManager.endMiniGame(didPlayerWin);

        yield return 0;
    }
}
