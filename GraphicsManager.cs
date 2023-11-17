using System.Collections.Generic;
using CustomGrid;
using UnityEngine;

namespace CustomGraphics
{
    public class GraphicsManager : MonoBehaviour
    {
        private List<GraphicsInstance> _graphicsObjects = new List<GraphicsInstance>();
        
        private static GraphicsManager _instance;

        private void Awake()
        {
            _instance = this;
        }
        
        private void Update()
        {
            foreach (var graphicsObject in _graphicsObjects)
            {
                graphicsObject.Draw();
            }
        }
        
        public static GraphicsInstance New(GraphicsObject graphicsObject)
        {
            var instance = new GraphicsInstance(graphicsObject, _instance._graphicsObjects.Count);
            _instance._graphicsObjects.Add(instance);
            return instance;
        }

        public static void DeleteInstance(int foliageInstanceIndex, int foliageIndex)
        {
            _instance._graphicsObjects[foliageInstanceIndex].RemoveInstance(foliageIndex);
        }

        public static void DeleteInstance(GridObject.Tile tile)
        {
            _instance._graphicsObjects[tile.Foliage.InstanceIndex].RemoveInstance(tile.Foliage.FoliageIndex);

        }
    }
}
