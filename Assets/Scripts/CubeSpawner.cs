using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
   [SerializeField]
   private GameObject _cubePrefab;
   [SerializeField]
   private float _stepDistance = 0.4f;
   [SerializeField]
   private float _timeBetweenSpawn = 0.04f;
   [SerializeField]
   private int _xCount = 20;
   [SerializeField]
   private int _yCount = 20;
   [SerializeField]
   private GameObject _changeColorButton;
   [SerializeField]
   private float _timeBetweenChangeColor = 0.08f;

   private Vector3 spawnPosition;
   private float startXPosition;
   private List<GameObject> cubes = new List<GameObject>();
   private Color randomColor;

   private void Start()
   {
      spawnPosition = new Vector3(-5, 4.5f, 0);
      startXPosition = spawnPosition.x;
      _changeColorButton.SetActive(false);

      SpawnCubes();
   }

   private void SpawnCubes()
   {
      StartCoroutine(SpawnCubesCoroutine());
   }

   private IEnumerator SpawnCubesCoroutine()
   {
      for (int i = 0; i < _yCount; i++)
      {
         for (int j = 0; j < _xCount; j++)
         {
            var cube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity, transform);
            cubes.Add(cube);

            yield return new WaitForSeconds(_timeBetweenSpawn);

            spawnPosition.x += _stepDistance;
         }

         spawnPosition.y -= _stepDistance;
         spawnPosition.x = startXPosition;
      }

      _changeColorButton.SetActive(true);
   }

   public void ChangeColor()
   {
      randomColor = Random.ColorHSV(0, 1, 0.8f, 1, 0, 1, 0, 1);

      StartCoroutine(ChangeColorCoroutine());
   }

   private IEnumerator ChangeColorCoroutine()
   {
      for (int i = 0; i < cubes.Count; i++)
      {
         cubes[i].GetComponent<Cube>().ChangeColor(randomColor);
         yield return new WaitForSeconds(_timeBetweenChangeColor);
      }
   }
}
