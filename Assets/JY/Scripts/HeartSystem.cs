using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;
    public GameObject canvas;

    private void Start()
    {
        life = hearts.Length;
    }
    void Update()
    {
        if (dead == true)
        {
            canvas.SetActive(true);
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }
}
