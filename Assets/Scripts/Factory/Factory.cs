using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Factory
{
    public class Factory : IFactory
    {
        List<MonoBehaviour> _prefabs = new();

        public static IFactory Instance { get; private set; } = new Factory();

        public Factory()
        {
            GameObject[] allPrefabs = Resources.LoadAll<GameObject>("");
            foreach (GameObject prefab in allPrefabs)
            {
                MonoBehaviour obj = prefab.GetComponent<MonoBehaviour>();
                if (obj == null)
                    continue;

                if (!_prefabs.Contains(obj))
                    _prefabs.Add(obj);
            }
        }

        public T CreateObject<T>() where T : MonoBehaviour
        {
            Type type = typeof(T);
            MonoBehaviour? obj = _prefabs.Find(x => x.GetType().Equals(type) );
            if (obj == null)
            {
                Debug.Log($"Object not found: {type.GetType().FullName}");
                return default;
            }
            return (T)UnityEngine.Object.Instantiate(obj);
        }

        public T CreateObject<T>(int varianId) where T : MonoBehaviour
        {
            return CreateObject<T>(varianId);
        }
        public T CreateObject<T>( Transform parent) where T : MonoBehaviour
        {
            Type type = typeof(T);
            MonoBehaviour? obj = _prefabs.Find(x => x.GetType().Equals(type) );
            if (obj == null)
            {
                Debug.Log($"Object not found: {type.GetType().FullName}");
                return default;
            }

            return (T)UnityEngine.Object.Instantiate(obj, parent);
        }
        public T CreateObject<T>(int varianId, Transform parent) where T : MonoBehaviour
        {
            Type type = typeof(T);
            MonoBehaviour? obj = _prefabs.Find(x => x.GetType().Equals(type));
            if (obj == null)
            {
                Debug.Log($"Object not found: {type.GetType().FullName}");
                return default;
            }

            return (T)UnityEngine.Object.Instantiate(obj, parent);
        }

    }
}