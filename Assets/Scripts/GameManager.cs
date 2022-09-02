using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함
using UnityEngine.SceneManagement;      //scene 종료를 위함


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //다른 클래스에서 객체생성 없이 사용할 수 있게 함
    
    public struct trashCount
    {
        public int trashTouchCount;     //지금까지 터치한 쓰레기 개수
        public int trashCurrentCount;   // 현재 활성화된 쓰레기 개수
    }
    public trashCount _trashCount;

    public int garbageCreatePlus;      //레벨 올라갈수록 더해질 쓰레기 개수

    // public int heart;

    public int playDay;     //날짜
    // public int animalCountSum; //모든 동물 수
    // public int animalCount0;  //동물 수
    // public int animalCount1;  //동물 수
    // public int animalCount2;  //동물 수
    // public int animalCount3;  //동물 수
    // public int animalCount4;  //동물 수
    // public int animalCount5;  //동물 수
    // public int animalCount6;  //동물 수
    // public int animalCount7;  //동물 수
    // public int animalCount8;  //동물 수
    // public int animalCount9;  //동물 수

    public bool iscomplete0;
    public bool iscomplete1;
    public bool iscomplete2;
    public bool iscomplete3;
    public bool iscomplete4;
    public bool iscomplete5;

    public GameObject GameOverPanel;
    public GameObject EndingPanel;

    public AudioSource[] bgmMusic;
    public AudioSource[] sfxMusic;

    public enum bgm {START, MAIN};
    public enum sfx {LEVELUP, BUTTON, PICKUP, SPAWNTRASHBAG};
    private int sfxCursor;



    private void Awake() 
    {
        Instance = this; 

        iscomplete0 = PlayerPrefs.GetInt("iscomplete0")==1?true:false;
        iscomplete1 = PlayerPrefs.GetInt("iscomplete1")==1?true:false;
        iscomplete2 = PlayerPrefs.GetInt("iscomplete2")==1?true:false;
        iscomplete3 = PlayerPrefs.GetInt("iscomplete3")==1?true:false;
        iscomplete4 = PlayerPrefs.GetInt("iscomplete4")==1?true:false;
        iscomplete5 = PlayerPrefs.GetInt("iscomplete5")==1?true:false;

        garbageCreatePlus = PlayerPrefs.GetInt("garbageCreatePlus");

        // PlayerPrefs.SetInt("trashCurrentCount", 0);     //!로드될 쓰레기 양 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount0", 1);           //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount1", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount2", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount3", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount4", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount5", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount6", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount7", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount8", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCount9", 1);          //!로드될 동물 수 유지하기 위한 장치 (작품 완성시 지우기)
        // PlayerPrefs.SetInt("animalCountSum", 10);

        // // 데이터 불러오기
        // _trashCount.trashTouchCount = PlayerPrefs.GetInt("trashTouchCount");
        // _trashCount.trashCurrentCount = PlayerPrefs.GetInt("trashCurrentCount");
        // playDay = PlayerPrefs.GetInt("playDay");
        // animalCount0 = PlayerPrefs.GetInt("animalCount0");
        // animalCount1 = PlayerPrefs.GetInt("animalCount1");
        // animalCount2 = PlayerPrefs.GetInt("animalCount2");
        // animalCount3 = PlayerPrefs.GetInt("animalCount3");
        // animalCount4 = PlayerPrefs.GetInt("animalCount4");
        // animalCount5 = PlayerPrefs.GetInt("animalCount5");
        // animalCount6 = PlayerPrefs.GetInt("animalCount6");
        // animalCount7 = PlayerPrefs.GetInt("animalCount7");
        // animalCount8 = PlayerPrefs.GetInt("animalCount8");
        // animalCount9 = PlayerPrefs.GetInt("animalCount9");
        // animalCountSum = PlayerPrefs.GetInt("animalCountSum");
        // heart = PlayerPrefs.GetInt("heart");
        PlayBgm(bgm.START);
    }


    public void ClickGameReset()
    {
        Instance = this; 
        PlayerPrefs.SetInt("iscomplete0", 0);     
        PlayerPrefs.SetInt("iscomplete1", 0);     
        PlayerPrefs.SetInt("iscomplete2", 0);    
        PlayerPrefs.SetInt("iscomplete3", 0);     
        PlayerPrefs.SetInt("iscomplete4", 0);     
        PlayerPrefs.SetInt("iscomplete5", 0);     

        // iscomplete0 = PlayerPrefs.GetInt("iscomplete0")==1?true:false;
        // iscomplete1 = PlayerPrefs.GetInt("iscomplete1")==1?true:false;
        // iscomplete2 = PlayerPrefs.GetInt("iscomplete2")==1?true:false;
        // iscomplete3 = PlayerPrefs.GetInt("iscomplete3")==1?true:false;
        // iscomplete4 = PlayerPrefs.GetInt("iscomplete4")==1?true:false;
        // iscomplete5 = PlayerPrefs.GetInt("iscomplete5")==1?true:false;

        PlayerPrefs.SetInt("garbageCreatePlus", 10);
        // garbageCreatePlus = PlayerPrefs.GetInt("garbageCreatePlus");
        // PlayBgm(bgm.START);
        SceneManager.LoadScene(0);
    }



    //object가 파괴될 때, Scene이 변경될 때, 게임이 종료될 때 1회 호출
    private void OnDestroy()
    {
        // PlayerPrefs.SetInt("trashTouchCount", _trashCount.trashTouchCount);
        // PlayerPrefs.SetInt("trashCurrentCount", _trashCount.trashCurrentCount);
        // PlayerPrefs.SetInt("playDay", playDay);
        // PlayerPrefs.SetInt("animalCount0", animalCount0);
        // PlayerPrefs.SetInt("animalCount1", animalCount1);
        // PlayerPrefs.SetInt("animalCount2", animalCount2);
        // PlayerPrefs.SetInt("animalCount3", animalCount3);
        // PlayerPrefs.SetInt("animalCount4", animalCount4);
        // PlayerPrefs.SetInt("animalCount5", animalCount5);
        // PlayerPrefs.SetInt("animalCount6", animalCount6);
        // PlayerPrefs.SetInt("animalCount7", animalCount7);
        // PlayerPrefs.SetInt("animalCount8", animalCount8);
        // PlayerPrefs.SetInt("animalCount9", animalCount9);
        // PlayerPrefs.SetInt("animalCountSum", animalCountSum);
        // PlayerPrefs.SetInt("heart", heart);


    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        PlayerPrefs.SetInt("iscomplete0", iscomplete0?1:0);
        PlayerPrefs.SetInt("iscomplete1", iscomplete1?1:0);
        PlayerPrefs.SetInt("iscomplete2", iscomplete2?1:0);
        PlayerPrefs.SetInt("iscomplete3", iscomplete3?1:0);
        PlayerPrefs.SetInt("iscomplete4", iscomplete4?1:0);
        PlayerPrefs.SetInt("iscomplete5", iscomplete5?1:0);
        PlayerPrefs.SetInt("garbageCreatePlus", garbageCreatePlus);
        
    }

    public void Ending()
    {
        EndingPanel.SetActive(true);
    }


    // //해당 동물 오브젝트에 맞는 animalCount 반환
    // public ref int MappingAnimalCount(GameObject obj)
    // {
    //     if(obj.name == "bear")
    //     {
    //         return ref GameManager.Instance.animalCount0;
    //     }
    //     else if(obj.name == "bull")
    //     {
    //         return ref GameManager.Instance.animalCount1;
    //     }
    //     else if(obj.name == "camel")
    //     {
    //         return ref GameManager.Instance.animalCount2;
    //     }
    //     else if(obj.name == "chick")
    //     {
    //         return ref GameManager.Instance.animalCount3;
    //     }
    //     else if(obj.name == "chicken")
    //     {
    //         return ref GameManager.Instance.animalCount4;
    //     }
    //     else if(obj.name == "cock")
    //     {
    //         return ref GameManager.Instance.animalCount5;
    //     }
    //     else if(obj.name == "cow")
    //     {
    //         return ref GameManager.Instance.animalCount6;
    //     }
    //     else if(obj.name == "deer")
    //     {
    //         return ref GameManager.Instance.animalCount7;
    //     }
    //     else if(obj.name == "dog")
    //     {
    //         return ref GameManager.Instance.animalCount8;
    //     }
    //     else if(obj.name == "dove")
    //     {
    //         return ref GameManager.Instance.animalCount9;
    //     }
    //     else
    //     {
    //         Debug.Log(" error!! GameManager의 MappingAnimalCount 오류!");
    //         return ref GameManager.Instance.animalCount0;
    //     }
    // }

    
    // public void PlusAnimalCount(GameObject Obj)
    // {
    //     MappingAnimalCount(Obj)++;
    //     animalCountSum++;
    //     return;
    // }

    // public void MinusAnimalCount(GameObject Obj)
    // {
    //     MappingAnimalCount(Obj)--;
    //     animalCountSum--;
    //     return;
    // }

    // public int GetAnimalCountSum()
    // {
    //     return animalCountSum;
    // }
    
    public void PlaySfxMusic(sfx type)
    {
        switch(type) 
        {
            case sfx.LEVELUP :
                sfxMusic[0].Play();
                break;
            case sfx.BUTTON :
                sfxMusic[1].Play();
                break;
            case sfx.PICKUP :
                sfxMusic[2].Play();
                break;
            case sfx.SPAWNTRASHBAG :
                sfxMusic[3].Play();
                break;
            
        }
    }

    public void PlayBgm(bgm type)
    {
        switch(type)
        {
            case bgm.START :
                bgmMusic[0].Play();
                break;
            case GameManager.bgm.MAIN :
                bgmMusic[1].Play();
                break;
        }
    }


    public void StopBgm(bgm type)
    {
        switch(type)
        {
            case bgm.START :
                bgmMusic[0].Stop();
                break;
            case GameManager.bgm.MAIN :
                bgmMusic[1].Stop();
                break;
        }
    }
}
