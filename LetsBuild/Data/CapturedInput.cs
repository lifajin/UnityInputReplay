using LetsBuild.Enums;
using System;

namespace LetsBuild.Data
{
    [Serializable]
    public struct CapturedInput
    {
        public bool bit;
        public float flt;
        public string str;
        public string key;
        public InputType eventType;
    }
}
