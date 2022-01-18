using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
	[SerializeField] private Joystick joystick;
	[SerializeField] private Player player;
	[SerializeField] private Gun gun;
	[SerializeField] private Bullet bullet;
	[Header("LevelObjects")]
	[SerializeField] private Pickable pickable;
	[SerializeField] private Movable movable;
	[SerializeField] private Breakable breakable;
	public override void InstallBindings()
	{
		Container.Bind<IController>().To<Joystick>().FromInstance(joystick).AsSingle().NonLazy();
		Container.Bind<Player>().FromComponentInNewPrefab(player).AsSingle().NonLazy();
		Container.BindFactory<Gun, Gun.Factory>().FromComponentInNewPrefab(gun).AsSingle().NonLazy();
		Container.BindFactory<WeaponData, Bullet, Bullet.Factory>().FromComponentInNewPrefab(bullet).AsSingle().NonLazy();
		Container.BindFactory<Pickable, Pickable.Factory>().FromComponentInNewPrefab(pickable).AsSingle();
		Container.BindFactory<Movable, Movable.Factory>().FromComponentInNewPrefab(movable).AsSingle();
		Container.BindFactory<Breakable, Breakable.Factory>().FromComponentInNewPrefab(breakable).AsSingle();
	}
}
