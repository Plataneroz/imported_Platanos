using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public int coroutineCounter;
    public float speedLimit = 12;
    public float launchAngleLimit = -160;
    public float forHowLongIsItDangerous = 6;
   
    // Start is called before the first frame update
    void Start()
    {   transform.eulerAngles = new Vector3(0, 0, Random.Range(-120, launchAngleLimit));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 2);
    }


}
