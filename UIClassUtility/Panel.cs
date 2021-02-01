using System.Collections.Generic;
using VRage.Game.GUI.TextPanel;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class Panel : BasePanel
        {
            public Panel()
            {
            }
            public Panel(string name, Vector2 pos, Vector2 size)
            {
                _name = name;
                _size = size;
                _pos = pos;
                posInBasePanel = SetPosInBasePanel(pos, size);
            }
        }
    }
}
