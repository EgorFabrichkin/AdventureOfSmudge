using System.Collections;

namespace GameCore.Spawns
{
    public interface ISpawn
    {
        public IEnumerator Spawn();
    }
}