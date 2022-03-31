using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEscort : MonoBehaviour
{   [SerializeField]
    GameObject waitingForObjDeath;
    [SerializeField]
    GameObject activatingEscort;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingForObjDeath.activeSelf)
        {
            activatingEscort.SetActive(true);
        }
    }

     void TellPlayerToGetOnEScort()
    {

    }
}
