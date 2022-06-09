using UnityEngine;

public class SwitchControll : MonoBehaviour
{
    //Sound
    private AudioSource source;
    public AudioClip switchSound;


    private bool on = false;
    public bool switchHit = false;

    private float switchRotation = 100;
    private GameObject switchBase;

    public Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        switchBase = transform.GetChild(0).gameObject;
        //turn off spotlight
        spotLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchHit == true)
        {
            //PlaySound
            source.PlayOneShot(switchSound);
            switchHit = false;
            //if on is true make on false, and if on is false make on true
            on = !on;

            //rotate
            if (on == true)
            {
                spotLight.enabled = true;
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x + switchRotation, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else
            {
                spotLight.enabled = false;
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x - switchRotation, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            switchHit = true;
        }
    }
}
