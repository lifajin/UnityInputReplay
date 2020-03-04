using System;
using System.Collections.Generic;

namespace LetsBuild.Data
{
    [Serializable]
    public struct Frame
    {
        public float time;
        public List<CapturedInput> data;
        public List<GameObjectLocation> gameObjects;

        public static bool operator ==(Frame c1, Frame c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Frame c1, Frame c2)
        {
            return !c1.Equals(c2);
        }
    }
}
