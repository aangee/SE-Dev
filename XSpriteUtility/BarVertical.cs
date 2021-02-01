using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class BarVertical : BaseCompo
        {
            public float fill = 0f;
            public BarVertical()
            {
            }

            public BarVertical(Vector2 pos, Vector2 size, Color[] _colors,float fill)
            {
                this.pos = pos;
                this.size = size;
                this.fill = fill;
                this.content.Sprites = Construct(pos,size,_colors);
            }

            MySprite[] Construct(Vector2 _pos, Vector2 _size, Color[] _colors)
            {
                MySprite[] compos = new MySprite[2];

                // On crée le contour de la barre avec une nvlle sprite 
                // elle sert de ref pour tous les autres
                compos[0] = new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Data = "SquareHollow",
                    Position = _pos,
                    Size = _size,
                    Color = (_colors.Length == 0) ? Color.Red.Alpha(0.26f) : _colors[0],
                    Alignment = TextAlignment.CENTER
                };

                // On calcule la SizeY du remplissage
                float sizeY = compos[0].Size.Value.Y - fill;
                // On calcule la positionY du remplissage
                float posY = compos[0].Position.Value.Y + (fill / 2);

                // On crée l'interieur de la barre avec une nvlle sprite
                compos[1] = new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Data = "SquareTapered",
                    Position = new Vector2(compos[0].Position.Value.X, posY),
                    Size = new Vector2(compos[0].Size.Value.X, sizeY),
                    Color = (_colors.Length == 0) ? Color.Red.Alpha(0.46f) : _colors[1],

                    Alignment = TextAlignment.CENTER
                };


                return compos;
            }
        }
    }
}
