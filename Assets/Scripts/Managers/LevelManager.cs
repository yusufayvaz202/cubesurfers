using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _permanentGamePrefab;
        public static LevelManager Instance;
        
        [Header("Settings")]
        private int _currentSceneIndex;

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start()
        {
            LoadNextScene();
        }

        #endregion

        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning("No more scenes to load. Returning to the first scene.");
                nextSceneIndex = 1; 
            }
            
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.buildIndex == 0) return;
            Instantiate(_permanentGamePrefab);
        }

        public void RestartCurrentScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
        }
    }
}