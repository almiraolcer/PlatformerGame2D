using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private BoxCollider2D _coll;
    private SpriteRenderer _sprite;
    private Animator _anim;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

     private  float  dirX ;
     private float _movespeed=7f;
     private float _jumpforce = 14f;

    private enum _MovementState{idle,running,jumping,falling, attack}
    

    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _coll=GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
       
    }


    private void Update()
    {
        
       dirX= Input.GetAxisRaw("Horizontal");
        _rb.velocity= new Vector2(dirX * _movespeed, _rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            jumpSoundEffect.Play();
            _rb.velocity = new Vector2(_rb.velocity.x,_jumpforce);
        }

      UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate(){
        _MovementState state;
        if(dirX>0f){
            state = _MovementState.running;
            _sprite.flipX=false;
        }
        else if (dirX<0f){
            state = _MovementState.running;
            _sprite.flipX = true;
        }
        else{
            state = _MovementState.idle;
        }

        if(_rb.velocity.y> .1f){
            state=_MovementState.jumping;
        }
        else if(_rb.velocity.y < -.1f){
            state=_MovementState.falling;
        }
        _anim.SetInteger("State", (int)state); 
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(_coll.bounds.center, _coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
