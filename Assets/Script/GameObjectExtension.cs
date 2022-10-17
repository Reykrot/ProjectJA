using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace UnityEngine
{
    public static class GameObjectExtension
    {
        public static Entity FindEntityInChildWithTag<Entity>(this GameObject parent, string tag) where Entity : class
        {
            Entity[] entities = parent.GetComponentsInChildren<Entity>();
            return FindIt<Entity>(entities, tag);
        }

        public static GameObject FindGameObjectInChildWithTag(this GameObject parent, string tag)
        {
            Transform t = parent.transform;
            foreach (Transform tr in t)
            {
                if (tr.tag == tag)
                {
                    return tr.gameObject;
                }
            }
            return null;
        }

        public static GameObject[] FindGameObjectsInChildWithTag(this GameObject parent, string tag)
        {
            List<GameObject> toReturn = new List<GameObject>();
            Transform t = parent.transform;
            foreach (Transform tr in t)
            {
                if (tr.tag == tag)
                {
                    toReturn.Add(tr.gameObject);
                }
            }
            return toReturn.ToArray();
        }

        public static GameObject[] GetAllChildren(this GameObject parent)
        {
            List<GameObject> toReturn = new List<GameObject>();
            Transform t = parent.transform;
            foreach (Transform tr in t)
            {
                toReturn.Add(tr.gameObject);
            }
            return toReturn.ToArray();
        }

        public static Entity FindIt<Entity>(Entity[] entities, string tag)
        {
            foreach (Entity entity in entities)
            {
                if ((entity as ICanvasElement).transform.tag == tag)
                {
                    return entity;
                }
            }
            // TODO gestire l'eccezione? qualcosa toccava mettilo e null giustamente non gli va in culo
            throw new Exception();
        }
        public static Transform GetTransformFromParent(this GameObject gameObject)
        {
            return gameObject.transform.parent;
        }
        //public static ComponentLocator GetComponentLocator(this GameObject gameObject)
        //{
        //    var componentLocator = gameObject.scene.GetRootGameObjects().ToList().FirstOrDefault(x => x.tag == "ComponentLocator").GetComponent<ComponentLocator>();

        //    return componentLocator;
        //}
    }
}