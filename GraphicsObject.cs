using System;
using UnityEngine;

namespace CustomGraphics
{
    [Serializable]
    public class GraphicsObject
    {
        public Mesh mesh;
        public Material material;
        [Header("Transform")]
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale = Vector3.one;
        
    }
}