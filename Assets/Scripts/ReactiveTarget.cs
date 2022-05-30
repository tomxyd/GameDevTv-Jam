using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] float health;

    AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    public void Die(float damage)
    {
        audioData.Play();
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log("Hit");
    }
}
