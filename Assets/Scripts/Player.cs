using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _experience;
    [SerializeField] private float _speed;
    [SerializeField] private int _attack;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _stamina;
    [SerializeField] private int _magic;
    [SerializeField] private int _magicPower;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The Player Level before is " + _level);

        PlayerManager.instance.GetPlayerValues(out _level, out _experience, out _speed, out _attack, out _maxHealth, out _stamina, out _magic, out _magicPower);

        Debug.Log("The Player Level after is " + _level);

        PlayerManager.onLevelUp += PlayerManager_onLevelUp;
    }

    private void PlayerManager_onLevelUp()
    {
        PlayerManager.instance.GetPlayerValues(out _level, out _experience, out _speed, out _attack, out _maxHealth, out _stamina, out _magic, out _magicPower);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _experience = PlayerManager.instance.AddExp(10);

            Debug.Log("The Player Experience is " + _experience);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Scene scene = SceneManager.GetActiveScene();
            
            if(scene.name == "SampleScene")
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
