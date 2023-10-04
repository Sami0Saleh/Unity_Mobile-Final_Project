using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _outsideBackGround;
    [SerializeField]
    private GameObject _studioBackGround;
    [SerializeField]
    private GameObject _tiltanRoofBackGround;
    void Update()
    {
        if (_player.level == 1)
        {
            _outsideBackGround.gameObject.SetActive(true);
            _studioBackGround.gameObject.SetActive(false);
            _tiltanRoofBackGround.gameObject.SetActive(false);
        }
        else if (_player.level == 2)
        {
            _outsideBackGround.gameObject.SetActive(false);
            _studioBackGround.gameObject.SetActive(true);
            _tiltanRoofBackGround.gameObject.SetActive(false);
        }
        else if (_player.level == 3)
        {
            _outsideBackGround.gameObject.SetActive(false);
            _studioBackGround.gameObject.SetActive(false);
            _tiltanRoofBackGround.gameObject.SetActive(true);
        }
    }
}
