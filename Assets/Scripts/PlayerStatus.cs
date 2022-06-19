using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    [SerializeField] private AudioSource DeathSoundEffect;


    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _anim=GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap")){
            Die();
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision){
      //      if(collision.gameObject.CompareTag("Enemy")){
        //    Die();
        //}
    //}
    private void Die(){
        DeathSoundEffect.Play();
        _rb.bodyType= RigidbodyType2D.Static;
        _anim.SetTrigger("Death");
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
