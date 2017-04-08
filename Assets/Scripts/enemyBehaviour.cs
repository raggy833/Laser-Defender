using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed = 10;
    public float health = 150f;
    public float shotPerSec = 0.5f;
    public int scoreValue = 150;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private scoreKeeper scoreKeeper;

    void Start(){
       scoreKeeper = GameObject.FindObjectOfType<scoreKeeper>();
    }

    void Update(){
        float probability = Time.deltaTime * shotPerSec;
        if (Random.value < probability){
            Fire();
        }
    }
    void Fire(){
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider){
        
        laser missile = collider.gameObject.GetComponent<laser>();
        if (missile){
            health -= missile.GetDamage();
            missile.Hit();
                if (health <= 0){
                Die();
                }
            }
        }
    void Die(){
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }

}
