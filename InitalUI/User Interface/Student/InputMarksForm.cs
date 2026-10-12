using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.UI.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.UI.Student
{
    public partial class InputMarksForm : Form
    {
        private int ID;
        public InputMarksForm(ViewAssignments assign, int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void UpdateMarksButtonClick(object sender, EventArgs e)
        {
            // This method validates the number of marks inputted by the user before querying the database
            // to update the new number of marks. Note: it does this through the UpdateMarks method of the AssignmentRepo
            int marksEntered = Convert.ToInt16(marksInput.Value);
            if (marksEntered < 0 )
            {
                MessageBox.Show("Please enter a mark that is greater than or equal to 0");
            }
            else
            {
                AssignmentRepo.UpdateMarks(marksEntered, ID);
            }
            this.Hide();
        }
    }
}
