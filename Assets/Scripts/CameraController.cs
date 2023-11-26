using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _povCam, _3rdPersCam, _orbCam;
    [SerializeField] private bool _povActive;
    [SerializeField] private PlayableDirector _intro_Cin;
    [SerializeField] private float _timeWithoutInput;
    [SerializeField] Vector3 _updatedMousePos;
    [SerializeField] private Text _rightClick, _pressR, _introTxt;
    private bool _pressRUI;

    private void Start()
    {
        _rightClick.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _pressR.gameObject.SetActive(false);
            
            if (_povActive == false)
            {
                _3rdPersCam.Priority = 11;
                _povCam.Priority = 10;
                _povActive = true;
                _introTxt.gameObject.SetActive(true);

            }
            else if (_povActive == true)
            {
                _3rdPersCam.Priority = 10;
                _povCam.Priority = 11;
                _povActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _orbCam.Priority = 12;
            _rightClick.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _orbCam.Priority = 10;
            if (!_pressR.gameObject.activeInHierarchy && _pressRUI == false)
            {
                _pressR.gameObject.SetActive(true);
                _pressRUI = true;
            }

        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    _introTxt.gameObject.SetActive(false);
        //    _intro_Cin.Play();
        //}
        if (Input.anyKey)
        {
            _timeWithoutInput = 0;
            _intro_Cin.Stop();
        }
        if (Input.mousePosition != _updatedMousePos)
        {
            _timeWithoutInput = 0;
            _intro_Cin.Stop();
        }

        _timeWithoutInput += Time.deltaTime;

        if (_timeWithoutInput >= 5)
        {
            _introTxt.gameObject.SetActive(false);
            IdleCinematic();
        }
        _updatedMousePos = Input.mousePosition;
    }

    void IdleCinematic()
    {
        _pressR.gameObject.SetActive(false);
        _rightClick.gameObject.SetActive(false);
        _intro_Cin.Play();
    }
}
