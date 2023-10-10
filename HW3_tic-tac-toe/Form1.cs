using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HW3_tic_tac_toe
{
    public partial class Form1 : Form
    {
        int udpPort = 44444;
        bool canPlay = false;
        TcpListener tcpListener;
        Player currentPlayer = new Player();
        List<Player> players = new List<Player>();
        TTTgame game = new();
        Button[,] buttons = new Button[3, 3];
        Player? enemy = null;
        TcpClient? tcpClientEnemy = null;
        IPAddress network;
        public Form1()
        {
            InitializeComponent();
            InitButtonsArray();
            listBoxPlayers.DisplayMember = "Name";
            comboBox1.DataSource = Dns.Resolve(SystemInformation.ComputerName).AddressList;
            network = comboBox1.SelectedItem as IPAddress;     
        }
        private void InitButtonsArray()
        {
            buttons[0, 0] = button1;
            buttons[0, 1] = button2;
            buttons[0, 2] = button3;
            buttons[1, 0] = button4;
            buttons[1, 1] = button5;
            buttons[1, 2] = button6;
            buttons[2, 0] = button7;
            buttons[2, 1] = button8;
            buttons[2, 2] = button9;
        }

        private async Task Login()
        {
            try
            {
                UdpClient udpClient = new UdpClient(new IPEndPoint(network, 0));
                udpClient.Connect(IPAddress.Broadcast, udpPort);
                string message = $"{currentPlayer.Id} {currentPlayer.Name} {currentPlayer.EndPoint}";
                var data = Encoding.UTF8.GetBytes(message);
                await udpClient.SendAsync(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListenUdp()
        {
            UdpClient udpClient = new UdpClient(new IPEndPoint(network, udpPort));
            while (true)
            {
                IPEndPoint broudcustEndPoint = new IPEndPoint(IPAddress.Broadcast, udpPort);
                var bytes = udpClient.Receive(ref broudcustEndPoint);
                var message = Encoding.UTF8.GetString(bytes);
                var messageParts = message.Split(' ');
                Player player = new Player();
                player.Id = messageParts[0];
                player.Name = messageParts[1];
                player.EndPoint = IPEndPoint.Parse(messageParts[2]);
                if (player.Id == currentPlayer.Id)
                {
                    continue;
                }
                players.Add(player);
                listBoxPlayers.Invoke(new Action(() => listBoxPlayers.Items.Add(player)));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Please enter your name");
                return;
            }
            await Login();
        }
        private async void ListenTcp()
        {
            while (true)
            {
                try
                {
                    if (tcpListener.Pending() && enemy is null)
                    {
                        var client = tcpListener.AcceptTcpClient();
                        var stream = client.GetStream();
                        StreamReader reader = new StreamReader(stream);
                        var message = await reader.ReadLineAsync();
                        if (message == "Play")
                        {
                            var id = await reader.ReadLineAsync();
                            enemy = players.FirstOrDefault(p => p.Id == id);
                            if (enemy is null)
                            {
                                MessageBox.Show("Player not found");
                                continue;
                            }
                            var res = MessageBox.Show($"Play with {enemy.Name}?", "Invitation to the game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            StreamWriter writer = new StreamWriter(stream);
                            switch (res)
                            {
                                case DialogResult.Yes:
                                    await writer.WriteLineAsync("Yes");
                                    await writer.FlushAsync();
                                    tcpClientEnemy = client;
                                    MessageBox.Show("Game started");
                                    break;
                                default:
                                    await writer.WriteLineAsync("No");
                                    await writer.FlushAsync();
                                    client.Close();
                                    ResetGame();
                                    break;
                            }
                        }
                    }
                    if (enemy is not null)
                    {
                        //if (tcpClientEnemy is null)
                        //{
                        //    tcpClientEnemy = new TcpClient();
                        //    await tcpClientEnemy.ConnectAsync(enemy.EndPoint);
                        //}
                        var stream = tcpClientEnemy.GetStream();
                        if (!stream.DataAvailable) continue;
                        var reader = new StreamReader(stream);
                        var message = reader.ReadLine();
                        if (message == "Move")
                        {
                            var x = int.Parse(await reader.ReadLineAsync());
                            var y = int.Parse(await reader.ReadLineAsync());
                            if (game.IsCellEmpty(x, y))
                            {
                                game.SetCell(x, y, -1);
                                buttons[x, y].Invoke(new Action(() => buttons[x, y].Text = "O"));
                                switch (game.CheckWinner())
                                {
                                    case 1:
                                        MessageBox.Show("You win");
                                        ResetGame();
                                        break;
                                    case -1:
                                        MessageBox.Show("You lose");
                                        ResetGame();
                                        break;
                                    case 0:
                                        if (game.IsBoardFull())
                                        {
                                            MessageBox.Show("Draw");
                                            ResetGame();
                                        }
                                        break;
                                }
                            }
                            canPlay = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ResetGame()
        {
            game.ClearBoard();
            enemy = null;
            tcpClientEnemy?.Close();
            tcpClientEnemy = null;
            buttonPlay.Invoke(new Action(() => { buttonPlay.Enabled = true; }));
            foreach (var button in buttons)
            {
                button.Invoke(new Action(() => { button.Text = ""; }));
            }
        }

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select a player");
                return;
            }
            Player player = (Player)listBoxPlayers.SelectedItem;
            tcpClientEnemy = new TcpClient(new IPEndPoint(network, 0));
            await tcpClientEnemy.ConnectAsync(player.EndPoint);
            var stream = tcpClientEnemy.GetStream();
            var writer = new StreamWriter(stream);
            var reader = new StreamReader(stream);
            await writer.WriteLineAsync("Play");
            await writer.WriteLineAsync(currentPlayer.Id);
            await writer.FlushAsync();
            var message = await reader.ReadLineAsync();
            if (message == "Yes")
            {
                canPlay = true;
                enemy = player;
                (sender as Button).Enabled = false;
                MessageBox.Show("Game started");
            }
            else
            {
                MessageBox.Show("Player refused to play");
            }
        }

        private async void board_Click(object sender, EventArgs e)
        {
            if (!canPlay)
            {
                MessageBox.Show("You can't play now");
                return;
            }
            var button = (Button)sender;
            var point = button.Tag.ToString().Split(' ');
            var x = int.Parse(point[0]);
            var y = int.Parse(point[1]);
            var stream = tcpClientEnemy.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            await writer.WriteLineAsync("Move");
            await writer.WriteLineAsync(x.ToString());
            await writer.WriteLineAsync(y.ToString());
            await writer.FlushAsync();
            if (game.IsCellEmpty(x, y))
            {
                game.SetCell(x, y, 1);
                buttons[x, y].Invoke(new Action(() => buttons[x, y].Text = "X"));
                switch (game.CheckWinner())
                {
                    case 1:
                        MessageBox.Show("You win");
                        game.ClearBoard();
                        break;
                    case -1:
                        MessageBox.Show("You lose");
                        game.ClearBoard();
                        break;
                    case 0:
                        if (game.IsBoardFull())
                        {
                            MessageBox.Show("Draw");
                            game.ClearBoard();
                        }
                        break;
                }
                canPlay = false;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            currentPlayer.Name = textBoxName.Text;
        }

        private void buttonStopGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            network = comboBox1.SelectedItem as IPAddress;
            button10.Enabled = true;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(network, 0);
            tcpListener.Start();
            currentPlayer.Id = Guid.NewGuid().ToString();
            currentPlayer.EndPoint = (IPEndPoint)tcpListener.LocalEndpoint;
            Task.Run(() => ListenUdp());
            Task.Run(() => ListenTcp());
            button10.Enabled = false;
        }
    }
}