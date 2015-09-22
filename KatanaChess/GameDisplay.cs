using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatanaChess
{
    public partial class GameDisplay : Form
    {
        public GameDisplay()
        {
            InitializeComponent();
        }

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            
        }

        // Tying individual click functions to Game.onClick
        private void button0_0_Click(object sender, EventArgs e)
        {
            Game.onClick(0,0);
        }

        private void button7_7_Click(object sender, EventArgs e)
        {

        }
    }
}
