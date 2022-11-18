using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int poolSize = 10;
    private List<GameObject> pool;
    private GameObject poolContainer;

    private void Awake()
    {
        pool = new List<GameObject>();
        poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for(int i = 0; i < poolSize; i++)
        {
            pool.Add(CreateInst());
        }
    }

    private GameObject CreateInst()
    {
        GameObject newInst = Instantiate(prefab);
        newInst.transform.SetParent(poolContainer.transform);
        newInst.SetActive(false);
        return newInst;
    }

    public GameObject GetInstFromPool()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return CreateInst();
    }

    public static void ReturnToPool(GameObject inst)
    {
        inst.SetActive(false);
    }

    public static IEnumerator ReturnToPoolWithDelay(GameObject inst, float delay)
    {
        yield return new WaitForSeconds(delay);
        inst.SetActive(false);
    }
}
