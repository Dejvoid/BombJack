namespace BombJack
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            MainGameForm game = new MainGameForm();
            this.Hide();
            switch (game.ShowDialog())
            {
                case DialogResult.TryAgain: // New game
                    //game = new MainGameForm();
                    break;
                case DialogResult.Continue: // Back to menu

                    break;
                default: // Error
                    break;
            }
            this.Show();
        }

        private void createMap_btn_Click(object sender, EventArgs e)
        {
            MapEditor mapEditor = new MapEditor();
            if (mapEditor.ShowDialog() == DialogResult.OK)
            {
                // save map
            }
        }

        private void loadMap_btn_Click(object sender, EventArgs e)
        {
            MainGameForm game = new MainGameForm("exampleMap.json");
            this.Hide();
            switch (game.ShowDialog())
            {
                case DialogResult.TryAgain: // New game
                    //game = new MainGameForm();
                    break;
                case DialogResult.Continue: // Back to menu

                    break;
                default: // Error
                    break;
            }
            this.Show();
        }
    }
}