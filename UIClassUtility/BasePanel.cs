using System.Collections.Generic;
using VRage.Game.GUI.TextPanel;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class BasePanel
        {
            internal string _name;// Nom de notre panel
            internal Canvas _parent;// Le parent de notre panel

            internal Vector2 _pos;// Position dans la canvas Parent
            internal Vector2 _size;// Taille du panel

            //Setup des possition predefini dans le panel
            internal AE_PosIntern posInBasePanel = new AE_PosIntern();


            // Liste de sprite de notre panel
            public List<BaseCompo> Content = new List<BaseCompo>();


            #region Construcor ..
            /// <summary>
            /// Constructor Empty
            /// </summary>
            public BasePanel() { }
            public BasePanel(string name, Canvas parent, Vector2 pos)
            {
                _name = name;
                _parent = parent;
                _pos = pos;
                _size = Vector2.Zero;
            }
            public BasePanel(string name, Canvas parent, Vector2 pos, Vector2 size, AE_PosIntern posInBaseCanvas)
            {
                _name = name;
                _parent = parent;
                _pos = pos;
                _size = size;
                this.posInBasePanel = posInBaseCanvas;
            }

            public AE_PosIntern SetPosInBasePanel(Vector2 pos, Vector2 size)
            {
                return new AE_PosIntern(pos, size);
            }
            #endregion
        }
    }
}
