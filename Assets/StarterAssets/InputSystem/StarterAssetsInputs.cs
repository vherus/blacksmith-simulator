using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
        private const string MINING = "Mining";
        private const string MINING_SPEED = "MiningSpeed";

		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        private bool shouldLerpMiningAnim = false;
        private float miningTimeElapsed = 0f;
        private float amountToLerp = 0f;

        private void Update()
        {
            if (PlayerManager.Instance.IsMining && shouldLerpMiningAnim) {
                amountToLerp = Mathf.Lerp(PlayerManager.Instance.BaseMiningSpeed, PlayerManager.Instance.SuccessMiningSpeed, miningTimeElapsed / .75f);
                PlayerManager.Instance.PlayerAnimator.SetFloat(MINING_SPEED, amountToLerp);
                miningTimeElapsed += Time.deltaTime;
            } else {
                shouldLerpMiningAnim = false;
                miningTimeElapsed = 0f;
                amountToLerp = 0f;
            }
        }

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnFire(InputValue value) {
            bool isTargetingVein = PlayerManager.Instance.InteractableTarget != null && PlayerManager.Instance.InteractableTarget.gameObject.tag == "OreVein";
            if (value.isPressed && isTargetingVein && !PlayerManager.Instance.IsMining) {
                PlayerManager.Instance.IsMining = true;
                PlayerManager.Instance.PlayerAnimator.SetFloat(MINING_SPEED, PlayerManager.Instance.BaseMiningSpeed);
                PlayerManager.Instance.PlayerAnimator.SetTrigger(MINING);
                PlayerManager.Instance.UIStatusBar.gameObject.SetActive(true);
            } else {
                PlayerManager.Instance.UIStatusBar.gameObject.SetActive(false);

                if (PlayerManager.Instance.UIStatusBar.DidHitTarget) {
                    shouldLerpMiningAnim = true;
                }
            }
        }
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}