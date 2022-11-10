using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledBoulders = new List<GameObject>();
    private int amountToPool = 5;
    [SerializeField] private GameObject boulder;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }   
    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(boulder);
            obj.SetActive(false);
            pooledBoulders.Add(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBoulders.Count; i++)
        {
            if (!pooledBoulders[i].activeInHierarchy)
            {
                return pooledBoulders[i];
            }
        }
        return null;
    }
    // Update is called once per frame
}
