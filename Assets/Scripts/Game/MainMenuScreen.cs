using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MainMenuScreen : MonoBehaviour
    {
        // вызывается при нажатии на кнопку старта игры
        [UsedImplicitly]
        public void StartGame()
        {
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
        }
    }
}
