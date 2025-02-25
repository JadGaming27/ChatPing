using System.Text;
using System;
using System.Net;
using System.Net.WebSockets;

namespace ChatPing
{
    public partial class ChatPing : Form
    {
        string usrname = Environment.UserName;
        ClientWebSocket clientWebSocket = new ClientWebSocket();
        public ChatPing()
        {
            InitializeComponent();
        }
        void ChatPing_Load(object sender, EventArgs e)
        {
            /*textBox1.VisibleChanged += (sender, e) =>
            {
                if (textBox1.Visible)
                {
                    textBox1.SelectionStart = textBox1.TextLength;
                    textBox1.ScrollToCaret();
                }
            };*/
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9.]"))
            {
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "\\|"))
            {
                MessageBox.Show("No | in Messages!");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != " " && textBox3.Text.Length > 0)
            {
                await ConnectToServer("ws://" + textBox3.Text + ":5034");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != null)
                await Ping(listBox1.SelectedItem.ToString());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text != "" && textBox2.Text != " ")
            {
                await SendMessage(textBox2.Text);
                textBox2.Text = "";
            }
        }
        async Task SendMessage(string msg)
        {
            string message = "MSG|" + usrname + "|" + msg;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            try { await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None); } catch (Exception) { }
            //textBox1.Text += "\n[" + usrname.ToUpper() + "]" + "LOGON|" + usrname;
        }
        async Task Ping(string who)
        {
            string message = "PING|" + who;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            try { await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None); } catch (Exception) { }
            //textBox1.Text += "\n[" + usrname.ToUpper() + "]" + "LOGON|" + usrname;
        }
        public async Task ConnectToServer(string serverUri)
        {

            try { await clientWebSocket.ConnectAsync(new Uri(serverUri), CancellationToken.None); } catch (Exception) { }

            //Console.WriteLine("Connected to the server. Start sending messages...");

            // Send messages to the server
            string message = "LOGON|" + usrname;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            try { await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None); } catch (Exception) { }
            textBox1.Text += '\n' + "[" + usrname.ToUpper() + "]" + "LOGON|" + usrname;
            // Receive messages from the server
            byte[] receiveBuffer = new byte[1024];
            while (clientWebSocket.State == WebSocketState.Open)
            {
                try
                {
                    WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                        Console.WriteLine($"Received message from server: {receivedMessage}");
                        string[] cmds = receivedMessage.Split('|');
                        /*string test = "";
                        foreach(string cmd in cmds)
                        {
                            test += cmd+"\n";
                        }
                        MessageBox.Show(test);*/
                        if (cmds[0] == "ACCEPTLOGON" && cmds[1] == usrname)
                        {
                            MessageBox.Show("Connected.");
                            textBox1.Text += Environment.NewLine + "[SERVER]" + "ACCEPTLOGON|" + usrname;
                            button1.Enabled = true;
                            button3.Enabled = false;
                        }
                        else if (cmds[0] == "MSG")
                        {
                            textBox1.Text += Environment.NewLine + "[" + cmds[1] + "]" + "[MSG]" + cmds[2];
                        }
                        else if (cmds[0] == "USERS")
                        {
                            listBox1.Items.Clear();
                            if (!cmds[1].Contains(','))
                            {
                                listBox1.Items.Add(cmds[1]);
                            }
                            else
                            {
                                string[] lists = cmds[1].Split(',');
                                foreach (string s in lists)
                                {
                                    listBox1.Items.Add(s);
                                }
                            }
                        }
                        else if (cmds[0] == "PING")
                        {
                            if (cmds[1] == usrname.ToUpper())
                            {
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                player.SoundLocation = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Music/pop.wav";
                                player.Play();
                            }
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                if (clientWebSocket.State == WebSocketState.Aborted)
                {
                    MessageBox.Show("Server Closed.");
                    button1.Enabled = false;
                    button3.Enabled = true;
                    clientWebSocket = new ClientWebSocket();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
