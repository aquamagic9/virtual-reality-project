using UnityEngine;

public class KeyFeedback : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip keySound;
    public bool keyHit = false;

    

    private Color originalColor;
    private Renderer renderer;


    //return color Timer
    private float colorReturnTime = 0.1f;
    private float returnColor;


    // 스타트
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 0.1f;
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        
    }

    //프렘당
    void Update()
    {
        if (keyHit && returnColor < Time.time)
        {

            Debug.Log("sound");
            audioSource.PlayOneShot(keySound);
            returnColor = Time.time + colorReturnTime;
            renderer.material.color = Color.green;

            keyHit = false;
        }
        if (renderer.material.color != originalColor && returnColor < Time.time)
        {
            renderer.material.color = originalColor;
        }

    }
    
    }

