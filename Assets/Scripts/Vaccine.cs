using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [Header("Vaccine Parameters")]
    [SerializeField]
    private float _speed = 5f;

    [SerializeField] 
    private float _spinSpeed = 200f;

    [SerializeField] 
    private bool _rotationOn = true;

    //[SerializeField] 
    //private GameObject _Player; 
    
    
    // Start is called before the first frame update
    /*void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y. 0f);
    } */
    
  
    

    // Update is called once per frame
    void Update()
    {
        if (_rotationOn)
        {
            transform.Rotate(new Vector3(0f,_spinSpeed * Time.deltaTime, 0f), Space.Self);
        }
       

        transform.Translate(Vector3.up * Time.deltaTime * _speed);

        _selfdestruct();
        
       _setParent();
    }

    private void _selfdestruct()
    {
        if (transform.position.y > 6f )
        {
            Destroy(this.gameObject);
        }
    }

    private void _setParent()
    {
        this.transform.parent = GameObject.Find("VaccineSpawn").transform;
    }
} 
