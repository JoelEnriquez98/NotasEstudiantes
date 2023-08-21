using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotasEstudiante
{
    public partial class Notas : System.Web.UI.Page
    {
        DataTable tableNotes = new DataTable();
        private String pathNotes = "Files/Notes.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            tableNotes.Columns.Add("Carne");
            tableNotes.Columns.Add("Nombre");
            tableNotes.Columns.Add("Apellido");
            tableNotes.Columns.Add("P1");
            tableNotes.Columns.Add("P2");
            tableNotes.Columns.Add("P3");
            tableNotes.Columns.Add("T1");
            tableNotes.Columns.Add("T2");
            tableNotes.Columns.Add("T3");
            tableNotes.Columns.Add("Zona");

            using (StreamReader file = new StreamReader(Server.MapPath(pathNotes)))
            {
                while (!file.EndOfStream)
                {
                    string[] data = file.ReadLine().Split(';');
                    if (!data[0].Equals("Carne"))
                    {
                        tableNotes.Rows.Add(data);
                    }

                }
            }

            GridViewNotes.DataSource = tableNotes;
            GridViewNotes.DataBind();
        }

        protected void GridViewNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

        }


    }
}