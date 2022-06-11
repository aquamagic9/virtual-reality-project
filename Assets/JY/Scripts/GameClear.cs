using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public void GameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
