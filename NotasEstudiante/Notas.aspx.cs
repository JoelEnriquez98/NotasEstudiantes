using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotasEstudiante
{
    public partial class Notas : System.Web.UI.Page
    {
        private String pathNotes = "Files/Notes.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                loadNotes();
            }

        }



        /*
        protected void GridViewNotes_IndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewNotes.PageIndex = e.NewPageIndex;
            ButtonSave.Enabled = false;
            loadNotes();
        }
        */


        private void loadNotes()
        {
            DataTable tableNotes = new DataTable();
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

            tableNotes.Rows.Clear();
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
            ButtonSave.Enabled = false;
        }



        protected void ButtonValidate_Click(object sender, EventArgs e)
        {
            Boolean notesValid = false;

            for (int index = 0; index < GridViewNotes.Rows.Count; index++)
            {
                int carnet = Convert.ToInt32(GridViewNotes.Rows[index].Cells[0].Text);
                try
                {
                    decimal homework1 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork1")).Text);
                    decimal homework2 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork2")).Text);
                    decimal homework3 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork3")).Text);
                    decimal shortTest1 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest1")).Text);
                    decimal shortTest2 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest2")).Text);
                    decimal shortTest3 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest3")).Text);

                    Note[] notesEvaluate = new Note[6];
                    notesEvaluate[0] = new Note(homework1, 5, "Homework", "Tarea 1");
                    notesEvaluate[1] = new Note(homework2, 5, "Homework", "Tarea 2");
                    notesEvaluate[2] = new Note(homework3, 5, "Homework", "Tarea 3");
                    notesEvaluate[3] = new Note(shortTest1, 15, "Short Exam", "Parcial 1");
                    notesEvaluate[4] = new Note(shortTest2, 15, "Short Exam", "Parcial 2");
                    notesEvaluate[5] = new Note(shortTest3, 15, "Short Exam", "Parcial 3");

                    Note incorrectNote = checkCorrectAmount(notesEvaluate);

                    if (incorrectNote != null)
                    {
                        Response.Write("<script>alert('La nota: " + incorrectNote.typeNote + " deberia ser mayor a 0 y/o menor a " + incorrectNote.maximumNote + ". Por favor colocar una cantidad correcta de notas para el carnet: " + carnet + "');</script>");
                        notesValid = false;
                        ButtonSave.Enabled = false;
                        break;
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Ingrese un formeto correcto de notas para el carnet: " + carnet + "');</script>");
                    break;
                }

                notesValid = true;
            }

            if (notesValid)
            {
                ButtonSave.Enabled = true;
            }
        }

        private Note checkCorrectAmount(Note[] notes)
        {
            foreach (Note note in notes)
            {
                if (note.note >= 0)
                {
                    if (note.note > note.maximumNote)
                    {
                        return note;
                    }
                }
                else
                {
                    return note;
                }

            }
            return null;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //Update text file
            using (StreamWriter writer = new StreamWriter(Server.MapPath(pathNotes), false))
            {
                writer.WriteLine("Carne;Nombre;Apellido;P1;P2;P3;T1;T2;T3;Zona");

                for (int index = 0; index < GridViewNotes.Rows.Count; index++)
                {
                    int carne = Convert.ToInt32(GridViewNotes.Rows[index].Cells[0].Text);
                    string name = GridViewNotes.Rows[index].Cells[1].Text;
                    string lastName = GridViewNotes.Rows[index].Cells[2].Text;
                    decimal shortTest1 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest1")).Text);
                    decimal shortTest2 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest2")).Text);
                    decimal shortTest3 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxShortTest3")).Text);
                    decimal homework1 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork1")).Text);
                    decimal homework2 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork2")).Text);
                    decimal homework3 = Convert.ToDecimal(((TextBox)GridViewNotes.Rows[index].FindControl("TextBoxHomeWork3")).Text);
                    decimal finalZone = homework1 + homework2 + homework3 + shortTest1 + shortTest2 + shortTest3;

                    writer.WriteLine(carne + ";" + name + ";" + lastName + ";" + shortTest1 + ";" + shortTest2 + ";" + shortTest3 + ";" + homework1 + ";" + homework2 + ";" + homework3 + ";" + finalZone);
                }
            }
            Response.Write("<script>alert('Notas actualizadas correctamente');</script>");
            loadNotes();
        }
    }
}