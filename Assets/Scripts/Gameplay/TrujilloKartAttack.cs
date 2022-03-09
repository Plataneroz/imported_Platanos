using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrujilloKartAttack : MonoBehaviour
{
    public GameObject eggs;
    public float Timer = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ThrowEggs();
    }

    void ThrowEggs()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            CreateEggs();
            Timer = 10;
        }

    }

    void CreateEggs()
    {
        eggs.transform.position = new Vector3(transform.position.x, transform.position.y + 2);
        Instantiate(eggs);
    }
}



