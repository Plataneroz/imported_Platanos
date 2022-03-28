using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{


    //[SerializeField]
    float moveSpeed = 10f;
    float pointToDisable = -10;
    [SerializeField]
    float frequency = 20f;
    [SerializeField]
    bool isMovingRight, isMovingLeft;
    float magnitude = 0.5f;

    bool facingRight = true;
    float angle;
    Vector3 pos, startingPosition;

    bool starter = true;
    // Start is called before the first frame update
    void Start()
    {

        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (isMovingRight)
        {
            MoveRight();
        }
        else if (isMovingLeft)
        {
            MoveLeft();
        }
        else { MoveLeft(); }
        

    }


    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Lwall") {
            isMovingLeft = false;
            isMovingRight = true;
        }
        else if(collision.gameObject.tag =="Rwall")
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
    }
    }
