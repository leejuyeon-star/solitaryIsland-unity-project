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
    public int animalCount;  //동물 수

    public GameObject _garbageUI;


    private void Awake() 
    {
        Instance = this; 

        // 데이터 불러오기
        _trashCount.trashTouchCount = PlayerPrefs.GetInt("trashTouchCount");
        _trashCount.trashCurrentCount = PlayerPrefs.GetInt("trashCurrentCount");
        playDay = PlayerPrefs.GetInt("playDay");
        // animalCount = PlayerPrefs.GetInt("animalCount");
    }



    //object가 파괴될 때, Scene이 변경될 때, 게임이 종료될 때 1회 호출
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("trashTouchCount", _trashCount.trashTouchCount);
        PlayerPrefs.SetInt("trashCurrentCount", _trashCount.trashCurrentCount);
        PlayerPrefs.SetInt("playDay", playDay);
        // PlayerPrefs.SetInt("animalCount", animalCount);
    }



    public void printgarbageUI()
    {
        _garbageUI.GetComponent<garbageUI>().printUI();
        return;
    }

}
