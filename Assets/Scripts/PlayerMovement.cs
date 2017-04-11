using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float xmin = -5;
    public float xmax = 5;
    public float padding = 1f;
    public GameObject Projectile;
    public float projectileSpeed;
    private Rigidbody2D rb;
    public float fireRate = 0.5f;
    public float health = 250f;
    public AudioClip fireSound;
    private bool Upgrade = false;
    private float timeLeft = 0;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    void Fire(){
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(Projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    
    FireData fireData = new FireData { 
    fireRate = 0.5f 
    };
    
    void Update(){
        if (timeLeft > 0){
            timeLeft -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            fireDate.fireRate = true;
            }
        if (fireData.fireRate){
            InvokeRepeating("Fire", 0.000001f, fireRate);
            }
        if (Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Fire");
            }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.position += Vector3.left * speed * Time.deltaTime;
            }
        else if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * speed * Time.deltaTime;
            }
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }

    void PowerUp()
    {
        Upgrade = true;
        timeLeft = +5f;
        if (Upgrade == true)
        {
            fireData.fireRate = 0.1f;
        }
        if (timeLeft <= 0)
        {
            Upgrade = false;
            fireData.fireRate = 0.5f;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        ball item = collider.gameObject.GetComponent<ball>();
        laser missile = collider.gameObject.GetComponent<laser>();
        if (item){
            Debug.Log("Got item");
            item.Hit();
            PowerUp();
         }
        if (missile){
            Debug.Log("Player hit");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0){
                Die();
            }
        }
    }
    void Die(){
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}

public class FireData
{
    public float fireRate = 0.1;
}
     
