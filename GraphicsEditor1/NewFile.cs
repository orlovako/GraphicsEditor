using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor1
{
    public partial class NewFile : Form
    {
        public NewFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, принимаемый ширину рабочей области.
        /// </summary>
        public int ImageWidth
        {
            get { return (int)widthBox.Value; }
        }

        /// <summary>
        /// Метод, принимаемый ширину рабочей области.
        /// </summary>
        public int ImageHeight
        {
            get { return (int)heightBox.Value; }
        }
    }
}
