using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endbutton : MonoBehaviour
{
    public string sceneToLoad;



    public void loadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            loadNextScene();
        }


    }


}
