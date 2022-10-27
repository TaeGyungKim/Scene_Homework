using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scene_transition : MonoBehaviour
{
    //lose scene 
    public void transition()
    {
        SceneManager.LoadScene("scene2", LoadSceneMode.Single);
    }

    //main game scene
    public void sceneStart()
    {
        SceneManager.LoadScene("scene1", LoadSceneMode.Single);
    }
}
