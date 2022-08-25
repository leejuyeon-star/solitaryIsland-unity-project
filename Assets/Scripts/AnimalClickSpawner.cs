using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClickSpawner : MonoBehaviour
{
    public GameObject spawnAnimal;
    public GameObject AnimalParent;
    public Vector3 spawnPosition;
    public GameObject _NoPointAlarm;


    public int animalPoint;

    private void Start()
    {
    }

    

    // 해당 동물 Instantiate
    public void OnClickButton()
    {
        // 해당 동물의 포인트 <= 현 포인트 라면, 포인트--
        if(animalPoint <= GameManager.Instance._trashCount.trashTouchCount)
        {
            GameManager.Instance._trashCount.trashTouchCount -= animalPoint;
            GameManager.Instance.printgarbageUI();
            int index;
            GameObject newObj = Instantiate(spawnAnimal); 
            newObj.transform.position = spawnPosition;
            newObj.transform.parent = AnimalParent.transform;
            newObj.transform.localScale = new Vector3(10,10,10);
            index = newObj.name.IndexOf("(Clone)");
            if (index > 0) 
                newObj.name = newObj.name.Substring(0, index);
            GameManager.Instance.MappingAnimalCount(newObj)++;
        }
        else
        {
            //! Text로 포인트가 부족합니다 내보내기
            _NoPointAlarm.SetActive(true);
        }
        return;
    }

    
}
