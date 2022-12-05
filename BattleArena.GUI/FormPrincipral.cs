using BattleArena.GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Threading;

namespace BattleArena.GUI
{
    public partial class FormPrincipral : Form
    {
        DispatcherTimer gameLoopTimer { get; set; }
        Bitmap screenBuffer { get; set; }
        Graphics screenPainter { get; set; }
        Background background { get; set; }
        List<GameObject> gameObjects { get; set; }
        public FormPrincipral()
        {
            InitializeComponent();

            this.ClientSize = Media.fundo.Size;
            this.screenBuffer = new Bitmap(Media.fundo.Width, Media.fundo.Height);
            this.screenPainter = Graphics.FromImage(this.screenBuffer);
            this.gameObjects = new List<GameObject>();
            this.background = new Background(this.screenBuffer.Size, this.screenPainter);

            this.gameLoopTimer = new DispatcherTimer(DispatcherPriority.Render);
            this.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16.6666);
            this.gameLoopTimer.Tick += GameLoop;

            this.gameObjects.Add(background);

            StartGame();
        }
        public void StartGame()
        {
            this.gameLoopTimer.Start();
        }

        public void GameLoop(object sender, EventArgs e)
        {
            foreach(GameObject gObj in this.gameObjects) 
            {
                gObj.UpdateObject();
                this.Invalidate();
            }
        }

        private void FormPrincipral_Load(object sender, EventArgs e)
        {           

        }

        private void FormPrincipral_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(this.screenBuffer, 0, 0);
        }
    }
}
