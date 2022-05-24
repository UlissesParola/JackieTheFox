using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{ 
    [SerializeField]
    private GameObject[] BasePoolObjects;

	public int PoolSize {
		get { return BasePoolObjects.Length; }
	}

	private List<Queue<GameObject>> _poolList; 

	void Start () {
		Debug.Log("PoosSize = " + PoolSize);
		_poolList = new List<Queue<GameObject>>();

        for (int i = 0; i < BasePoolObjects.Length; i++)
        {
			Queue<GameObject> PoolQueue = new Queue<GameObject>();

			GameObject newObject = CreatePoolObject(BasePoolObjects[i], i);
			PoolQueue.Enqueue(newObject);
			_poolList.Insert(i, PoolQueue);
		}
		
	}

	public GameObject InstantiatePoolObject(int index)
	{
		bool poolIsEmpity = _poolList[index].Count == 0;

		if (poolIsEmpity)
		{
			GameObject newObject = CreatePoolObject(BasePoolObjects[index], index);
			_poolList[index].Enqueue(newObject);
		}

		GameObject obj = _poolList[index].Dequeue();
		obj.SetActive(true);
		return obj;
	}

	private GameObject CreatePoolObject(GameObject baseObject, int poolIndex)
    {
        GameObject newObject = Instantiate(baseObject);
        newObject.SetActive(false);
        newObject.transform.SetParent(this.transform);
		newObject.GetComponent<PoolObject>().Pool = this;
		newObject.GetComponent<PoolObject>().PoolIndex = poolIndex;
		return newObject;
    }

    public void RetainObject(GameObject obj, int poolIndex)
	{
		obj.SetActive(false);
		obj.transform.SetParent(this.transform);
		_poolList[poolIndex].Enqueue(obj);
	}
}
