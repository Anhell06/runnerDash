using Assets.CodeBase.InputService;
using Assets.CodeBase.PlayerComponent;
using Assets.CodeBase.Servises.ProgressService;
using UnityEngine;

namespace Assets.CodeBase.Servises.LevelFactory
{
    public class LevelFactory : ILevelFactory
    {
        private readonly IInputObservableService _inputService;
        private readonly IResourcesProvider _resourcesProvider;
        private readonly IProgressDataServise _progress;

        public LevelFactory(IInputObservableService inputService, IResourcesProvider resourcesProvider, IProgressDataServise progress)
        {
            _inputService = inputService;
            _resourcesProvider = resourcesProvider;
            _progress = progress;
        }

        public void LoadHUD()
        {
            InputServiceBehaviour UIRoot = Object.Instantiate(_resourcesProvider
                .LoadObject<GameObject>(Constants.ConstantResourcesPath.UIRoot))
                .GetComponentInChildren<InputServiceBehaviour>();

            UIRoot.Constract(_inputService);
        }

        public void LoadPlayer()
        {
            GameObject player = Object.Instantiate(_resourcesProvider.LoadObject<GameObject>(Constants.ConstantResourcesPath.Player));
            player.GetComponentInChildren<PlayerMediator>().Constract(_inputService, _progress);

            Camera.main.gameObject.AddComponent<CameraFollow>()
                .Follow(the: player.transform, withOffset: new Vector3(0, 0, -10));
        }
    }
}
