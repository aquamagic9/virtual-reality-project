using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxCollision : MonoBehaviour
{
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
        if (collision.gameObject.name == "Cube_T")
        {
            Debug.Log("collide answer!");
        }
    }
}
