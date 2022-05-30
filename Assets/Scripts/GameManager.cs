using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text starCount;

    private static GameManager _instance = null;

    public PlayerCharacter playerStats;
    public static GameManager instance { get { return _instance; } }

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerCharacter>();
        starCount.text = $"Stars : 0";
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

    private void Update()
    {
        starCount.text = $"Stars : {playerStats.stars}";
    }
}
