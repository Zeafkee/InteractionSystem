    using DG.Tweening;
    using LuduInteraction.Runtime.Core;
    using LuduInteraction.Runtime.Player;
    using UnityEngine;

    namespace LuduInteraction.Runtime.Interactables
    {
        /// <summary>
        /// A door that can be toggled open/closed using Quaternion-based DOTween animations.
        /// </summary>
        public class Door : ToggleInteractable
        {
            #region Fields

            [Header("Lock Settings")]
            [SerializeField] private bool m_IsLocked;
            [SerializeField] private ItemData m_RequiredKey;
            
            [Header("Animation Settings")]
            [SerializeField] private Vector3 m_OpenedRotationEuler;
            [SerializeField] private float m_TransitionDuration = 1.0f;
            [SerializeField] private Ease m_TransitionEase = Ease.OutQuart;

            [Header("Prompts")]
            [SerializeField] private string m_LockedPrompt = "Locked (Key Required)";
            [SerializeField] private string m_OpenPrompt = "Close Door";
            [SerializeField] private string m_ClosedPrompt = "Open Door";

            private Quaternion m_OpenedQuaternion;
            private Quaternion m_ClosedQuaternion;
            private Tween m_RotationTween;

            #endregion

            #region Properties

            /// <summary>
            /// Returns a dynamic prompt based on the door's current state.
            /// </summary>
            public override string InteractionPrompt
            {
                get
                {
                    if (m_IsLocked)
                    {
                        string keyName = m_RequiredKey != null ? m_RequiredKey.ItemName : "Key";
                        return $"{m_LockedPrompt} ({keyName})";
                    }
                    return m_IsOn ? m_OpenPrompt : m_ClosedPrompt;
                }
            }

            #endregion

            #region Unity Methods

            private void Awake()
            {
                // Store the starting rotation as the "Closed" state
                m_ClosedQuaternion = transform.localRotation;
            }

            #endregion

            #region Overrides

            /// <inheritdoc />
            public override void OnInteractStart(GameObject interactor)
            {
                if (m_IsLocked)
                {
                    if (CheckForKey(interactor))
                    {
                        m_IsLocked = false;
                        Debug.Log("Door Unlocked!");
                        base.OnInteractStart(interactor);
                    }
                    else
                    {
                        Debug.Log("The door is locked. You need a key.");
                    }
                }
                else
                {
                    base.OnInteractStart(interactor);
                }
            }

            /// <inheritdoc />
            public override void OnInteractComplete(GameObject interactor)
            {
                // ToggleInteractable base class already flipped m_IsOn before calling this
                
                Quaternion targetRotation = m_IsOn ? Quaternion.Euler(m_OpenedRotationEuler) : m_ClosedQuaternion;

                // Handle Tween management to prevent overlapping animations
                m_RotationTween?.Kill();
                m_RotationTween = transform.DOLocalRotateQuaternion(targetRotation, m_TransitionDuration)
                    .SetEase(m_TransitionEase);

                Debug.Log(m_IsOn ? "Door Opening" : "Door Closing");
            }

            #endregion

            #region Private Methods

            private bool CheckForKey(GameObject interactor)
            {
                if (m_RequiredKey == null) return true;

                SimpleInventory inventory = interactor.GetComponent<SimpleInventory>();
                if (inventory != null)
                {
                    return inventory.HasItem(m_RequiredKey);
                }

                return false;
            }

            #endregion
        }
    }
