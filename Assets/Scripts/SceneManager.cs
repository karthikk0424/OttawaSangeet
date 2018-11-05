using UnityEngine;
using System.Collections;

namespace OttawaSangeet
{
    public class SceneManager : MonoBehaviour
    {
        public static string ParentScene = string.Empty;

        private static SceneManager _instance;
        // Use this for initialization
        void Start()
        {
            if (!_instance)
                _instance = this;
            //otherwise, if we do, kill this thing
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
				PlayMovie(MovieConstants.CLEAN_BLUE);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                PlayMovie(MovieConstants.COLORFUL_RAYS);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                PlayMovie(MovieConstants.TRAVEL_BLUE_NEBULA);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                PlayMovie(MovieConstants.HALO_DESIGN);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                PlayMovie(MovieConstants.BLUE_MOTION);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                PlayMovie(MovieConstants.FIRE);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                PlayMovie("stage lights");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Application.LoadLevel("Splash");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayMovie(MovieConstants.DISCO_BALL_COLOR);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                PlayMovie(MovieConstants.MAGICAL_GROUND);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Application.LoadLevel("Applauncher");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                PlayMovie(MovieConstants.TORNADO);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                PlayMovie(MovieConstants.PARTY);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayMovie(MovieConstants.RAINBOW_FLARE);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PlayMovie(MovieConstants.RAINBOW_SPACE);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                PlayMovie(MovieConstants.GLOWING_RING);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel("CreditsFireworks");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
				Application.LoadLevel("IntroSequence");
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                PlayMovie("luminousstars");
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                Application.LoadLevel("Sequencer");
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                PlayMovie(MovieConstants.STRONGHOLD);
            }
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                PlayMovie("Flying light particles");
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("OctaneSplatt");
            }
        }

        private void PlayMovie(string movieName)
        {
            ParentScene = Application.loadedLevelName;
            MovieManager.Instance.ClearQueue();
            MovieManager.Instance.PlayVideo(movieName, false, false, true);
        }
    }
}