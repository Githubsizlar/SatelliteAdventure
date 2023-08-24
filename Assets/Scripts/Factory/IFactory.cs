using UnityEngine;

namespace Factory
{
    public interface IFactory 
    {
        T CreateObject<T>() where T : MonoBehaviour;
        T CreateObject<T>(int varianId) where T : MonoBehaviour;
        T CreateObject<T>(Transform parent) where T : MonoBehaviour;
        T CreateObject<T>(int varianId, Transform parent) where T : MonoBehaviour;
    }
}