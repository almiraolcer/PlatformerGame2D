using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{

[SerializeField] private Text ItemsText;
[SerializeField] private AudioSource collectSoundEffect;

private int Items = 0;
private void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.CompareTag("Item")){
        collectSoundEffect.Play();
        Destroy(collision.gameObject);
        Items++;
        ItemsText.text = "Items:" + Items;
    }
}

}
