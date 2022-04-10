using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class Extensions
    {
        public static Vector3 ToVector3(this Vec3 v3)
        {
            return new Vector3(v3.X, v3.Y, v3.Z);
        }

        /// <summary>
        /// Converts Unity Vector3 to Vec3 used by model
        /// </summary>
        /// <param name="v3"></param>
        /// <returns></returns>
        public static Vec3 ToVec3(this Vector3 v3)
        {
            return new Vec3
            {
                X = v3.x,
                Y = v3.y,
                Z = v3.z
            };
        }

        /// <summary>
        /// Converts Unity Quaternion to Vec4 used by model
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Vec4 ToVec4(this Quaternion quaternion)
        {
            return new Vec4
            {
                X = quaternion.x,
                Y = quaternion.y,
                Z = quaternion.z,
                W = quaternion.w
            };
        }
    }
}
