using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float obstacleRange;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, .5f, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                PlayerCharacter player = hitObject.GetComponent<PlayerCharacter>();
                player.Die(1f);
                Destroy(this.gameObject);
            }else if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110f, 110f);
                transform.Rotate(0, angle, 0);
            }

        }
    }
}
