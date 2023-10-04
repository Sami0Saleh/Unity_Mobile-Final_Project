using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _avishai;
    [SerializeField]
    private GameObject _dor;
    [SerializeField]
    private GameObject _ofir;
    void Update()
    {
        if (_player.level == 1)
        {
            _avishai.gameObject.SetActive(true);
            _dor.gameObject.SetActive(false);
            _ofir.gameObject.SetActive(false);
        }
        else if (_player.level == 2)
        {
            _avishai.gameObject.SetActive(false);
            _dor.gameObject.SetActive(true);
            _ofir.gameObject.SetActive(false);
        }
        else if (_player.level == 3)
        {
            _avishai.gameObject.SetActive(false);
            _dor.gameObject.SetActive(false);
            _ofir.gameObject.SetActive(true);
        }
    }
}
