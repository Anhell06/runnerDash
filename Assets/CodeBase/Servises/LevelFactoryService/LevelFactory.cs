using Assets.CodeBase.InputService;
using UnityEngine;

namespace Assets.CodeBase.Servises.LevelFactory
{
    public class LevelFactory : ILevelFactory
    {
        private readonly IInputObservableService _inputService;
        private readonly IResourcesProvider _resourcesProvider;

        public LevelFactory(IResourcesProvider resourcesProvider, IInputObservableService inputService)
        {
            _inputService = inputService;
            _resourcesProvider = resourcesProvider;
        }

        public void LoadHUD()
        {
            InputServiceBehaviour UIRoot = _resourcesProvider
                .InstantiateObject<GameObject>(Constants.ConstantResourcesPath.UIRoot)
                .GetComponentInChildren<InputServiceBehaviour>();

            UIRoot.Constract(_inputService);
        }
    }
}
