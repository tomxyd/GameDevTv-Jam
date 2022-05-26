using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContainer : MonoBehaviour
{
    [SerializeField] GameObject starPrefab;
    private GameObject star;

    private void OnEnable()
    {
        PlayerCharacter.OnDeath += SpawnStars;
    }

    private void OnDisable()
    {
        PlayerCharacter.OnDeath -= SpawnStars;
    }


    private void Start()
    {
        SpawnStars();
    }

    void SpawnStars()
    {

        if (star == null)
        {
            star = Instantiate(starPrefab) as GameObject;
            star.transform.position = this.transform.position;
        }
    }
}
