using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomGraphics
{
        public class GraphicsInstance
        {
            private readonly GraphicsObject _graphicsObject;
            
            public GraphicsInstance(GraphicsObject graphicsObject, int index)
            {
                _graphicsObject = graphicsObject;
                InstanceIndex = index;
            }

            public readonly int InstanceIndex;
            
            private readonly List<Batch> _batches = new List<Batch>();

            private int _nextId = 0;
            
            public int AddInstance(Matrix4x4 matrix)
            {
                matrix *= Matrix4x4.TRS(_graphicsObject.position, Quaternion.Euler(_graphicsObject.rotation), _graphicsObject.scale);
                
                var id = _nextId++;

                if (_batches.Count == 0)
                {
                    _batches.Add(new Batch
                    {
                        Matrices = new Dictionary<int, Matrix4x4>()
                    });
                }
                var batch = _batches[^1];

                if (batch.Matrices.Count == 1023)
                {
                    _batches.Add(new Batch
                    {
                        Matrices = new Dictionary<int, Matrix4x4>()
                    });
                    batch = _batches[^1];
                }

                batch.Matrices.Add(id, matrix);
                return id;
            }
            
            public int AddInstanceAndLoad(Matrix4x4 matrix)
            {
                matrix *= Matrix4x4.TRS(_graphicsObject.position, Quaternion.Euler(_graphicsObject.rotation), _graphicsObject.scale);
                
                var id = _nextId++;

                if (_batches.Count == 0)
                {
                    _batches.Add(new Batch
                    {
                        Matrices = new Dictionary<int, Matrix4x4>()
                    });
                }
                var batch = _batches[^1];

                if (batch.Matrices.Count == 1023)
                {
                    _batches.Add(new Batch
                    {
                        Matrices = new Dictionary<int, Matrix4x4>()
                    });
                    batch = _batches[^1];
                }

                batch.Matrices.Add(id, matrix);
                batch.UpdateArray();
                return id;
            }

            public void Init()
            {
                foreach (var batch in _batches)
                {
                    batch.UpdateArray();
                }
            }
            
            public void RemoveInstance(int id)
            {
                foreach (var batch in _batches)
                {
                    if (batch.Matrices.ContainsKey(id))
                    {
                        batch.Matrices.Remove(id);
                        batch.UpdateArray();  // Update the array
                        break;
                    }
                }
            }

            public class Batch
            {
                public Dictionary<int, Matrix4x4> Matrices;
                private Matrix4x4[] _matrixArray;  // Store the array

                public Matrix4x4[] GetMatricesArray()
                {
                    return _matrixArray;
                }

                public void UpdateArray()  // New method to update the array
                {
                    _matrixArray = Matrices.Values.ToArray();
                }
            }

            public void Draw()
            {
                foreach (var batch in _batches)
                {
                    Graphics.DrawMeshInstanced(_graphicsObject.mesh, 0, _graphicsObject.material, batch.GetMatricesArray());
                }
            }
        }
}