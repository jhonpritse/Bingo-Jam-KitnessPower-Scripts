using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squasher : MonoBehaviour
{
    public float floatFreqY;
    public float floatHeightY;
    private float posY;
    private float posX;
    
    void Start()
    {
        posY = transform.position.y;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        var transform1 = transform;
            posX = transform1.position.x;
            transform.position = new Vector3(posX, posY) +
                                 transform1.up * (Mathf.Sin(Time.timeSinceLevelLoad * floatFreqY) * floatHeightY);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var particleManager = GameObject.Find("Particle Manager").GetComponent<ParticleManager>();
        if (other.transform.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            foreach (var contact in other.contacts)
            {
                var hit = Instantiate(particleManager.splat, contact.point, Quaternion.identity);
                var rad =  other.transform.GetComponent<CircleCollider2D>().radius;
                var scale = new Vector2(rad, rad);
                hit.transform.localScale = scale*1.2f;
                var rot = Random.Range(0, 360);
                hit.transform.eulerAngles = Vector3.forward * rot;
                hit.transform.parent = gameObject.transform;
            }
            Destroy(other.gameObject);
        }
      
    }
}
