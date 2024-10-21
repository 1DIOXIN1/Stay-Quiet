using System.Collections;
using UnityEngine;

public class OffTip : MonoBehaviour
{
    [SerializeField] private GameObject _uiTip;
    [SerializeField] private float _timeBeforOff;
    void Start()
    {
        StartCoroutine(Off(_timeBeforOff));
    }

    IEnumerator Off(float timeBeforOff)
    {
        yield return new WaitForSeconds(timeBeforOff);
        _uiTip.SetActive(false);
    }
}
