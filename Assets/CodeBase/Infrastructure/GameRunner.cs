using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameRunner : MonoBehaviour
  {
    public Bootstrapper BootstrapperPrefab;
    private void Awake()
    {
      var bootstrapper = FindObjectOfType<Bootstrapper>();
      
      if(bootstrapper != null) return;

      Instantiate(BootstrapperPrefab);
    }
  }
}