using Naninovel;
using Naninovel.UI;

namespace NaninovelScripts
{
    public class ControlPanelMapButton : ScriptableLabeledButton
    {
        private IUIManager _uiManager;

        protected override void Awake()
        {
            base.Awake();

            _uiManager = Engine.GetService<IUIManager>();
        }

        protected override void OnButtonClick()
        {
            _uiManager.GetUI<IPauseUI>()?.Hide();
            _uiManager.GetUI<IMapUI>()?.Show();
        }
    }
}