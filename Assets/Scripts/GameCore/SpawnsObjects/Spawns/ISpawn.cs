using System.Collections;

namespace GameCore.SpawnsObjects.Spawns
{
    public interface ISpawn
    {
        public IEnumerator Spawn();
    }
}