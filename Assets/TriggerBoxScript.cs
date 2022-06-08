using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    bool ani = false;
    GameObject doorR;
    GameObject doorL;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        doorR = transform.Find("Door R").gameObject;
        doorL = transform.Find("Door L").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ani)
        {
            doorR.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            doorL.transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
            Debug.Log(doorR.transform.rotation.y);
            Debug.Log(doorL.transform.rotation.y);
            if (doorR.transform.rotation.y >= 0.3)
            {
                Debug.Log("collide answer!");
                ani = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CubeT")
        {
            ani = true;
        }
        else
        {
            ui.GetComponent<HeartSystem>().TakeDamage(1);
        }
    }
}
