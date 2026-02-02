using System;
using Code.Gameplay;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private BattleFeature _battleFeature;

        private GameContext _gameContext;
        private ITimeService _time;
        private IInputService _input;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(GameContext gameContext, ITimeService time, IInputService input, ICameraProvider cameraProvider)
        {
            _gameContext = gameContext;
            _time = time;
            _input = input;
            _cameraProvider = cameraProvider;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _time, _input, _cameraProvider);
            _battleFeature.Initialize();
        }
        
        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }
        
        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}