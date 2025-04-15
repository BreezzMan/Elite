using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Slider _hpStationBar;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _station;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _diePanel;

    private bool _isPause;
    private bool _isDie;

    private void Start()
    {
        _isPause = false;
        _isDie = false;

        _hpBar.maxValue = _player.GetComponent<shipController>().GetHP();
        _hpBar.value = _hpBar.maxValue;

        _hpStationBar.maxValue = _station.GetComponent<StationController>().GetHP();
        _hpStationBar.value = _hpStationBar.maxValue;
    }

    private void Update()
    {
        _hpBar.value = _player.GetComponent<shipController>().GetHP();
        _hpStationBar.value = _station.GetComponent<StationController>().GetHP();

        if (Input.GetKeyDown(KeyCode.Escape) && !_isDie )
        {
            ChangePause();
        }

        if (_isPause)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        Cursor.visible = _isPause || _isDie;
        _pausePanel.SetActive(_isPause);

        if (_isDie )
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            _isPause = false;
        }

        _diePanel.SetActive(_isDie);

        if (_hpBar.value <= 0 || _hpStationBar.value <= 0)
        {
            _isDie = true;
        }

    }

    public void ChangePause()
    {
        _isPause = !_isPause;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
