using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
   public void ChangeScene()
    {
        Debug.Log("ClickFlag");
        SceneManager.LoadScene("Start");
    }
}
