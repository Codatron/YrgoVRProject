using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPatricalEffectNectar : MonoBehaviour
{
    public static ObjectPoolPatricalEffectNectar SharedInstance;
    public List<GameObject> pooledObject;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObject = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObject.Add(tmp);
        }

        //satt amonut till minst 20.
        // skapar 20 GO innan programmer k�rs?
    }


    //metod for att na dom och gora dom aktiva
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }

        return null;
    }

    //Detta ska skrivas dar bullets brukar skapar

    //   GameObject bullet = ObjectPool.SharedInstance.GetPooledObject;

    //   if (bullet != null)
    //{
    //        bullet.transform.position = turret.transform.postion;
    //       bullet.transform.rotation = turret.transform.rotation;
    //       bullet.setActiv(true);

    //}

    //istallet for att destroya bullet

    //GameObject.setActiv(false);
}

