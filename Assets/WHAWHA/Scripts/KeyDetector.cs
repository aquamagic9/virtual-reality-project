using System;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{

    private TextMeshPro display;

    private KeyPadControll keyPadControll;
    // 스탓
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";
        Debug.Log("reset");
        keyPadControll = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("what");
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            Debug.Log("what");
            if (key != null)
            {
                var keyFeedBack = other.gameObject.GetComponent<KeyFeedback>();

                    if (key.text == "Back")
                    {
                        if (display.text.Length > 0)
                            display.text = display.text.Substring(0, display.text.Length - 1);
                    }
                    else if (key.text == "Enter")
                    {
                        var accessGranted = false;
                        
                        if (display.text.Length > 0) 
                            {
                                accessGranted = keyPadControll.CheckIfCorrect(Convert.ToString(display.text));
                            } 
                         
                        if(accessGranted == true)
                        {
                            display.text = "OK";
                        } 
                        else
                        {
                            display.text = "NO";
                        }
                    }
                    else if (key.text == "Cancel")
                    {
                        display.text = "";
                    }
                    else
                    {
                        //t파싱및 글자 텟그트기
                        //bool onlyNumbers =  int.TryParse(display.text, out int value);
                        //if(onlyNumbers == false)
                        //{
                        //    display.text = "";
                        //}
                        if(display.text == "Start" || display.text == "NO")
                        {
                            display.text = "";
                        }
                        //4잠나 뜨게
                        if(display.text.Length < 5)
                        display.text += key.text;
                    }
                    keyFeedBack.keyHit = true;
            }
        }
    }
}
