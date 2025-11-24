using UnityEngine;
using Zenject;

public class InputActionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameInputAction>().AsSingle().NonLazy(); 
    }
}

