using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Vector3 lastPosition;

    private int _stars;
    private bool _isAlive;
    public int stars { get { return _stars; } }
    public bool isAlive { get { return _isAlive; } }
    public delegate void DeathAction();
    public static event DeathAction OnDeath;

    private void Start()
    {
        _stars = 0;
    }
    public void Die(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            lastPosition = transform.position;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        _isAlive = false;
        if (OnDeath != null) OnDeath();

        yield return new WaitForSeconds(1f);

        _isAlive = true;
        health = 1;
        _stars = 0;
        transform.position = lastPosition;
    }



    public void UpdatePlayerStars()
    {
        _stars++;
    }
}
