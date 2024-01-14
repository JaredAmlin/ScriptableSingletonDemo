using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[FilePath("Managers/StateFile.foo", FilePathAttribute.Location.PreferencesFolder)]
public class PlayerManager : ScriptableSingleton<PlayerManager>
{
    [SerializeField] private int _playerLevel = 1;
    [SerializeField] private int _experience;
    [SerializeField] private int _experienceToLevelUp = 50;
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _attack = 150;
    [SerializeField] private int _maxHealth = 800;
    [SerializeField] private int _stamina = 100;
    [SerializeField] private int _magic = 100;
    [SerializeField] private int _magicPower = 70;

    public static event Action onLevelUp;

    public int AddExp(int exp)
    {
        _experience += exp;
        _experienceToLevelUp -= exp;

        Save(true);

        if (_experienceToLevelUp <= 0)
        {
            LevelUp();

            onLevelUp?.Invoke();
        }

        return _experience;
    }

    public void LevelUp()
    {
        _playerLevel++;
        _experienceToLevelUp = 50;
        _speed += 0.2f;
        _attack += 10;
        _maxHealth += 50;
        _stamina += 5;
        _magic += 10;
        _magicPower += 8;

        Save(true);

        Debug.Log("Saved to: " + GetFilePath());

        Debug.Log("MySingleton state: " + JsonUtility.ToJson(this, true));
    }

    public void GetPlayerValues(out int level, out int exp, out float speed, out int attack, out int health, out int stamina, out int magic, out int magicPower)
    {
        level = _playerLevel;
        exp = _experience;
        speed = _speed;
        attack = _attack;
        health = _maxHealth;
        stamina = _stamina;
        magic = _magic;
        magicPower = _magicPower;
    }
}
