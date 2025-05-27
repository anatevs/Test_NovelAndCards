using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;

namespace Naninovel
{
    public class PlayScriptCustom : MonoBehaviour
    {
        protected virtual string ScriptName => scriptName;
        protected virtual string ScriptText => scriptText;
        protected virtual bool PlayOnAwake => playOnAwake;
        protected virtual bool DisableWaitInput => disableWaitInput;

        [Tooltip("The script asset to play.")]
        [ResourcePopup(ScriptsConfiguration.DefaultPathPrefix, ScriptsConfiguration.DefaultPathPrefix, emptyOption: "None (play script text)")]
        [SerializeField] private string scriptName;
        [TextArea(3, 10), Tooltip("The naninovel script text (commands) to execute; has no effect when `Script Name` is specified. Argument of the event (if any) can be referenced in the script text via `{arg}` expression. Conditional block commands (if, else, etc) are not supported.")]
        [SerializeField] private string scriptText;
        [Tooltip("Whether to automatically play the script when the game object is instantiated.")]
        [SerializeField] private bool playOnAwake;
        [Tooltip("Whether to disable waiting for input mode when the script is played.")]
        [SerializeField] private bool disableWaitInput;

        private string argument;

        private IScriptPlayer _scriptPlayer;

        public virtual async Task Play()
        {
            argument = null;
            await PlayScriptAsync();
        }

        //public virtual void Play(string argument)
        //{
        //    this.argument = argument;
        //    PlayScriptAsync();
        //}

        //public virtual void Play(float argument)
        //{
        //    this.argument = argument.ToString(CultureInfo.InvariantCulture);
        //    PlayScriptAsync();
        //}

        //public virtual void Play(int argument)
        //{
        //    this.argument = argument.ToString(CultureInfo.InvariantCulture);
        //    PlayScriptAsync();
        //}

        //public virtual void Play(bool argument)
        //{
        //    this.argument = argument.ToString(CultureInfo.InvariantCulture).ToLower();
        //    PlayScriptAsync();
        //}

        protected virtual void Awake()
        {
            //if (PlayOnAwake) Play();

            _scriptPlayer = Engine.GetService<IScriptPlayer>();
        }

        protected virtual async Task PlayScriptAsync()
        {
            if (!string.IsNullOrEmpty(scriptName))
            {
                //player.ResetService();

                await _scriptPlayer.PreloadAndPlayAsync(scriptName);


                //if (!Engine.GetService<IScriptManager>().TryGetScript(scriptName, out var script))
                //    throw new Error($"Script player failed to start: script with name `{scriptName}` not found.");

                //var scriptPlaylist = new ScriptPlaylist(script);

                //player.PlayTransient(scriptPlaylist).Forget();


                return;
            }

            if (DisableWaitInput) _scriptPlayer.SetWaitingForInputEnabled(false);

            if (!string.IsNullOrWhiteSpace(scriptText))
            {
                var text = string.IsNullOrEmpty(argument) ? scriptText : scriptText.Replace("{arg}", argument);
                _scriptPlayer.PlayTransient($"`{name}` generated script", text).Forget();
            }
        }
    }
}