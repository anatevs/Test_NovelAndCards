using Naninovel;
using System;
using UnityEngine;

namespace NaninovelScripts
{
    public class PlayScriptButton : ScriptableButton
    {
        [Tooltip("The script asset to play.")]
        [ResourcePopup(ScriptsConfiguration.DefaultPathPrefix, ScriptsConfiguration.DefaultPathPrefix, emptyOption: "None (play script text)")]
        [SerializeField]
        private string _scriptName;


        private string[] excludeFromReset = Array.Empty<string>();


        private IScriptPlayer _scriptPlayer;

        //private IStateManager _stateManager;


        protected override void Awake()
        {
            base.Awake();

            _scriptPlayer = Engine.GetService<IScriptPlayer>();

            //_stateManager = Engine.GetService<IStateManager>();
        }

        protected override async void OnButtonClick()
        {
            if (string.IsNullOrEmpty(_scriptName))
            {
                Engine.Err("Can't play a script: specify a name for the naninovel script.");
                return;
            }

            //_stateManager.ResetStateAsync(excludeFromReset,
            //    () => _scriptPlayer.PreloadAndPlayAsync(_scriptName)).Forget();

            await PlayScript();
        }

        protected virtual async UniTask PlayScript()
        {
            //_scriptPlayer.ResetService();


            await _scriptPlayer.PreloadAndPlayAsync(_scriptName);

            //await UniTask.WaitWhile(() => _scriptPlayer.Playing);
        }
    }
}