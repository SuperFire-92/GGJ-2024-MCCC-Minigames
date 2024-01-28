using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAimIndicator : MonoBehaviour
{

    private TrashBallControler trashBallControlerScript;
    public Sprite preFlick;
    public Sprite postFlick;
    private SpriteRenderer spriteControlerChild;
    public GameObject trashBall;
    private Vector3 aimIndicator;


    // Start is called before the first frame update
    void Start()
    {
        trashBallControlerScript = trashBall.GetComponent<TrashBallControler>();
        spriteControlerChild = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        aimIndicator = trashBallControlerScript.getAimIndicator();
        updateAimIndicator();
    }

    private void updateAimIndicator()
    {

        if (trashBallControlerScript.getCanShoot())
        {

            spriteControlerChild.sprite = preFlick;


        }
        else
        {
            spriteControlerChild.sprite = postFlick;
        }
       transform.eulerAngles = new Vector3(0, 0, -aimIndicator.x * 4);





    }
}
