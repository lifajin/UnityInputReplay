using System;
using UnityEngine;

namespace LetsBuild.Data
{
    [Serializable]
    public struct GameObjectLocation
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }
}
