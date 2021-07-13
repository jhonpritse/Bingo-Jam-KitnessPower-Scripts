using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModifer : MonoBehaviour
{
    public bool isSizeBig;
    public bool isSizeSmall;
    public bool isSizeNormal;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (isSizeBig) BigSize(other);
        else if (isSizeNormal) NormalSize(other);
        else if (isSizeSmall) SmallSize(other);
    }
    
    void NormalSize(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            var parent = GameObject.Find("PlayerHolder").transform;
            foreach (Transform player in parent)
            {
                var scale = other.transform.localScale;
                var scaleX = scale.x;
                var scaleY = scale.y;
                player.GetComponent<CircleCollider2D>().radius = .38f;
                player.transform.Find("Circle").localScale =  new Vector3(scaleX*1f, scaleY*1f);
            }
            foreach (Transform bone in other.GetComponent<Transform>().Find("Circle").transform)
            {
                bone.GetComponent<Rigidbody2D>().mass = 1.5f;
            }
            
            Destroy(gameObject);
        }  
    }
    void SmallSize(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            var parent = GameObject.Find("PlayerHolder").transform;
            foreach (Transform player in parent)
            {
                var scale = other.transform.localScale;
                var scaleX = scale.x;
                var scaleY = scale.y;
                player.GetComponent<CircleCollider2D>().radius = .18f;
                player.transform.Find("Circle").localScale =  new Vector3(scaleX*.5f, scaleY*.5f);
            }
            foreach (Transform bone in other.GetComponent<Transform>().Find("Circle").transform)
            {
                bone.GetComponent<Rigidbody2D>().mass = 1.2f;
            }
            
            Destroy(gameObject);
        }  
    }
    void BigSize(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            var parent = GameObject.Find("PlayerHolder").transform;
            foreach (Transform player in parent)
            {
                var scale = other.transform.localScale;
                var scaleX = scale.x;
                var scaleY = scale.y;
                player.GetComponent<CircleCollider2D>().radius = .78f;
                player.transform.Find("Circle").localScale =  new Vector3(scaleX*2f, scaleY*2f);
            } 
           
            foreach (Transform bone in other.GetComponent<Transform>().Find("Circle").transform)
            {
                bone.GetComponent<Rigidbody2D>().mass = 1.6f;
            }
            
            Destroy(gameObject);
        }
        
        
    }

}
