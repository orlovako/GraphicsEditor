using Basis;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;
using BaseData;

namespace GraphicsEditor1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Canva MainForm = new Canva();

            UnityContainer UnityContainerInit = new UnityContainer();

            DataInitialization InitializatioForm = UnityContainerInit.Resolve<DataInitialization>(new OrderedParametersOverride(new object[] { MainForm.Width, MainForm.Height }));

            MainForm.InitializatioForm = InitializatioForm;

            MainForm.Workspace = InitializatioForm.ReturnWorkspace();            

            Application.Run(MainForm);

            //Application.Run(new Canva());
        }
    }
}
