using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObj : MonoBehaviour
{   [SerializeField]
    float angleMultiplier=  200 ;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,0, Time.deltaTime * angleMultiplier);
    }
}
