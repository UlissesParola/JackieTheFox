using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool// : MonoBehaviour
{ 
    private GameObject[] BasePoolObjects;
	private List<Queue<GameObject>> _poolList; 

	public Pool (GameObject[] gameObjects) {

		BasePoolObjects = gameObjects;
		_poolList = new List<Queue<GameObject>>();

        for (int i = 0; i < BasePoolObjects.Length; i++)
        {
			Queue<GameObject> PoolQueue = new Queue<GameObject>();

			GameObject newObject = CreatePoolObject(BasePoolObjects[i], i);
			PoolQueue.Enqueue(newObject);
			_poolList.Insert(i, PoolQueue);
		}
	}

	public GameObject InstantiatePoolObject(int poolIndex)
	{
		bool poolIsEmpity = _poolList[poolIndex].Count == 0;

		if (poolIsEmpity)
		{
			GameObject obj = CreatePoolObject(BasePoolObjects[poolIndex], poolIndex);
			_poolList[poolIndex].Enqueue(obj);
		}

		GameObject newObject = _poolList[poolIndex].Dequeue();
		newObject.SetActive(true);
		return newObject;
	}

	private GameObject CreatePoolObject(GameObject baseObject, int poolIndex)
    {
        GameObject newObject = UnityEngine.Object.Instantiate(baseObject);
        newObject.SetActive(false);
		newObject.GetComponent<PoolObject>().Pool = this;
		newObject.GetComponent<PoolObject>().PoolIndex = poolIndex;
		return newObject;
    }

    public void RetainObject(GameObject obj, int poolIndex)
	{
		obj.SetActive(false);
		_poolList[poolIndex].Enqueue(obj);
	}
}
