using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour {
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
}
