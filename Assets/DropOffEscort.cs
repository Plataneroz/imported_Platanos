using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffEscort : MonoBehaviour
{
    public Transform firstTarget;
    public Transform finalTarget;
    public GameObject player;
    bool dropedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != firstTarget.position.x && !dropedPlayer)
        { transform.position = Vector2.MoveTowards(transform.position,
                          firstTarget.position, 10 * Time.deltaTime);

            }
        else if (transform.position.x == firstTarget.position.x && !dropedPlayer)
        {
            player.SetActive(true);
            player.transform.parent = null;
            
            dropedPlayer = true;
        }
        else 
         {
                transform.position = Vector2.MoveTowards(transform.position,
                      finalTarget.position, 10 * Time.deltaTime);
            if (transform.position.y == finalTarget.position.y) { gameObject.SetActive(false); }
            }
    }
}
