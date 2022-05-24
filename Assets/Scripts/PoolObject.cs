using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public Pool Pool;
    public int PoolIndex;

    internal void ReturnToPool()
    {
        Pool.RetainObject(this.gameObject, PoolIndex);
    }
}
