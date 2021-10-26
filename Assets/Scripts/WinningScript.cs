using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    [SerializeField] private Material _winMaterial;
    [SerializeField] private GameObject _winUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WinRoutine()
    {
        GetComponent<MeshRenderer>().material = _winMaterial;

        _winUI.SetActive(true);
        Time.timeScale = 0.25f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WinRoutine());
        }
    }
}
