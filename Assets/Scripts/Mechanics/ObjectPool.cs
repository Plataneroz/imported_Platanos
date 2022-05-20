using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledObjects2;
    public GameObject objectToPool;
    public GameObject objectToPool2;
    public int amountToPool;
    public int amountToPool2;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledObjects2 = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i < amountToPool2; i++)
        {
            tmp2 = Instantiate(objectToPool2);
            tmp2.SetActive(false);
            pooledObjects2.Add(tmp2);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        return null;
    }



}
