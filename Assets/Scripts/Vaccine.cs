using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _vaccineSpawn;
 
    
    // Start is called before the first frame update
    /*void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y. 0f);
    } */
    
  
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        
        _selfdestruct();
        
        this.transform.parent = GameObject.Find("VaccineSpawn").transform;
    }

    private void _selfdestruct()
    {
        if (transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void _setParent()
    {
        this.transform.parent = GameObject.Find("VaccineSpawn").transform;
    }
} 
