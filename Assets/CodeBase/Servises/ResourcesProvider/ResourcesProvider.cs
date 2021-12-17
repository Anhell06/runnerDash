using UnityEngine;

public class ResourcesProvider : IService, IResourcesProvider
{
    public TObject LoadObject<TObject>(string path) where TObject : Object
    {
        return Resources.Load<TObject>(path);
    }
    
}
