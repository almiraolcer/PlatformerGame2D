using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{

    private AudioSource finishSound;
    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter2D(Collider2D collision){
       if(collision.gameObject.name=="Player"){
           finishSound.Play();
           CompleteLevel();
       }
   }

   private void CompleteLevel(){
       
   }
}
