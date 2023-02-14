using System.Collections;
using UnityEngine;

namespace GameCore.Spawns
{
    public abstract class SimpleSpawn : MonoBehaviour, ISpawn
    {
        public abstract IEnumerator Spawn();
    }
}