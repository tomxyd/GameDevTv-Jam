using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject starPrefab;
    [SerializeField] Transform[] starSpawnPoint;

    private static GameManager _instance = null;

    public PlayerCharacter playerStats { get; }
    public static GameManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
