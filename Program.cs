using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using VRage.Game.GUI.TextPanel;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        #region Variables
        // Screen ProgramBloc
        IMyTextSurface _textSurface;
        RectangleF _viewport;

        //Info sur les Blocs
        InfoBlocs _infoBlocs;
        string _nameGroupBattery="test";



        MySpriteDrawFrame _frame;
        Canvas canvas;
        #endregion

        #region Fonction IngameScript

        public Program()
        {
            // Reglage update
            Runtime.UpdateFrequency = UpdateFrequency.Update100;


            AE_Init();
            AE_Start();
        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            //// Begin a new frame
            //var frame = _textSurface.DrawFrame();

            //// All sprites must be added to the frame here
            //Draw(ref frame,TESTCANVAS);

            //// We are done with the frame, send all the sprites to the text panel
            //frame.Dispose();



            AE_Update();
        }

        #endregion

        void AE_Init()
        {
            // Recup du textSurface
            _textSurface = Me.GetSurface(0);
            // On calcule la position centre de notre ecran de Programme Block 
            // Calculate the viewport offset by centering the surface size onto the texture size
            _viewport = new RectangleF(
                (_textSurface.TextureSize - _textSurface.SurfaceSize) / 2f,
                _textSurface.SurfaceSize
            );
            _frame = _textSurface.DrawFrame();

            _infoBlocs = new InfoBlocs();
            _infoBlocs.Init(this);
            _infoBlocs.FindBatGrpWithName(_nameGroupBattery);

            TEST_CreationCanvas();
        }

        void AE_Start()
        {
            SetupBP(_textSurface);
            TEST_AddBar();
            Draw(canvas);
        }

        void AE_Update()
        {
            //AE_DEBUG_SPRITES();
            AE_DEBUG_INFOBLOCS();
         
            TEST_AddBar();
            Draw(canvas);
           
        }
        #region Draw

        void Draw(Canvas can)
        {
            MySpriteDrawFrame _frame = _textSurface.DrawFrame();

            if (can == null) return;

            foreach (BasePanel item in can.GetListChildrens())
            {

                if (item == null) return;
                foreach (BaseCompo baseCompo in item.Content)
                {
                    foreach (var sprite in baseCompo.content.Sprites)
                    {
                        _frame.Add(sprite);
                    }
                }

            }

            _frame.Dispose();
        }

        #endregion

        #region <-- - TEST - -->

        void TEST_CreationCanvas()
        {
            Vector2 POS_CENTRE = _viewport.Center;
            canvas = new Canvas(_textSurface);
            Panel panel = new Panel("Panel 01", POS_CENTRE, Vector2.One * 100F);
            // On ajoute le panel a norte canvas
            canvas.AddChild(panel);
        }
        float i = 0;
        void TEST_AddBar()
        {
            if (i >= 40f) i = 0;

            Panel panel = canvas.GetListChildrens()[0] as Panel;
            panel.Content.Clear();
            BarVertical bar = new BarVertical(panel.posInBasePanel.CenterHaut.Pos, Vector2.One * 55f, new Color[] { Color.Yellow, Color.Blue }, i++);

            BarVertical bar2 = new BarVertical(panel.posInBasePanel.CenterBas.Droite, new Vector2(20, 50), new Color[] { Color.Yellow, Color.Blue }, i++);
            BarVertical bar3 = new BarVertical(panel.posInBasePanel.CenterBas.Gauche, Vector2.One * 75f, new Color[] { Color.Green, Color.Blue }, i++);
            BarVertical bar4 = new BarVertical(panel.posInBasePanel.Center.Pos, new Vector2(50, 20), new Color[] { Color.Yellow, Color.Red }, i++);
            panel.Content.Add(bar);
            panel.Content.Add(bar2);
            panel.Content.Add(bar3);
            panel.Content.Add(bar4);

        }

        #endregion

        #region Setup ProgrammableBloc
        /// <summary>
        /// Ici, il faudra gere tous les differante surface des LCD
        /// Auto-setup text surface
        /// </summary>
        /// <param name="textSurface"></param>
        public void SetupBP(IMyTextSurface textSurface)
        {
            // Set the sprite display mode
            textSurface.ContentType = ContentType.SCRIPT;
            // Set color background panel /// DOTO: modif pour le backgroundColor pour ScriptBackgroundColor
            textSurface.ScriptBackgroundColor = new Color(0, 0, 0, 255);// textSurface.ScriptBackgroundColor = new Color(0, 0, 0, 255);
                                                                        // Make sure no built-in script has been selected
            textSurface.Script = "";
        }

        #endregion

        #region <-- !DEBUG! -->
        // Affichage du debug txt
        public void AE_DEBUG_SPRITES()
        {
            int nbsCompoInPanel = 0;
            Echo("Nbs de canvas: " + canvas.GetListChildrens().Count);
            foreach (BasePanel basepanel in canvas.GetListChildrens())
            {
                Echo("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
                Echo("Name: " + basepanel._name + " / Nb de BaseCompo: " + basepanel.Content.Count);

                foreach (BaseCompo baseCompo in basepanel.Content)
                {
                    nbsCompoInPanel++;
                    Echo("- -- - Compo: " + nbsCompoInPanel + " / Nbs sprite: " + baseCompo.content.Sprites.Length + " - -- -");
                    int nbSpritesInCanvas = 0;
                    foreach (MySprite sprite in baseCompo.content.Sprites)
                    {
                        nbSpritesInCanvas++;
                        Echo("- -- - Sprite: " + nbSpritesInCanvas + " - -- -");
                        Echo("Type: " + sprite.Type);
                        Echo("Data: " + sprite.Data);
                        if (sprite.Size != null) Echo("Size: " + sprite.Size);
                        Echo("Position: " + sprite.Position);

                        if (sprite.RotationOrScale != 0) Echo("RotOrScaleForTxt: " + sprite.RotationOrScale);

                    }
                }
                //break;
            }
        }

        public void AE_DEBUG_INFOBLOCS()
        {
            _infoBlocs.ShowDebugBlocUtility();
        }
        #endregion
    }
}
