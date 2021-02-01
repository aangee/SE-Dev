using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class AE_PosIntern
        {
            public AE_TransForme Center = new AE_TransForme();
            public AE_TransForme CenterHaut = new AE_TransForme();
            public AE_TransForme CenterBas = new AE_TransForme();

            public AE_PosIntern() { }
            /// <summary>
            /// Calcule de tous les position a interieur du carre
            /// </summary>
            /// <param name="center">Position centre</param>
            /// <param name="size">Taille de notre carre</param>
            public AE_PosIntern(Vector2 center,Vector2 size)
            {
                Vector2 calculePos;

                Center = new AE_TransForme(center,size.X);

                calculePos = new Vector2(center.X, center.Y - (size.Y / 2f));
                CenterHaut = new AE_TransForme(calculePos,size.X);

                calculePos = new Vector2(center.X, center.Y + (size.Y / 2f));
                CenterBas = new AE_TransForme(calculePos, size.X);
            }

        }
    }
}
