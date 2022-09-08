using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    public GameObject EndingPanel;
    public GameObject EndingScrollPanel;
    public GameObject mainCamera;
    public GameObject endingCamera;
    public float scrollMax;
    private void OnEnable()
    {
        EndingPanel.SetActive(true);
        mainCamera.SetActive(false);
        endingCamera.SetActive(true);
        StartCoroutine("AutoScroll");
    }

    IEnumerator AutoScroll()
    {
        float location = EndingScrollPanel.transform.position.y;
        while(EndingScrollPanel.transform.position.y - location < scrollMax)
        {
            EndingScrollPanel.transform.position += new Vector3(0,20,0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
