using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();

            if(player != null)
            {
                player.UpdatePlayerStars();
                Destroy(this.gameObject);
            }

            if(player.stars == 4)
            {
                Debug.Log("Game Completed");
            }
        }
    }
}
