using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(movement));

        if (movement > 0.01f)
        {
            transform.localScale = Vector3.one;
            
        }
        else if (movement < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            

        }
        else if (movement == 0f)
        {

        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f ) 
        { 
            _rigidbody.AddForce(new Vector2(0 , JumpForce), ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }


        if (Input.GetKey(KeyCode.LeftShift))

        {
            _animator.SetBool("Slide", true);
            MovementSpeed = 11;
        }
        else 
        {
            _animator.SetBool("Slide", false);
            MovementSpeed = 8;
        }
    }
}
