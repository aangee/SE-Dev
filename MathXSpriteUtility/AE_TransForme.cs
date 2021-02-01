using System;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class AE_TransForme
        {
            public Vector2 Pos;
            public Vector2 Droite;
            public Vector2 Gauche;

            public AE_TransForme() { }
            public AE_TransForme(Vector2 pos, float size)
            {
                Pos = pos;
                Droite = new Vector2(pos.X + (size / 2f), pos.Y);
                Gauche = new Vector2(pos.X - (size / 2f), pos.Y);
            }

        }
    }
}
