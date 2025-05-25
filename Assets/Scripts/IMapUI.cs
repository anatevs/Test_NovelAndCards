using Naninovel.UI;

namespace NaninovelScripts
{
    public interface IMapUI : IManagedUI
    {
        public void SetLocationAvailable(int index, bool isActive);

        public void SelectLocation(int index);
    }
}