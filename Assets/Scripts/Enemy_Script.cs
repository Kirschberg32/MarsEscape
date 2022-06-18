using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 3f;

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if(transform.position.y < -4.5f)
        {
            transform.position = new Vector3(Random.Range(-25f, 25f), 15f, 0f);
        }       
    }


    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Bullet"))
        {
            //Debug.Log("Bullet collision");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player collision");
            Destroy(this.gameObject);
            other.GetComponent<Player>().Damage();
            // damage player
        }

    }
}
