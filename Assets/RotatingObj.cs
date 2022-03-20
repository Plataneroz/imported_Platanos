using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObj : MonoBehaviour
{   
    float angleMultiplier=  120 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Rotate(0,0, Time.deltaTime * angleMultiplier);
        

    }
}
