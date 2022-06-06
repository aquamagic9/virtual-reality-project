using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
public class KeyItemController : MonoBehaviour
{
   [SerializeField] private bool firstDoor = false;
   [SerializeField] private bool firstKey = false;

   [SerializeField] private KeyInventory _keyInventory = null;

   private KeyDoorController doorObject;

   private void Start() {
       if (firstDoor){
           doorObject = GetComponent<KeyDoorController>();
       }
       
   }
   public void ObjectInteraction(){
       if (firstDoor){
           doorObject.PlayAnimation();
       }
       else if (firstKey){
           _keyInventory.hasFirstKey = true;
           gameObject.SetActive(false);
       }
   }
}
}