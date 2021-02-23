using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Player
{
    public Animator transition;
    public Animator _animator;
    public int transitionTime;
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("maricon");
            LoadNextLevel();
            FindObjectOfType<AudioManager>().Play("rodolfodeath");
            //Destroy(this.gameObject);
        }
        healthBar.SetHealth(currentHealth);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            FindObjectOfType<AudioManager>().Play("hitted");
            _animator.SetTrigger("hitted");

        }
    }
}
