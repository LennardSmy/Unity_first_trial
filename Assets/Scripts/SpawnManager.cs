using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("External Components")]
    [SerializeField]
    private GameObject _coronaPrefab;

    [SerializeField]
    private GameObject _UVLightPrefab;

    [Header("Overall Spawn Behaviour")]
    [SerializeField]
    private bool _spawningOn = true;
    [SerializeField]
    private float _powerUpSpawnRate = 15f;
    [SerializeField]
    private float _delay = 2f;
    
    //bools to turn on and off the spawning of the respective game object
    [Header("PowerUps Spawn")]
    [SerializeField] 
    private bool _uvLightSpawnOn = true;

    [Header("Enemy Spawn")]
    [SerializeField] 
    private bool _coronaSpawnOn = true;
    
  

    

    void Start()
    {
        StartCoroutine(SpawnSystem());
        StartCoroutine(SpawnPowerUp());

    }

    // Update is called once per frame
    void Update()
    {

    }
    //T
    public void playerDead()
    {
        _spawningOn = false;
    }

    IEnumerator SpawnSystem()
    {
        //this while loop should go until the game is finished or one enters a new scene. 
        
        while (_spawningOn && _coronaSpawnOn)
        {
            Instantiate(_coronaPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0f),Quaternion.identity,this.transform);
           
            yield return new WaitForSeconds(_delay);
        }

        if (_spawningOn == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        Debug.Log("power ups enabled");
        while (_spawningOn && _uvLightSpawnOn)
        {
            Instantiate(_UVLightPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0f),Quaternion.identity,this.transform);
            yield return new WaitForSeconds(_powerUpSpawnRate);
        }
        if (_spawningOn == false)
        {
            Destroy(this.gameObject);
        }
    }
}
