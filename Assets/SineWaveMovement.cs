using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    void EnableObj()
    {
        gameObject.SetActive(true);
    }
    void DisableObj()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;
    float angle;
    Vector3 pos, localScale;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();

       
    }

    void DirectionFacing() { 
    		if (pos.x< -7f)

            facingRight = true;
		
		else if (pos.x > 7f)
			facingRight = false;

		if (((facingRight) && (localScale.x< 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
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
}
