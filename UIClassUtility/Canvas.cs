using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class Canvas
        {
            internal IMyTextSurface _parent;
            // Liste de tous nos Panel cree
            List<BasePanel> childrens = new List<BasePanel>();


            // Constructeur Empty
            public Canvas() { }
            public Canvas(IMyTextSurface parent)
            {
                _parent = parent;
            }
            /// <summary>
            /// Pour ajoute un nouveau (BasePanel) a la liste du (Canvas)
            /// </summary>
            /// <param name="bPanel">BasePanel a ajoute</param>
            public void AddChild(BasePanel bPanel)
            {
                childrens.Add(bPanel);
            }

            public List<BasePanel> GetListChildrens()
            {
                return childrens;
            }
        }
    }
}
