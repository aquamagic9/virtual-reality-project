using UnityEngine;

public class KeyPadControll : MonoBehaviour
{
    private Animator doorAnim;
    public int correctCombination;
    public bool accessGranted = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "Doorleft";
    [SerializeField] private string open2AnimationName = "Doorright";
    [SerializeField] private string lockAnimationName = "lockopen";
    
    //아무거나
    public Light spotLight;
    
    private void Awake() {
        doorAnim = gameObject.GetComponent<Animator>();
    }
    
    private void Start()
    {
        spotLight.enabled = false;
    }
    //프레임당
    void Update()
    {
        if(accessGranted == true)
        {
            //작업
            spotLight.enabled = true;
            accessGranted = false;
            doorAnim.Play(openAnimationName,0,0.0f);
            doorAnim.Play(open2AnimationName,0,0.0f);
            doorAnim.Play(lockAnimationName,0,0.0f);
        }
    }


    public bool CheckIfCorrect(int combination)
    {
        if(combination == correctCombination)
        {
            accessGranted = true;
            return true;
        }
        return false;
    }
}
