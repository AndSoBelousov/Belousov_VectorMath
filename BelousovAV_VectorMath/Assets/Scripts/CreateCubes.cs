
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    // префабы тонеля и игроков
    private GameObject _prefabPOne;
    private GameObject _prefabPTwo;

    public GameObject[] _levels;

    [Header("Set Dynamiclly")]
    public int _level;
    public int _levelMax;
    // местоположения респа игроков 
    private Transform _spawnPOne;
    private Transform _spawnPTwo;
 
    private GameObject _prefabLevel;

    private int _nextLevelPoints = 10;

    [SerializeField, Range(5, 30)]
    private int _countOfCubes;
    //private List<GameObject> Cubes;

    private float _deltaZ = 7;
    private float _deltaXY = 4;

    private void Start()
    {
        _level = 0;
        _levelMax = _levels.Length;
        StartLevel();
    }

    private void FixedUpdate()
    {
        if(GameManager._countOfPoints >= _nextLevelPoints)
        {
            Invoke("NextLevel", 2);
            _nextLevelPoints += 20;
        }
    }

    private void NextLevel()
    {
        _level++;
        if(_level == _levelMax)
        {
            _level = 0;
        }
        StartLevel();
    }
    private void StartLevel()
    {
        // уничтожаем прошлый уровень если он есть 
        if (_prefabLevel != null)
        {
            Destroy(_prefabLevel);
            Destroy(_prefabPOne);
            Destroy(_prefabPTwo);
        }

        //уничтожить прежние снаряды, если они существуют
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        // создаем новый уровень 
        _prefabLevel = Instantiate<GameObject>(_levels[_level]);

        _spawnPOne = FindObjectOfType<SpawnOne>().transform;
        _spawnPTwo = FindObjectOfType<SpawnTwo>().transform;

        _prefabPOne = Instantiate(Resources.Load("Prefabs/FirstPlayer"),
            _spawnPOne.transform.position,
            transform.rotation ) as GameObject;
        _prefabPTwo = Instantiate(Resources.Load("Prefabs/SecondPlayer"), _spawnPTwo.transform.position, transform.rotation) as GameObject;
        CreatingCubes();

        _countOfCubes += 20;
    }

    private void CreatingCubes()
    {
        for (; _countOfCubes > 0; _countOfCubes--)
        {
            if (_level == 1) { _deltaZ = 10; }
            else _deltaZ = 7;
            
            float z = Random.Range(-_deltaZ, _deltaZ);
            float y = Random.Range(-_deltaXY, _deltaXY);
            float x = Random.Range(-_deltaXY, _deltaXY);
            Vector3 RandomSpawn = new Vector3(x, y, z);

            GameObject cube = Instantiate(Resources.Load("Prefabs/Cube"), RandomSpawn, Random.rotation) as GameObject;  
            Color _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.8f);
            cube.GetComponent<Renderer>().material.color = _color;
            cube.GetComponent<Light>().color = _color;
            
        }
    }
        
}
