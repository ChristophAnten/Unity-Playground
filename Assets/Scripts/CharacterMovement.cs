using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool moveManual = true;

    private int decisionClock = 0;
    private int decisionTime= 500;
    private float speed = 40f;
    private float moveH,moveV; 
    
    private Vector2 direction = Vector2.zero;

    private CharacterAnimator animator;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody= GetComponent<Rigidbody2D>();
        animator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        if (moveManual){
            Move_manual();
        } else {
            Tick();
            Move_random();
        }
        
    }

    private void Move_manual()
    {
        moveH = speed * Input.GetAxis("MoveH");
        moveV = speed * Input.GetAxis("MoveV");

        Vector3 newDirection = new Vector3(moveH, moveV, 0);
        direction = newDirection.normalized;
        animator.setAnimation(direction);
        rigidBody.velocity = Time.deltaTime * speed * direction;
    }

    private void  Tick()
    {
        decisionClock++;
        if(decisionClock > decisionTime) {
            decisionClock = 0;

            direction = GetDirection();
            animator.setAnimation(direction);
        }
    }

    private void Move_random()
    {
        rigidBody.velocity = Time.deltaTime * speed * direction;
        animator.test_Vector2 = rigidBody.velocity;
    }

    private Vector2 GetDirection()
    {
        System.Random random = new System.Random();
        
        Vector3 newDirection = new Vector3(random.Next(-1, 2), random.Next(-1, 2), 0);

        return ToIso(newDirection.normalized);
    }

    private Vector3 ToIso(Vector3 cartesianVector)
    {
        return new Vector3(
            cartesianVector.x - cartesianVector.y,
            (cartesianVector.x + cartesianVector.y) / 2,
            0
        );
    }

}
