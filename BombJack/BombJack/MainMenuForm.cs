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
            game.Width = Constants.GAMEWIDTH + 50;
            game.Height = Constants.GAMEHEIGHT + 50;
            this.Hide();
            DealWithGameWindow(game.ShowDialog());
            this.Show();
        }

        private void createMap_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MapEditor mapEditor = new MapEditor();
            mapEditor.ShowDialog();
            this.Show();
        }

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
        private void DealWithGameWindow(DialogResult d)
        {
            switch (d)
            {
                case DialogResult.TryAgain: // Back to menu (player lost)
                    //game = new MainGameForm();
                    break;
                case DialogResult.Continue: // Next level

                    break;
                default: // Error
                    break;
            }
        }
    }
}