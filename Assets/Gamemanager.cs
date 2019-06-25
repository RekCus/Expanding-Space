using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager GM;
    public int coins=0;
    public int hp = 9;
    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }else if (GM != this)
        {
            Destroy(gameObject);
        }
    }
    public void Die()
    {
       // Destroy(GameObject.FindGameObjectWithTag("Player");
          coins = 0;
          hp = 9;
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
