using UnityEngine;

public interface IResourcesProvider : IService
{
    TObject LoadObject<TObject>(string path) where TObject : Object;
}