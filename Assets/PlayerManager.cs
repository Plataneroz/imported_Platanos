using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
       
        //playeyInpt = playerInputManager.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create2ndPlayer()
    {
        Instantiate(player2);
    }
}
