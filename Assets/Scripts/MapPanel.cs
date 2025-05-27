using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Naninovel;

namespace NaninovelScripts
{
    public class MapPanel : CustomUI, IMapUI
    {
        [SerializeField]
        private Button[] _locationButtons;

        private UnityAction[] _clickActions;

        protected override void Awake()
        {
            base.Awake();

            _clickActions = new UnityAction[_locationButtons.Length];

            for (int i = 0; i < _locationButtons.Length; i++)
            {
                int c = i;

                _clickActions[i] = new UnityAction(() => SelectLocation(c));
            }
        }

        protected override void OnEnable()
        {
            for (int i = 0; i < _locationButtons.Length; i++)
            {
                _locationButtons[i].onClick.AddListener(_clickActions[i]);

                //var playScript = _locationButtons[i].GetComponent<PlayScriptCustom>();

                //_locationButtons[i].onClick.AddListener(playScript.Play);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            foreach (var button in _locationButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }

        public void SelectLocation(int index)
        {
            //onclick

            //highlight

            this.Hide();
        }

        public void SetLocationAvailable(int index, bool isActive)
        {
            _locationButtons[index].interactable = isActive;
        }
    }
}