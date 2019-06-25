using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinUI : MonoBehaviour
{

    public TextMeshProUGUI text;
    private void Update()
    {
        text.text = Gamemanager.GM.coins.ToString();
    }

}
