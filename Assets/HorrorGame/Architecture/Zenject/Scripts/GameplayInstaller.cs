using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameObject _mainCharacterPrefab;
    [SerializeField] private Transform _spawnPointMainCharacter;

    public override void InstallBindings()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>
            (_mainCharacterPrefab, _spawnPointMainCharacter.position, Quaternion.identity, null);

        Container.Bind<Character>().FromInstance(character).AsSingle();
    }
}
