using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallSpawn : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
   [SerializeField] private GameObject spikeBall;
   [SerializeField] private float spawnTime; 
   private Vector3 _spawnPos;
   private float _timeSinceSpawn;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        this._spawnPos = this.gameObject.transform.position;
    }

    void _spawn()
    {
        Instantiate(spikeBall, new Vector3(this._spawnPos.x, this._spawnPos.y, this._spawnPos.z), Quaternion.identity);
    }

    private void LateUpdate()
    {
        if (this._timeSinceSpawn > this.spawnTime)
        {
            this._spawn();
            this._timeSinceSpawn = 0;
        }
        this._timeSinceSpawn += Time.deltaTime;
    }
}
