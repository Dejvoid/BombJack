namespace BombJack
{
    /*
     * Bomb Jack
     * Author: David Hrivna
     * 1st year summer semester 2022/2023
     * NPRG031 (Programming 2)
     */

    // Entry point - shows first
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // Opens MainGameForm with default example map
        private void start_btn_Click(object sender, EventArgs e)
        {
            MainGameForm game = new MainGameForm("Resources/example1.json");
            game.Width = Constants.GAMEWIDTH + 50;
            game.Height = Constants.GAMEHEIGHT + 50;
            this.Hide();
            if (DealWithGameWindow(game.ShowDialog()))
            {
                game = new MainGameForm("Resources/example2.json");
                game.Width = Constants.GAMEWIDTH + 50;
                game.Height = Constants.GAMEHEIGHT + 50;
                if (DealWithGameWindow(game.ShowDialog()))
                {
                    game = new MainGameForm("Resources/exampleMap.json");
                    game.Width = Constants.GAMEWIDTH + 50;
                    game.Height = Constants.GAMEHEIGHT + 50;
                }
            }
            this.Show();
        }

        // Opens MapEditor form
        private void createMap_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MapEditor mapEditor = new MapEditor();
            mapEditor.Width = Constants.GAMEWIDTH + 100;
            mapEditor.Height = Constants.GAMEHEIGHT + 100;
            mapEditor.ShowDialog();
            this.Show();
        }

        // Opens File dialog for playing map from file and starts MainGameForm
        private void loadMap_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MainGameForm game = new MainGameForm(ofd.FileName);
                game.Width = Constants.GAMEWIDTH + 50;
                game.Height = Constants.GAMEHEIGHT + 50;
                this.Hide();
                DealWithGameWindow(game.ShowDialog());
                this.Show();
            }
            else
                MessageBox.Show("No map loaded");
        }

        // Resolves game endings (should you continue to next stage?)
        private bool DealWithGameWindow(DialogResult d)
        {
            switch (d)
            {
                case DialogResult.TryAgain: // Back to menu (player lost)
                    return false;
                case DialogResult.Continue: // Next level
                    return true;
                default: // Error
                    break;
            }
            return false;
        }
    }
}