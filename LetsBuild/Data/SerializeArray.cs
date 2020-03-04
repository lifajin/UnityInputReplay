using System;
using UnityEngine;

namespace LetsBuild.Data
{
    [Serializable]
    public struct SerializeArray<T>
    {
        [SerializeField]
        public T[] data;
    }
}
