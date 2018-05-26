using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK;
using BaseActions;

namespace GraphicsEditor1
{
    public partial class HistoryActions : Form
    {       

        public HistoryActions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, помещмющий список действий в лист с историей.
        /// </summary>
        /// <param name="listActions">Переменная, хранящая список с классами действий.</param>
        public void DisplayListActions(List<IBaseActions> listActions)
        {
            foreach (IBaseActions _actions in listActions)
            {                
                listBox1.Items.Add(_actions.Operation());
            }
        }        
    }
}
