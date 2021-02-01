using System.Collections.Generic;
using VRage.Game.GUI.TextPanel;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class DEBUG_Sprite
        {

            public DEBUG_Sprite()
            {
            }

            public static MySprite AddDebugPos(Vector2 _pos)
            {
                // Create our first line
                var sprite = new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Data = "SquareTapered",
                    Position = _pos,
                    Size = Vector2.One * 10f,
                    Color = Color.Red.Alpha(0.26f),
                    Alignment = TextAlignment.CENTER
                };
                return sprite;
            }

            public static MySprite AddDebugSprite()
            {
                // Create our first line
                var sprite = new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Data = "SquareTapered",
                    Position = new Vector2(256f),// Center screen
                    Size = Vector2.One * 10f,
                    Color = Color.Blue.Alpha(0.66f),
                    Alignment = TextAlignment.CENTER
                };
                return sprite;
            }
        }
    }
}
