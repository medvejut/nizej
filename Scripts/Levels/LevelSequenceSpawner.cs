using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    public class LevelSequenceSpawner : MonoBehaviour
    {
        [AssetsOnly]
        public GameObject[] sequences;

        [Required, SceneObjectsOnly]
        public GameObject player;

        public int maxSpawnedSequences = 3;

        private Transform _parent;
        private List<GameObject> _spawned;

        private void Start()
        {
            _parent = new GameObject($"[Temp] {name}").transform;
            _spawned = new List<GameObject>();
        }

        [Title("Test", "PlayMode only"), Button(ButtonSizes.Large), DisableInEditorMode, GUIColor(0.2f, 0.8f, 1f)]
        public void Spawn()
        {
            if (sequences.Length == 0)
            {
                Debug.LogWarning($"Empty sequence", this);
                return;
            }

            var previous = _spawned.Count > 0 ? _spawned[_spawned.Count - 1] : null;

            var original = sequences[Random.Range(0, sequences.Length)];
            var current = Instantiate(original, _parent);
            _spawned.Add(current);

            Vector3 position;
            if (previous)
            {
                position = previous.transform.position;

                var previousOptions = previous.GetComponent<LevelSequence>();
                if (previousOptions)
                {
                    position += previousOptions.outPosition;
                }
                else
                {
                    Debug.LogWarning($"LevelSequence component not found for {previous.name}", this);
                }
            }
            else
            {
                position = transform.position;
            }

            var currentOptions = current.GetComponent<LevelSequence>();
            if (currentOptions)
            {
                position -= currentOptions.inPosition;
            }
            else
            {
                Debug.LogWarning($"LevelSequence component not found for {current.name}", this);
            }

            current.transform.position = position;

            var reflect = Random.value > 0.5f;
            if (reflect)
            {
                for (int i = 0; i < current.transform.childCount; i++)
                {
                    var child = current.transform.GetChild(i);
                    var reflectedPosition = child.transform.localPosition;
                    reflectedPosition.x = 10f - reflectedPosition.x;
                    child.transform.localPosition = reflectedPosition;
                }
            }
        }

        private void Update()
        {
            if (_spawned.Count == 0 || player.transform.position.y < _spawned[_spawned.Count - 1].transform.position.y)
            {
                Spawn();
            }

            if (_spawned.Count > maxSpawnedSequences)
            {
                var objectToRemove = _spawned[0];
                _spawned.Remove(objectToRemove);
                Destroy(objectToRemove);
            }
        }
    }
}