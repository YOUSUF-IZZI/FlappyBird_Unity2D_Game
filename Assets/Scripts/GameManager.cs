using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject column;

    [SerializeField]
    GameObject pauseMenu;

    bool game_started = false;

    void Start()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && game_started==false)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            StartCoroutine(CreateColumn());
            game_started = true;
        }
    }





    IEnumerator CreateColumn()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject new_column = Instantiate(column);
        new_column.transform.position = new Vector3(2,Random.Range(-1.04f, 2.2f), 0);
        StartCoroutine(CreateColumn());
        
    }

}
