using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinetOne : MonoBehaviour
{
    bool ani = false;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ani)
        {
            transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
            if (transform.rotation.y >= 0.3)
            {
                ani = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TigerCube")
        {
            ani = true;
        }
        else
        {
            ui.GetComponent<HeartSystem>().TakeDamage(1);
        }
    }
}
