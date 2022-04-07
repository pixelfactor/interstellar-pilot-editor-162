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

        public static Vec3 ToVec3(this Vector3 v3)
        {
            return new Vec3
            {
                X = v3.x,
                Y = v3.y,
                Z = v3.z
            };
        }

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
