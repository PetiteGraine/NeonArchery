using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject _midPointVisual, _arrowPrefab, _arrowSpawnPoint;
    [SerializeField] private float _arrowMaxSpeed = 15;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PrepareArrow()
    {
        _midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        _audioManager.PlaySFX(_audioManager.ArrowLaunch);
        _midPointVisual.SetActive(false);

        GameObject arrow = Instantiate(_arrowPrefab);
        arrow.transform.position = _arrowSpawnPoint.transform.position;
        arrow.transform.rotation = _midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(_midPointVisual.transform.forward * strength * _arrowMaxSpeed, ForceMode.Impulse);
        Destroy(arrow, 5);
    }
}