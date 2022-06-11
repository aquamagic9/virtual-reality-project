using UnityEngine;

public class KeyPadControll : MonoBehaviour
{
    //public Animator doorAnim1;
    //public Animator doorAnim2;
    //public Animator lockAnim;
    //public Animation doorRight;
    public GameObject doorR;
    public GameObject doorL;
    public GameObject locker;
    bool ani = false;
    public GameObject canvas;

    public string correctCombination;
    public bool accessGranted = false;

    [SerializeField] private string leftAnimationName = "";
    [SerializeField] private string rightAnimationName = "";
    [SerializeField] private string lockAnimationName = "";


    //아무거나

    /*
    private void Awake() {
        doorAnim1 = gameObject.GetComponent<Animator>();
        doorAnim2 = gameObject.GetComponent<Animator>();
    }
    */


    
    
    //프레임당
    void Update()
    {
        if(accessGranted == true)
        {
            //작업
            
            //accessGranted = false;
        }
        if (ani)
        {
            doorR.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            doorL.transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
            locker.transform.position = locker.transform.position + Vector3.down * Time.deltaTime;
            Debug.Log(doorR.transform.rotation.y);
            Debug.Log(doorL.transform.rotation.y);
            if (doorR.transform.rotation.y >= 0.8)
            {
                Debug.Log("collide answer!");
                ani = false;
            }
        }
    }


    public bool CheckIfCorrect(string combination)
    {
        if(combination == correctCombination)
        {
            accessGranted = true;
            ani = true;
            //lockAnim.Play(lockAnimationName);
            //doorAnim1.Play(leftAnimationName);
            //doorAnim2.Play(rightAnimationName);
            canvas.SetActive(true);

            return true;
        }
        return false;
    }
}
