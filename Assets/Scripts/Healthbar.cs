using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{

    private SpriteRenderer render;
    private Sprite s1,s2,s3,s4,s5,s6,s7,s8,s9;
    public PlayerMovement pm;

    int hp;

    

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        s1 = Resources.Load<Sprite>("1");
        s2 = Resources.Load<Sprite>("2");
        s3 = Resources.Load<Sprite>("3");
        s4 = Resources.Load<Sprite>("4");
        s5 = Resources.Load<Sprite>("5");
        s6 = Resources.Load<Sprite>("6");
        s7 = Resources.Load<Sprite>("7");
        s8 = Resources.Load<Sprite>("8");
        s9 = Resources.Load<Sprite>("9");
        render.sprite = s9;
    }

    // Update is called once per frame
    void Update()
    {

        hp = pm.health;

        switch (hp)
        {
            case 1:
                render.sprite = s1;
                break;
            case 2:
                render.sprite = s2;
                break;
            case 3:
                render.sprite = s3;
                break;
            case 4:
                render.sprite = s4;
                break;
            case 5:
                render.sprite = s5;
                break;
            case 6:
                render.sprite = s6;
                break;
            case 7:
                render.sprite = s7;
                break;
            case 8:
                render.sprite = s8;
                break;
            case 9:
                render.sprite = s9;
                break;




        }

    }


}
