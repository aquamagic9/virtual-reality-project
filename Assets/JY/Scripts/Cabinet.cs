using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public GameObject ui;
    public GameObject[] animalCube;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i<animalCube.Length; i++)
        {
            if (collision.Equals(animalCube[i]))
            {
                ui.GetComponent<HeartSystem>().TakeDamage(1);
            }
        }
    }
}
