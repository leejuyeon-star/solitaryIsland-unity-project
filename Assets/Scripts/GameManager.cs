using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //다른 클래스에서 객체생성 없이 사용할 수 있게 함
    
    public struct trashCount
    {
        public int trashTouchCount;     //지금까지 터치한 쓰레기 개수
        public int trashCurrentCount;   // 현재 활성화된 쓰레기 개수
    }
    public trashCount _trashCount;

    public int playDay;     //날짜
    private int animalCountSum; //모든 동물 수
    private int animalCount0;  //동물 수
    private int animalCount1;  //동물 수
    private int animalCount2;  //동물 수
    private int animalCount3;  //동물 수
    private int animalCount4;  //동물 수
    private int animalCount5;  //동물 수
    private int animalCount6;  //동물 수
    private int animalCount7;  //동물 수
    private int animalCount8;  //동물 수
    private int animalCount9;  //동물 수



    private void Awake() 
    {
        Instance = this; 

        PlayerPrefs.SetInt("trashCurrentCount", 5);     //!로드될 쓰레기 양 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount0", 1);           //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount1", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount2", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount3", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount4", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount5", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount6", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount7", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount8", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCount9", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        PlayerPrefs.SetInt("animalCountSum", 10);

        // 데이터 불러오기
        _trashCount.trashTouchCount = PlayerPrefs.GetInt("trashTouchCount");
        _trashCount.trashCurrentCount = PlayerPrefs.GetInt("trashCurrentCount");
        playDay = PlayerPrefs.GetInt("playDay");
        animalCount0 = PlayerPrefs.GetInt("animalCount0");
        animalCount1 = PlayerPrefs.GetInt("animalCount1");
        animalCount2 = PlayerPrefs.GetInt("animalCount2");
        animalCount3 = PlayerPrefs.GetInt("animalCount3");
        animalCount4 = PlayerPrefs.GetInt("animalCount4");
        animalCount5 = PlayerPrefs.GetInt("animalCount5");
        animalCount6 = PlayerPrefs.GetInt("animalCount6");
        animalCount7 = PlayerPrefs.GetInt("animalCount7");
        animalCount8 = PlayerPrefs.GetInt("animalCount8");
        animalCount9 = PlayerPrefs.GetInt("animalCount9");
        animalCountSum = PlayerPrefs.GetInt("animalCountSum");
    }



    //object가 파괴될 때, Scene이 변경될 때, 게임이 종료될 때 1회 호출
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("trashTouchCount", _trashCount.trashTouchCount);
        PlayerPrefs.SetInt("trashCurrentCount", _trashCount.trashCurrentCount);
        PlayerPrefs.SetInt("playDay", playDay);
        PlayerPrefs.SetInt("animalCount0", animalCount0);
        PlayerPrefs.SetInt("animalCount1", animalCount1);
        PlayerPrefs.SetInt("animalCount2", animalCount2);
        PlayerPrefs.SetInt("animalCount3", animalCount3);
        PlayerPrefs.SetInt("animalCount4", animalCount4);
        PlayerPrefs.SetInt("animalCount5", animalCount5);
        PlayerPrefs.SetInt("animalCount6", animalCount6);
        PlayerPrefs.SetInt("animalCount7", animalCount7);
        PlayerPrefs.SetInt("animalCount8", animalCount8);
        PlayerPrefs.SetInt("animalCount9", animalCount9);
        PlayerPrefs.SetInt("animalCountSum", animalCountSum);
    }


    //해당 동물 오브젝트에 맞는 animalCount 반환
    public ref int MappingAnimalCount(GameObject obj)
    {
        if(obj.name == "bear")
        {
            return ref GameManager.Instance.animalCount0;
        }
        else if(obj.name == "bull")
        {
            return ref GameManager.Instance.animalCount1;
        }
        else if(obj.name == "camel")
        {
            return ref GameManager.Instance.animalCount2;
        }
        else if(obj.name == "chick")
        {
            return ref GameManager.Instance.animalCount3;
        }
        else if(obj.name == "chicken")
        {
            return ref GameManager.Instance.animalCount4;
        }
        else if(obj.name == "cock")
        {
            return ref GameManager.Instance.animalCount5;
        }
        else if(obj.name == "cow")
        {
            return ref GameManager.Instance.animalCount6;
        }
        else if(obj.name == "deer")
        {
            return ref GameManager.Instance.animalCount7;
        }
        else if(obj.name == "dog")
        {
            return ref GameManager.Instance.animalCount8;
        }
        else if(obj.name == "dove")
        {
            return ref GameManager.Instance.animalCount9;
        }
        else
        {
            Debug.Log(" error!! GameManager의 MappingAnimalCount 오류!");
            return ref GameManager.Instance.animalCount0;
        }
    }

    
    public void PlusAnimalCount(GameObject Obj)
    {
        MappingAnimalCount(Obj)++;
        animalCountSum++;
        return;
    }

    public void MinusAnimalCount(GameObject Obj)
    {
        MappingAnimalCount(Obj)--;
        animalCountSum--;
        return;
    }

    public int GetAnimalCountSum()
    {
        return animalCountSum;
    }
    

}
