using UnityEngine;

namespace Utils
{
    public static class VectorExtensions
    {
        public static Vector3 Flat(this Vector2 vector)
        {
            return new Vector3(vector.x, 0, 0);
        }
    }
}