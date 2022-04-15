using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour
{
    // Use this for initialization

    private void Start()
    {
        foreach (GameObject obj in objContainer)
        {
            obj.SetActive(false);
        }
    }

    public int ativeObjCount { get; private set; }
   public List<GameObject> objContainer;



    public void IncreaseativeObjCount()
    {
        if (ativeObjCount < 6)
        {
            
            if (ativeObjCount == 1) objContainer[ativeObjCount].SetActive(true);
            ativeObjCount++;
        }

    }

    public void DecreaseAtiveObjCount()
    {
        if (ativeObjCount > 0)
        {
         
          objContainer[ativeObjCount].SetActive(false);
          ativeObjCount--;
        }
    }

}
