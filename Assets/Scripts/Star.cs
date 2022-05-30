using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    AudioSource audioData;


    private void Start()
    {
        audioData = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            audioData.Play();
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();

            if(player != null)
            {
                player.UpdatePlayerStars();
                StartCoroutine(Die());
            }

            if(player.stars == 4)
            {
                Debug.Log("Game Completed");
            }
        }
    }
    IEnumerator Die()
    {
        audioData.Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
