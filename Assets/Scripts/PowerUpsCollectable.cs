using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsCollectable : MonoBehaviour
{
    
    [Header("Collectable Parameters")]
    [SerializeField]
    private float _speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            
            // i think this one could work too when we make the bool _isUVlightOn in the player script public 
           // other.GetComponent<Player>()._isUVLightOn = true;
           //Debug.Log("Collision detected");
           Destroy(this.gameObject);
            other.GetComponent<Player>().ActivatePowerUp();  
           
            

        }
        
    }
}
