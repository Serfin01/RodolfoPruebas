using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Player
{
    public Animator transition;
    public Animator _animator;
    public Animator musicInPause;
    public int transitionTime;
    public static bool isGamePaused = false;
    [SerializeField] GameObject ragDoll;
    public AudioSource ADeath;
    public bool isAlive = true;
    [SerializeField] int healing;

    void Update()
    {
        if (currentHealth <= 0 && isAlive == true)
        {
            
            Debug.Log("maricon");
            gameObject.GetComponentInChildren<Animator>().enabled = false;
            gameObject.GetComponent<a>().canMove = false;
            ragDoll.SetActive(true);
            isAlive = false;
            LoadNextLevel();
            ADeath.Play();
        }
        healthBar.SetHealth(currentHealth);
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
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
        if (other.CompareTag("MediKit"))
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += healing;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        FindObjectOfType<AudioManager>().Play("hitted");
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        musicInPause.SetBool("Pause", false);
    }

    void PauseGame()
    {
        musicInPause.SetBool("Pause", true);
        isGamePaused = true;
    }

    public override void Damaged(int damage)
    {
        _animator.SetTrigger("hitted");
        currentHealth -= damage;
    }
}
