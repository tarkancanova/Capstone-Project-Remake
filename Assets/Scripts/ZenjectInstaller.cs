using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerAction>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Gravity>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Projectile>().FromComponentInHierarchy().AsTransient();
        Container.Bind<PlayerInventory>().FromComponentInHierarchy().AsSingle();
    }
}
