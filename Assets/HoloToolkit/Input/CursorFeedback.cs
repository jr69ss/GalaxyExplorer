﻿// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
namespace HoloToolkit.Unity
{
    using UnityEngine;

    /// <summary>
    /// CursorFeedback class takes GameObjects to give cursor feedback
    /// to users based on different states.
    /// </summary>
    public class CursorFeedback : MonoBehaviour
    {
        [Tooltip("Drag a prefab object to display when a hand is detected.")]
        public GameObject HandDetectedAsset;
        private GameObject handDetectedGameObject;

        [Tooltip("Drag a prefab object to parent the feedback assets.")]
        public GameObject FeedbackParent;

        private void Awake()
        {
            if (HandDetectedAsset != null)
            {
                handDetectedGameObject = InstantiatePrefab(HandDetectedAsset);
            }
        }

        private GameObject InstantiatePrefab(GameObject inputPrefab)
        {
            GameObject instantiatedPrefab = null;

            if (inputPrefab != null && FeedbackParent != null)
            {
                instantiatedPrefab = GameObject.Instantiate(inputPrefab);

                // Assign parent to be the FeedbackParent
                // so that feedback assets move and rotate with this parent.
                instantiatedPrefab.transform.parent = FeedbackParent.transform;

                // Set starting state of gameobject to be inactive.
                instantiatedPrefab.gameObject.SetActive(false);
            }

            return instantiatedPrefab;
        }

        private void Update()
        {
            UpdateHandDetectedState();
        }

        private void UpdateHandDetectedState()
        {
            if (handDetectedGameObject == null)
            {
                return;
            }

            handDetectedGameObject.SetActive(HandsManager.Instance.HandDetected);
        }
    }
}