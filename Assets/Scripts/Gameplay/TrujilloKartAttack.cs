using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay { 
public class TrujilloKartAttack : MonoBehaviour
{
    public GameObject eggs;
    public float Timer = 2;
    public float eggOffset;
    bool triggerAction = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(WaitForActions(Timer, eggOffset));
    }

    public IEnumerator WaitForActions(float waitTime, float offset)
        {
            while (triggerAction)
            {
                triggerAction = !triggerAction;
                yield return new WaitForSeconds(waitTime);
                CreateEggs(offset);
                triggerAction = !triggerAction;

            }
        }
    public void CreateEggs(float offset)
        {
            eggs.transform.position = new Vector3(transform.position.x, transform.position.y + offset);
            Instantiate(eggs);
        }
    }

}
