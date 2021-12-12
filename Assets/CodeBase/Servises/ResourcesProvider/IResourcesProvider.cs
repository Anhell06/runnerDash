using UnityEngine;

public interface IResourcesProvider : IService
{
    TObject InstantiateObject<TObject>(string path) where TObject : Object;
    TObject InstantiateObject<TObject>(string path, Vector3 at) where TObject : Object;
    TObject InstantiateObject<TObject>(string path, Vector3 at, Quaternion quaternion) where TObject : Object;
}