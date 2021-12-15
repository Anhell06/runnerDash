using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesProvider : IService, IResourcesProvider
{
    public TObject InstantiateObject<TObject>(string path) where TObject : Object
    {
        return Object.Instantiate(Resources.Load<TObject>(path));
    }

    public TObject InstantiateObject<TObject>(string path, Vector3 at) where TObject : Object
    {
        return Object.Instantiate(Resources.Load<TObject>(path), at, Quaternion.identity);
    }

    public TObject InstantiateObject<TObject>(string path, Vector3 at, Quaternion quaternion) where TObject : Object
    {
        return Object.Instantiate(Resources.Load<TObject>(path), at, quaternion);
    }

}
