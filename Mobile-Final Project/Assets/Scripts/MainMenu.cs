using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    [SerializeField]
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private Vector2 _offset;
    private Vector2 _initialPosition;
    private float _rotateSpeed = 50f;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out touchPos);

        _rectTransform.anchoredPosition = touchPos + _offset;
        Vector2 rotateVector = new Vector3(1, 0);
        rotateVector *= Time.deltaTime;
        rotateVector *= _rotateSpeed;
        transform.Rotate(rotateVector);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        CheckDropZone(eventData.pointerEnter);
    }
    private void CheckDropZone(GameObject dropZone)
    {
        if (dropZone == null)
        {
            ResetPosition();
        }
        else if (dropZone.CompareTag("StartButton"))
        {
            NewGame();
        }
        else if (dropZone.CompareTag("ExitButton"))
        {
            ExitGame();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 touchPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out touchPos);

        _offset = _rectTransform.anchoredPosition - touchPos;
    }
    private void ResetPosition()
    {
        _rectTransform.anchoredPosition = _initialPosition;
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
