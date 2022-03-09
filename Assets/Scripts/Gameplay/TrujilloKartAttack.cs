using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay { 
public class TrujilloKartAttack : MonoBehaviour
{
    public GameObject eggs;
    public float Timer = 2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            CreateEggs(2);
            Timer = 10;
        }
    }

    void CreateEggs( float offset)
    {
        eggs.transform.position = new Vector3(transform.position.x, transform.position.y + offset);
        Instantiate(eggs);
    }
}


}
