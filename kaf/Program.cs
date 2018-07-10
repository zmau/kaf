using kaf.dal;
using kaf.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                System.Data.Entity.Database.SetInitializer(strategy: new PubContext.SystemInitializer());
                Application.Run(new BaseForm());
                //initDatabaseData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if(e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
            }
        }

        private static void initDatabaseData() {
            PubContext dbContext = new PubContext();
            /*Role owner = new Role("administrator");
            dbContext.Roles.Add(owner);
            Role admin = new Role("menadžer");
            dbContext.Roles.Add(admin);
            Role employee = new Role("konobar");
            dbContext.Roles.Add(employee);
            */
            dbContext.MeasureUnits.Add(new MeasureUnit() { name = "lit" });
            dbContext.MeasureUnits.Add(new MeasureUnit() { name = "kom" });
            dbContext.MeasureUnits.Add(new MeasureUnit() { name = "kg" });
            dbContext.MeasureUnits.Add(new MeasureUnit() { name = "dan" });
            dbContext.MeasureUnits.Add(new MeasureUnit() { name = "por" });

            dbContext.SaveChanges();

        }
    }
}
