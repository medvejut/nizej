using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        [Title("Test", "PlayMode Only"), Button(ButtonSizes.Large), GUIColor(0.2f, 0.8f, 1f), DisableInEditorMode]
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }
}