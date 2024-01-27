using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KTB : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject keyboard_e;
    [SerializeField] private GameObject keyboard_c;
    [SerializeField] private TMP_Text powerTMP;
    [SerializeField] private GameObject instructionstxt;
    [SerializeField] private GameObject foot;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject goal;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject ballgoalthing;
    private bool ekeyActive;
    private bool cKeyActive;

    private bool successfulKeyPress;

    private float power;

    void Start()
    {
        power = 0;
        ekeyActive = false;
        cKeyActive = false;
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
    }

    IEnumerator minigame()
    {
        yield return new WaitForSeconds(1F);
        keyboard_c.SetActive(true);
        cKeyActive = true;
        yield return new WaitForSeconds(1F);
        cKeyActive = false;
        if(successfulKeyPress)
        {
            power += 3;
            powerTMP.SetText("POWER: " + power);
        }
        successfulKeyPress = false;
        keyboard_c.SetActive(false);
        yield return new WaitForSeconds(1F);
        keyboard_e.SetActive(true);
        ekeyActive = true;
        yield return new WaitForSeconds(1F);
        keyboard_e.SetActive(false);
        ekeyActive = false;
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
        if(power <= 0)
        {
            anim.SetTrigger("KickFail");
            didPlayerWin = false;
        }
        else if(power >= 6)
        {
            anim.SetTrigger("KickSuperSuccess");
            didPlayerWin = true;
        }
        else if(power >= 3)
        {
            anim.SetTrigger("KickSuccess");
            didPlayerWin = true;
        }
        else
        {
            didPlayerWin = false;
        }

        yield return new WaitForSeconds(1F);
        GameManager.endMiniGame(didPlayerWin);

        yield return 0;
    }
}
