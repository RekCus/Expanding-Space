using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public GameObject ui;
    public VideoPlayer vid;
    //vid.loopPointReached += EndReached;
    public string sceneToLoad;



   private void Start()
    {
        vid.loopPointReached += EndReached;
        ui.SetActive(false);
    }


    public void loadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            Debug.Log("Video End");
            ui.SetActive(true);
            loadNextScene();
        }
    
}
