using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesProvider : IService, IResourcesProvider
{
    public TObject InstantiateObject<TObject>(string path) where TObject : Object
    {
        TObject gameObject = Resources.Load<TObject>(path);
        Object.Instantiate(gameObject);
        return gameObject;
    }

    public TObject InstantiateObject<TObject>(string path, Vector3 at) where TObject : Object
    {
        TObject gameObject = Resources.Load<TObject>(path);
        Object.Instantiate(gameObject, at, Quaternion.identity);
        return gameObject;
    }

    public TObject InstantiateObject<TObject>(string path, Vector3 at, Quaternion quaternion) where TObject : Object
    {
        TObject gameObject = Resources.Load<TObject>(path);
        Object.Instantiate(gameObject, at, quaternion);
        return gameObject;
    }

}
