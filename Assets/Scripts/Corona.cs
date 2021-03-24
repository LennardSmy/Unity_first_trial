 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using Random = UnityEngine.Random;

 public class Corona : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    void Update()
    {
        transform.Translate(Vector3.down *_speed * Time.deltaTime);
        if (transform.position.y < -6f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0f);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
      // Debug.Log(other.name);
        // if the object we collide with is the player
       if (other.CompareTag("Player"))
       {
            //damage player or destroy it
            other.GetComponent<Player>().Damage();
            //Debug.LogWarning("player health not implemented");
          
           
           //and destroy the gameobject corona
           Destroy(this.gameObject);
           
       }
       //but if the other one is the vaccine
       else if (other.CompareTag("Vaccine"))
       {
           //destroy the vaccine and the virus
           Destroy(other.gameObject);
           Destroy(this.gameObject);
           
       }
       
       
       
    }

    /*
    [SerializeField] 
    private GameObject _CoronaPrefab;
    [SerializeField] 
    private float _coronaRate = 2f;
    
    // I tried doing this as 0 but then it never even enters the if clause in the _Coronapos() method
    private float _nextFire = 0f;
    
   [SerializeField]
    private float _speed = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // i tried to have different methods for each step im doing
        _CoronaPos();
        _CoronaMove();
        _SelfDestruct();

    }
    
    //When this method is called it should check if enough time has passed,
    //then adjust the new timepoint for the next corona intsantiation,
    //then it should create a vector with the help of calling the _RandomFloat() method
    //and then it should initiate the gameobject _CoronaPrefab
    private void _CoronaPos()
    {
        if (Time.time > _nextFire)
        {
            Debug.Log("hallo");
            _nextFire = Time.time + _coronaRate;
            
            var coronaPos = new Vector3(_RandomFloat(), 6f, 0f);
            Instantiate(_CoronaPrefab, coronaPos, Quaternion.identity);
        }

    }
    
    //this method should then refer to gameobject just created and transform its position according to the vector below
    private void _CoronaMove()
    {
        this.gameObject.transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
    
    // this method should delete/destroy any created gameobject when it crosses the indicated border
    private void _SelfDestruct()
    {
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
    
    // this method simply returns a random float limited by the indicated borders. 
    private float _RandomFloat()
    {
       float coronaRange = Random.Range(-3.8f, 3.8f);

        return coronaRange;

    }
    */
}
