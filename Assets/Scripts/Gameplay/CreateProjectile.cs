using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay { 
public class CreateProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float Timer = 3;
    public float yOffset;
    bool triggerAction = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(WaitForActions(Timer, yOffset));
    }

    public IEnumerator WaitForActions(float waitTime, float offset)
        {
            while (triggerAction)
            {
                triggerAction = !triggerAction;
                yield return new WaitForSeconds(waitTime);
                Launch(offset);
                triggerAction = !triggerAction;

            }
        }
    public void Launch(float offset)
        {
            projectile.transform.position = new Vector3(transform.position.x, transform.position.y + offset);
            Instantiate(projectile);
        }
    }

}
